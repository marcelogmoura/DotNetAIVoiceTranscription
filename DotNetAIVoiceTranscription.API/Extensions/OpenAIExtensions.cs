using OpenAI;

namespace DotNetAIVoiceTranscription.API.Extensions
{
    public static class OpenAIExtensions
    {
        public static WebApplicationBuilder AddOpenAI(this WebApplicationBuilder builder)
        {
            var apiKey = Environment.GetEnvironmentVariable("Marcelo_api_key");

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("OpenAI API key is not set.");
            }

            var openAiClient = new OpenAIClient(apiKey);


            builder.Services.AddSingleton(openAiClient);

            return builder;
        }

    }
}
