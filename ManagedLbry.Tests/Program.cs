using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagedLbry.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Test1();
            while (!t.IsCompleted)
                ;
            Console.WriteLine("Test1 is done.");
            Console.Read();
        }

        static async Task Test1()
        {
            try
            {
                JObject j = await LbrydAPI.Call("claim_list",
                new Dictionary<string, string> { { "name", "bellflower" } });

                Console.WriteLine(j.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
