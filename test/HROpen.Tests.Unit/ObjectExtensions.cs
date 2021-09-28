using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace HROpen
{
    public static class ObjectExtensions
    {
        private static readonly JsonSerializer JsonSerializer = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static void ShouldMatchJson(this object o, string json)
        {
            var t1 = JObject.FromObject(o!, JsonSerializer);
            var t2 = JObject.Parse(json);
            JToken.DeepEquals(t1, t2).Should().BeTrue("{0} didn't match {1}", t1, json);
        }
    }
}