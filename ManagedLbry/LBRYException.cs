using Newtonsoft.Json.Linq;
using System;

namespace ManagedLbry
{
    class LBRYException : Exception
    {
        public LBRYException(string what, string code) : base(what)
        {
            LbryCode = code;
            LbryResponse = JObject.Parse(what);
        }

        public LBRYException(string what_arg, JObject error)
            : base(what_arg)
        {
            LbryCode = error.SelectToken("error", true).ToString();
            LbryResponse = error;
        }
        
        public string LbryCode { get; private set; } //im to lazy to parse this to an int
        public JObject LbryResponse { get; private set; }
    }
}
