using RabbitMQService.Interfaces;
using RabbitMQService;
using RabbitMQService.Event;
using ServiceManager.Models;

namespace ServiceManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddDbContext<ServiceContext>(ServiceLifetime.Singleton);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQ"));
            builder.Services.AddSingleton<IRabbitMQConnection, RabbitMQDefaultConnection>();

            builder.Services.AddSingleton<IRabbitMQService, RabbitMQService.RabbitMQService>();
            builder.Services.AddSingleton<IMessageProcessor, OnlineCheckingService>();
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

            app.MapGet("/status", (HttpContext httpContext, ServiceContext serviceContext) =>
            {

                return serviceContext.MicroServices.Select(x=>x).ToList();
            })
            .WithName("GetWeatherForecast");

            app.Run();
        }
    }
}