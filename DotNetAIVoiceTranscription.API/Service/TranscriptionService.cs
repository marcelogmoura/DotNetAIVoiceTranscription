using OpenAI;
using OpenAI.Audio;

namespace DotNetAIVoiceTranscription.API.Service
{
    public class TranscriptionService
    {
        private readonly OpenAIClient openAIClient;
        private readonly string _model;

        public TranscriptionService(OpenAIClient openAIClient, IConfiguration configuration)
        {
            this.openAIClient=openAIClient;
            _model= configuration["OpenAi:AudioModel"] ?? "whisper-1";
        }

        public async Task<string> TranscribeAudioAsync(IFormFile file)
        {
            var temFilePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.mp3");
            try
            {
                var stream = new FileStream(temFilePath, FileMode.Create);
                await file.CopyToAsync(stream);
                stream.Close();

                var audioFile = new AudioTranscriptionOptions
                {
                    ResponseFormat = AudioTranscriptionFormat.Text,
                    Language = "pt",
                    Temperature = 0.0f
                };

                var audioClient = openAIClient.GetAudioClient(_model);

                var response = await audioClient.TranscribeAudioAsync(temFilePath, audioFile);

                return response.Value.Text ?? "No transcription generated";

            }
            catch (Exception ex)
            {
                throw new Exception("Error during transcription", ex);
            }
            finally
            {
                if (File.Exists(temFilePath))
                {
                    File.Delete(temFilePath);
                }
            }
        }
    }
}