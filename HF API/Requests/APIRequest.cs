﻿using HF_API.Helpers;
using HF_API.Enums;
using HF_API.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Concurrent;
using HF_API.Extensions;

namespace HF_API.Requests
{
    /// <summary>
    /// Represents an request to the HF API
    /// </summary>
    internal abstract class APIRequest
    {
        /// <summary>
        /// The base url.
        /// </summary>
        private const string BaseUrl = "https://hackforums.net/api/v2";

        /// <summary>
        /// The request posting parameters.
        /// </summary>
        /// <returns>The dictionary of parameters to pass into the request.</returns>
        protected Dictionary<string, object> Parameters { get; } = new Dictionary<string, object>();

        /// <summary>
        /// The request ask (me/forums/threads/posts/users/bytes/contracts)
        /// </summary>
        protected abstract RequestAsk Ask { get; }

        /// <summary>
        /// The request type (read/write/authorize).
        /// </summary>
        protected RequestType Type { get; set; }

        /// <summary>
        /// Whether this request requires an authorization token.
        /// </summary>
        protected virtual bool RequireAuthToken => true;

        /// <summary>
        /// Gets the path for this request endpoint.
        /// </summary>
        /// <returns>The url for the request.</returns>
        protected virtual string GetRequestPath() => UriHelper.Combine(BaseUrl, Type.ToString().ToLower());

        /// <summary>
        /// Gets the content data for the request.
        /// </summary>
        /// <returns>The FormUrlEncodedContent to pass into the request.</returns>
        protected virtual FormUrlEncodedContent GetParameters() => new FormUrlEncodedContent(new []
        {
            KeyValuePair.Create("asks", JsonConvert.SerializeObject(new Dictionary<string, Dictionary<string, object>> { { Ask.ToString().ToLower(), Parameters } }))
        });

        /// <summary>
        /// Adds the result parameters to the Parameter collection.
        /// </summary>
        internal virtual Dictionary<string, object> AddResultParameters() { return new Dictionary<string, object>(); }

        /// <summary>
        /// For caching parameter result sets.
        /// </summary>
        private static Dictionary<Type, Dictionary<string, object>> resultCache = new Dictionary<Type, Dictionary<string, object>>();

        /// <summary>
        /// Lock object for cache editing.
        /// </summary>
        private static object cacheLock = new object();

        /// <summary>
        /// Lock object for cache editing.
        /// </summary>
        private static Dictionary<Type, object> cacheTypeLock = new Dictionary<Type, object>();

        /// <summary>
        /// Adds result parameter to the parameter collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterName"></param>
        /// <param name="include"></param>
        protected KeyValuePair<string, object> AddResultParameter<T>(string parameterName, bool include = true)
        {
            // If not including, just set to false to prevent any results
            if (!include)
            {
                Parameters.Add(parameterName, include);
                return KeyValuePair.Create(parameterName, (object)include);
            }

            var type = typeof(T);
            if (!resultCache.ContainsKey(type))
            {
                lock (cacheLock)
                {
                    if (!resultCache.ContainsKey(type))
                    {
                        resultCache.TryAdd(type, new Dictionary<string, object>());
                        cacheTypeLock.Add(type, new object());
                    }
                }
            }

            if (!resultCache[type].ContainsKey(parameterName))
            {
                lock (cacheTypeLock[type])
                {
                    if (!resultCache[type].ContainsKey(parameterName))
                    {
                        if (type.IsSubclassOf(typeof(APIResult)))
                        {
                            var result = Activator.CreateInstance<T>() as APIResult;
                            resultCache[type].Add(parameterName, result.GetResultParameters());
                        }
                        else
                        {
                            resultCache[type].Add(parameterName, true);
                        }
                    }
                }
            }

            var param = KeyValuePair.Create(parameterName, resultCache[type][parameterName]);
            Parameters.Add(param.Key, param.Value);
            return param;
        }

        /// <summary>
        /// Attempts to process the request.
        /// </summary>
        /// <typeparam name="T">The expected APIResult to get from this request.</typeparam>
        /// <param name="client">The client to use to process this request.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        protected T ProcessRequest<T>(HttpClient client) where T : APIResult
        {
            var requestTask = ProcessRequestAsync<T>(client);
            requestTask.Wait();
            return requestTask.Result;
        }

        /// <summary>
        /// Attempts to process the request.
        /// </summary>
        /// <typeparam name="T">The expected APIResult to get from this request.</typeparam>
        /// <param name="client">The client to use to process this request.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        protected async Task<T> ProcessRequestAsync<T>(HttpClient client, bool multi = false) where T : APIResult
        {
            var result = Activator.CreateInstance<T>();
            try
            {
                // Parse the json directly into the APIResult
                var json = await ProcessRequestJsonAsync(client);

                try
                {
                    // Success responses and AuthToken responses don't contain "asks"
                    if (json.StartsWithICIW("{\"success\":") || typeof(T) == typeof(AuthToken))
                    {
                        result = JsonConvert.DeserializeObject<T>(json);
                    }
                    else
                    {
                        result = JsonConvert.DeserializeObject<Dictionary<string, T>>(json)[Ask.ToString().ToLower()];
                    }
                }
                catch(JsonSerializationException initialException)
                {
                    // Seemingly random, we get array results from the json even when we hit a single endpoint... so let's attempt to parse it that way
                    try
                    {
                        result = JsonConvert.DeserializeObject<Dictionary<string, T[]>>(json)[Ask.ToString().ToLower()].First();
                    }
                    catch (JsonSerializationException)
                    {
                        // Throw the initial exception if the multi-params didn't work
                        throw initialException;
                    }
                }

                if (!result.IsSuccess)
                {
                    throw APIException.FromMessage(result.ExceptionMessage);
                }
            }
            catch (Exception ex)
            {
                // If anything happens, flag unsuccessful and log error to the APIResult
                result.IsSuccess = false;
                result.ExceptionMessage = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// Attempts to process the request.
        /// </summary>
        /// <typeparam name="T">The expected APIResult to get from this request.</typeparam>
        /// <param name="client">The client to use to process this request.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        protected T[] ProcessMultiRequest<T>(HttpClient client) where T : APIResult
        {
            var requestTask = ProcessMultiRequestAsync<T>(client);
            requestTask.Wait();
            return requestTask.Result;
        }

        /// <summary>
        /// Attempts to process the request with the expectation of multiple results.
        /// </summary>
        /// <typeparam name="T">The expected APIResult to get from this request.</typeparam>
        /// <param name="client">The client to use to process this request.</param>
        /// <returns>True if the request was successful, otherwise false.</returns>
        protected async Task<T[]> ProcessMultiRequestAsync<T>(HttpClient client) where T : APIResult
        {
            T[] result;
            try
            {
                // Parse the json directly into the APIResult
                var json = await ProcessRequestJsonAsync(client);
                result = JsonConvert.DeserializeObject<Dictionary<string, T[]>>(json)[Ask.ToString().ToLower()];
            }
            catch (Exception ex)
            {
                // If anything happens, flag unsuccessful and log error to the APIResult
                var exResult = Activator.CreateInstance<T>();
                exResult.IsSuccess = false;
                exResult.ExceptionMessage = ex.ToString();
                if(ex is APIException apiEx)
                {
                    exResult.ExceptionCode = apiEx.Code;
                }
                result = new[] { exResult };
            }
            return result;
        }

        /// <summary>
        /// Process the request and return the json response.
        /// </summary>
        /// <param name="client">The HttpClient to process.</param>
        /// <returns>The json string from the client./returns>
        private async Task<string> ProcessRequestJsonAsync(HttpClient client)
        {
            // We need a token for every request except the one where we request a token (authorize)
            if (RequireAuthToken && client.DefaultRequestHeaders.Authorization == null)
            {
                throw new Exception("Request can't be made without first defining the authorization token.");
            }

            // Generate the path and parameters
            var requestPath = GetRequestPath();
            var requestParameters = GetParameters();

            // Get the server response
            var response = await client.PostAsync(requestPath, requestParameters);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                // Replace PRIVATE_FIELD results with null values
                return json?.Replace("\"PRIVATE_FIELD\"", "null");
            }
            else
            {
                throw new Exception($"Unsuccessful response code from server: {response.StatusCode.ToString()} ({(int)response.StatusCode})");
            }
        }
    }
}
