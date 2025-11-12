using DotNetAIVoiceTranscription.API.Extensions;
using DotNetAIVoiceTranscription.API.Service;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddOpenAI();

builder.Services.AddSingleton<TranscriptionService>();

builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }
));


builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, _) =>
    {
        document.Info = new()
        {
            Title = ".NET AI Marcelo API",
            Version = "v1",
            Description = """  
               This API provides AI-based features such as chat, image generation,  
               recipe creation and audio transcription.  
               """,
            Contact = new()
            {
                Name = "Marcelo Moura",
                Email = "mgmoura@gmail.com",
                Url = new Uri("https://www.allriders.com.br")
            },
            License = new()
            {
                Name = "Apache 2 License",
                Url = new Uri("https://www.allriders.com.br")
            },
            TermsOfService = new Uri("https://www.allriders.com.br")
        };
        return Task.CompletedTask;
    });
});


var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = ".NET AI Marcelo API";
        options.Theme = ScalarTheme.Mars;
        options.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

