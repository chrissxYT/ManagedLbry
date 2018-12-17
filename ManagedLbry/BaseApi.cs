using System;
using System.Collections.Generic;
using Windows.Data.Json;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ManagedLbry
{
    public class BaseApi
    {
        static uint request_id;

        /// <summary>
        /// Sends a POST request to the given URL with the given method,
        /// params and authorization.
        /// </summary>
        /// <param name="url">the url to post to</param>
        /// <param name="method">the method to call from the api</param>
        /// <param name="parameters">params to put into the request</param>
        /// <param name="username">the username to auth with</param>
        /// <param name="password">the password corresponding to the username</param>
        /// <returns>a json reader to read the response</returns>
        public static async Task<JsonObject> MakeRequest(string url, string method,
            Dictionary<string, string> parameters = null,
            string username = "", string password = "")
        {
            bool has_params = parameters != null && parameters.Count > 0;

            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("user-agent", "LBRY C# API");
            http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Authorization", username + ":" + password);

            string body = "{\"jsonrpc\": \"2.0\", \"id\": \"" +
                  ++request_id + "\", \"method\": \"" + method +
                  (has_params ? "\", \"params\": {" : "\"}");

            if (has_params)
            {
                uint count = 1;
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    body += "\"" + param.Key + "\": \"" + param.Value + "\"" +
                        (count++ < parameters.Count ? ", " : "}");
                }
                body += "}";
            }

            string rr = await(await
                http.PostAsync(url,
                new StringContent(body, Encoding.UTF8,
                "application/json-rpc")))
                .Content.ReadAsStringAsync();

            JsonObject resp = JsonValue.Parse(rr).GetObject();

            if (rr.Contains("\"result\""))
                return resp;
            else
                throw new LBRYException("POST Request made to LBRY API received LBRY Error", resp);
        }
    }
}
