using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Data.Json;

namespace ManagedLbry.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            try
            {
                JsonObject j = await LbrydAPI.Call("claim_list",
                new Dictionary<string, string> {{"name","bellflower"}});

                Debug.WriteLine(j.Stringify());
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
