using MySqlConnector;
using Microsoft.Extensions.Configuration;
using CurriculumService.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using RabbitMQ.Client;
using RabbitMQService;
using BlobStorageService;
using RabbitMQService.Interfaces;
using CurriculumService.Services;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace CurriculumService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });;
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
            builder.Services.AddTransient<IRabbitMQConnection, RabbitMQDefaultConnection>();

            builder.Services.AddScoped<IBlobStorageService, BlobStorageService.BlobStorageService>();
            builder.Services.AddSingleton<IRabbitMQService, RabbitMQService.RabbitMQService>();
            builder.Services.AddSingleton<IMessageProcessor, SemesterCurriculumVerifierService>();
            builder.Services.AddHostedService<RabbitMQListenerService>();
            builder.Services.AddDbContext<IuCurriculumContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("IuCurriculum");
                if(connectionString != null)
                { 
                    options.UseMySQL(connectionString);
                }
            });
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