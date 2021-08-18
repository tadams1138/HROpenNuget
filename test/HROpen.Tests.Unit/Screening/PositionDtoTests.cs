using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace HROpen.Screening
{
    public class PositionDtoTests
    {
        [Fact]
        public async Task SerializesToAndFromJson()
        {
            // Arrange
            var sample = await ReadSampleAsync("Screening\\json\\samples\\Position.json");

            // Act
            var dto = JsonConvert.DeserializeObject<PositionDto>(sample);
            var reserialized = JsonConvert.SerializeObject(dto);

            // Assert
            reserialized.Should().Be(sample);
        }

        private static async Task<string> ReadSampleAsync(string sampleFilePath)
        {
            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var pathToHROpenRepositories = configuration["PathToHROpenRepositories"];
            var pathToFile = Path.Combine(pathToHROpenRepositories, sampleFilePath);
            var sample = await File.ReadAllTextAsync(pathToFile);
            return sample;
        }
    }
}