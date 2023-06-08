
using RabbitMQService;
using BlobStorageService;
using RabbitMQService.Interfaces;
using NotificationServices.Services;

namespace CurriculumService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
            builder.Services.AddSingleton<IRabbitMQConnection, RabbitMQDefaultConnection>();

            builder.Services.AddSingleton<IBlobStorageService, BlobStorageService.BlobStorageService>();
            builder.Services.AddSingleton<IRabbitMQService, RabbitMQService.RabbitMQService>();
            builder.Services.AddSingleton<IMessageProcessor, EmailSenderService>();
            builder.Services.AddHostedService<RabbitMQListenerService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}