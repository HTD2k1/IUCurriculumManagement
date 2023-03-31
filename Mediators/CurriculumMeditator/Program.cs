using Microsoft.AspNetCore.Mvc;

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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            app.MapPost("/create-currriculum",  async (HttpContext httpContext) =>
            {
                var formFile = httpContext.Request.Form.Files.FirstOrDefault();

                if (formFile == null || formFile.Length == 0)
                {
                    return Results.BadRequest();
                }

                await BlobStorageService.UploadFiles(formFile);
                RabbitMQPublishClient.Publish($"{formFile.FileName}");
                return Results.Ok();
            })
            .WithName("CreateCurriculum");

            app.Run();
        }
    }
}