using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace HROpen.Screening
{
    public class SerializationTests
    {
        [Theory]
        [InlineData("Screening\\json\\samples\\Position.json", typeof(PositionDto))]
        [InlineData("Screening\\json\\samples\\StatusNotification.json", typeof(StatusNotificationDto))]
        [InlineData("Screening\\json\\samples\\ScreeningVendorMessage1.json", typeof(ScreeningVendorMessageDto))]
        [InlineData("Screening\\json\\samples\\ScreeningVendorMessage2.json", typeof(ScreeningVendorMessageDto))]
        public async Task SerializesToAndFromJson(string sampleFilePath, Type type)
        {
            // Arrange
            var sample = await Samples.ReadAsync(sampleFilePath);

            // Act
            var dto = JsonConvert.DeserializeObject(sample, type);

            // Assert
            dto.ShouldMatchJson(sample);
        }
    }
}