using DotNetAIVoiceTranscription.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAIVoiceTranscription.API.Controller
{
    [ApiController]
    [Route("ai")]
    public class TranscriptionController : ControllerBase
    {
        private readonly TranscriptionService _transcriptionService;

        public TranscriptionController(TranscriptionService transcriptionService)
        {
            _transcriptionService=transcriptionService;
        }

        [HttpPost("transcribe")]
        public async Task<IActionResult> TranscribeAudio([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded or file is empty.");
            }

            try
            {
                var result = await _transcriptionService.TranscribeAudioAsync(file);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }
    }

}