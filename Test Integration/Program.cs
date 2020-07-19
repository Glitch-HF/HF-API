using HF_API;
using HF_API.Results;
using Newtonsoft.Json;
using System;
using System.IO;

namespace HF_API_AutoGen
{
    class Program
    {
        const string testPath = @"C:\Test\HFAPI\";

        const string clientIdFile = testPath + "clientid.txt";
        const string secretKeyFile = testPath + "secretkey.txt";
        const string codeFile = testPath + "code.txt";
        const string tokenFile = testPath + "token.txt";

        static void Main(string[] args)
        {
            #region Setup and Authentication

            var clientId = File.ReadAllText(clientIdFile);
            var secretKey = File.ReadAllText(secretKeyFile);
            var code = File.Exists(codeFile) ? File.ReadAllText(codeFile) : null;
            var authToken = File.Exists(tokenFile) ? JsonConvert.DeserializeObject<AuthToken>(File.ReadAllText(tokenFile)) : null;

            var api = new HFAPI(clientId, secretKey, authToken);
            if (authToken == null)
            {
                if (api.TryGetAuthToken(code, out authToken))
                {
                    File.WriteAllText(tokenFile, JsonConvert.SerializeObject(authToken));
                    api.SetAuthToken(authToken);
                }
                else
                {
                    Console.WriteLine("Failed to acquire authentication token from code in file: " + codeFile);
                    Console.WriteLine(authToken.Message);
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }

            #endregion

            //--------------------- Reads -------------------------

            ProfileResult profile = api.ProfileRead();

            AdvancedProfileResult advancedProfile = api.AdvancedProfileRead();

            ForumResult forum = api.ForumGet(2);

            ThreadResult thread = api.ThreadGet(6095994);

            ThreadResult[] threadSearch = api.ThreadSearchByUserId(authToken.UserId, 1, 10);

            //--------------------- Writes -------------------------

            // ThreadResult createThread = api.ThreadCreate(375, "HFAPI.ThreadCreate Test", "Testing thread creation with my C# wrapper for the HF API.");
        }
    }
}
