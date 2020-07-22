using HF_API;
using HF_API.Results;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

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
                    Console.WriteLine(authToken.ExceptionMessage);
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }

            #endregion

            //--------------------- Reads -------------------------

            // Profile
            ProfileResult profile = api.ProfileRead();
            AdvancedProfileResult AdvancedProfileRead = api.AdvancedProfileRead();

            // Forums
            ForumResult ForumGet = api.ForumGet(2);

            // Threads
            ThreadResult ThreadGet = api.ThreadGet(6083735);
                // Automatically loads nested result types
                UserResult firstPostUser = ThreadGet.FirstPost.User;
            ThreadResult[] ThreadSearchByUserId = api.ThreadSearchByUserId(authToken.UserId, 55709, 3);

            // Posts
            PostResult PostGet = api.PostGet(59991944);
            PostResult[] PostSearchByThreadId = api.PostSearchByThreadId(6083735, 1, 2);
            PostResult[] PostSearchByUserId = api.PostSearchByUserId(55709, 1, 4);

            // Byte Transactions
            ByteTransactionResult[] ByteTransactionSearchByUserId = api.ByteTransactionSearchByUserId(55709, 1, 2);
            ByteTransactionResult[] ByteTransactionSearchByFromUserId = api.ByteTransactionSearchByFromUserId(55709, 1, 3);
            ByteTransactionResult[] ByteTransactionSearchByToUserId = api.ByteTransactionSearchByToUserId(55709, 1, 4);
            ByteTransactionResult ByteTransactionGet = api.ByteTransactionGet(ByteTransactionSearchByUserId.First().Id);

            // Contracts
            ContractResult[] ContractSearchByUserId = api.ContractSearchByUserId(55709, 1, 1);
            ContractResult ContractGet = api.ContractGet(ContractSearchByUserId.First().Id);

            //--------------------- Writes -------------------------

            // ThreadResult createThread = api.ThreadCreate(375, "HFAPI.ThreadCreate Test", "Testing thread creation with my C# wrapper for the HF API.");
        }
    }
}
