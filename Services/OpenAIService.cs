// Services/OpenAIService.cs
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HairDesignStudio.Services
{
    public class OpenAIService : IHairStyleService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly ILogger<OpenAIService> _logger;

        public OpenAIService(IConfiguration configuration, ILogger<OpenAIService> logger)
        {
            _client = new HttpClient();
            _apiKey = configuration["OpenAI:ApiKey"] ?? 
                throw new ArgumentNullException("OpenAI:ApiKey configuration is missing");
            _logger = logger;

            _client.BaseAddress = new Uri("https://api.openai.com/v1/");
            _client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<List<string>> GenerateHairStyles(byte[] imageBytes, string userPrompt = "")
        {
            try
            {
                string finalPrompt = BuildPrompt(userPrompt);

                var request = new
                {
                    model = "dall-e-3",
                    prompt = finalPrompt,
                    n = 1,
                    size = "1024x1024",
                    quality = "hd"
                };

                _logger.LogInformation($"Using prompt: {finalPrompt}");

                var content = new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8,
                    "application/json");

                var response = await _client.PostAsync("images/generations", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"OpenAI API error: {error}");
                    throw new Exception($"OpenAI API call failed: {response.StatusCode}, {error}");
                }

                var result = await response.Content.ReadFromJsonAsync<OpenAIImageResponse>();
                
                return result?.Data?.Select(x => x.Url).ToList() ?? new List<string>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GenerateHairStyles: {ex}");
                throw;
            }
        }

        private string BuildPrompt(string userPrompt)
        {
            const string basePrompt = "Generate a professional portrait photo showing a hairstyle that is";
            
            if (string.IsNullOrWhiteSpace(userPrompt))
            {
                return $"{basePrompt} modern and attractive. The image should be high quality, realistic, and focus on the hair styling. The image must be a men. It has to be a helper image for an hairdesigner.";
            }

            return $"{basePrompt} {userPrompt.Trim()}. The image should be high quality, realistic, and focus on the hair styling. The image must be a men. It has to be a helper image for an hairdesigner.";
        }
    }

    public class OpenAIImageResponse
    {
        public List<OpenAIImage> Data { get; set; }
    }

    public class OpenAIImage
    {
        public string Url { get; set; }
    }
}