using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace ManagedLbry
{
    public class LbrydAPI : BaseApi
    {
        const string lbryd_url = "http://localhost:5279";

        public static Task<JsonObject> Call(string method,
            Dictionary<string, string> parameters = null)
        {
            return MakeRequest(lbryd_url, method, parameters);
        }
    }
}
