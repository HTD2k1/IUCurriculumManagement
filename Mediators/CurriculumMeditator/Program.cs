using Microsoft.AspNetCore.Mvc;
using RabbitMQClient;
using RabbitMQClient.Event;
using BlogStorageService;
namespace CurriculumMeditator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IRabbitMQConnection>()
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization(); 

            app.MapPost("/create-currriculum", async (HttpContext httpContext) =>
            {
                var formFile = httpContext.Request.Form.Files.FirstOrDefault();
                if (formFile == null || formFile.Length == 0)
                {
                    return Results.BadRequest();
                }

                await BlobStorageService.UploadFiles(formFile);

                var newEvent = new CurriculumEvent(CurriculumEventType.created, formFile.FileName); 
                RabbitMQBaseClient.Publish(newEvent);
                return Results.Ok();
            })
            .WithName("CreateCurriculum");

            app.Run();
        }
    }
}