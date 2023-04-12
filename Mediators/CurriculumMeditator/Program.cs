using Microsoft.AspNetCore.Mvc;
using RabbitMQClient;
using RabbitMQClient.Event;
using BlobStorageService;
using RabbitMQ.Client;

namespace CurriculumMeditator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Logging.AddConsole();   

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IRabbitMQConnection >( _ =>
            {
                var configuration = builder.Configuration;
                var factory = new ConnectionFactory { HostName = builder.Configuration.GetValue<string>("RabbitMQConnection:HostName") };
                return new RabbitMQDefaultConnection(factory);
            });
            builder.Services.AddScoped<IBlobStorageService, BlobStorageService.BlobStorageService>();
            builder.Services.AddScoped<IRabbitMQClient,RabbitMQBaseClient>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization(); 

            app.MapPost("/create-currriculum", async (HttpContext httpContext, IRabbitMQClient rabbitMQClient, IBlobStorageService blobService) =>
            {
                try
                {
                    var formFile = httpContext.Request.Form.Files.FirstOrDefault();
                    if (formFile == null || formFile.Length == 0)
                    {
                        return Results.BadRequest();
                    }

                    await blobService.UploadFiles(formFile);

                    var newEvent = new CurriculumEvent(CurriculumEventType.created, formFile.FileName);
                    rabbitMQClient.Publish(newEvent);
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