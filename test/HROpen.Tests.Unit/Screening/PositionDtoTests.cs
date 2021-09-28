using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace HROpen.Screening
{
    public class PositionDtoTests
    {
        private static readonly JsonSerializer JsonSerializer = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        [Fact]
        public async Task SerializesToAndFromJson()
        {
            // Arrange
            var sample = await ReadSampleAsync("Screening\\json\\samples\\Position.json");

            // Act
            var dto = JsonConvert.DeserializeObject<PositionDto>(sample);

            // Assert
            VerifyDeserializedObjectMatchesJson(dto, sample);
        }

        private static async Task<string> ReadSampleAsync(string sampleFilePath)
        {
            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var pathToHROpenRepositories = configuration["PathToHROpenRepositories"];
            var pathToFile = Path.Combine(pathToHROpenRepositories, sampleFilePath);
            var sample = await File.ReadAllTextAsync(pathToFile);
            return sample;
        }

        private static void VerifyDeserializedObjectMatchesJson(object o, string json)
        {
            var t1 = JObject.FromObject(o!, JsonSerializer);
            var t2 = JObject.Parse(json);
            JToken.DeepEquals(t1, t2).Should().BeTrue("{0} didn't match {1}", t1, json);
        }
    }
}