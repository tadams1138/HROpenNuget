using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HROpen
{
    public static class Samples
    {
        private static readonly IConfigurationRoot Configuration =
            new ConfigurationBuilder().AddEnvironmentVariables().Build();

        public static async Task<string> ReadAsync(string sampleFilePath)
        {
            var pathToHROpenRepositories = Configuration["PathToHROpenRepositories"];
            var pathToFile = Path.Combine(pathToHROpenRepositories, sampleFilePath);
            var text = await File.ReadAllTextAsync(pathToFile);
            return text;
        }
    }
}