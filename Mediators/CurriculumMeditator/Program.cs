using Microsoft.AspNetCore.Mvc;
using RabbitMQService;
using RabbitMQService.Event;
using BlobStorageService;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using RabbitMQService.Interfaces;

namespace CurriculumMeditator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
            builder.Services.AddSingleton<IRabbitMQConnection, RabbitMQDefaultConnection>();

            builder.Services.AddScoped<IBlobStorageService, BlobStorageService.BlobStorageService>();
            builder.Services.AddSingleton<IRabbitMQService,RabbitMQService.RabbitMQService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization(); 

            app.MapPost("/create-currriculum", async (HttpContext httpContext, IRabbitMQService rabbitMQService, IBlobStorageService blobService, ILogger<Program> logger) =>
            {
                try
                {
                    var formFile = httpContext.Request.Form.Files.FirstOrDefault();
                    if (formFile == null || formFile.Length == 0)
                    {
                        return Results.BadRequest();
                    }
                    await blobService.UploadFilesAsync(formFile);

                    var newEvent = new CurriculumEvent(CurriculumEventType.processed, formFile.FileName);
                    rabbitMQService.PublishEvent(newEvent);
                    logger.LogInformation($"New event {newEvent.Id} : {newEvent.EventType}");
                    return Results.Ok();
                }   
                catch(Exception ex)
                {   
                    return Results.BadRequest(ex.ToString());  
                }
            })
            .WithName("CreateCurriculum");

            app.Run();
        }
    }
}