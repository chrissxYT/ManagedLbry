using System;
using Windows.Data.Json;

namespace ManagedLbry
{
    class LBRYException : Exception
    {
        public LBRYException(string what, int code) : base(what)
        {
            LbryCode = code;
            LbryResponse = JsonValue.Parse(what).GetObject();
        }

        public LBRYException(string what_arg, JsonObject error)
            : base(what_arg)
        {
            LbryCode = (int)error.GetNamedObject("error")
                .GetNamedNumber("code");
            LbryResponse = error;
        }
        
        public int LbryCode { get; private set; }
        public JsonObject LbryResponse { get; private set; }
    }
}
