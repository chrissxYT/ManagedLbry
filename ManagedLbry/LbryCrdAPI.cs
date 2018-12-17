using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ManagedLbry
{
    public class LbryCrdAPI : BaseApi
    {
        const string lbrycrd_url = "http://localhost:9245";
        string username, password;

        public LbryCrdAPI(string username = "", string password = "")
        {
            this.username = username;
            this.password = password;
        }

        public Task<JsonObject> Call(string method,
            Dictionary<string, string> parameters = null)
        {
            return MakeRequest(lbrycrd_url, method, parameters,
                username, password);
        }
    }
}
