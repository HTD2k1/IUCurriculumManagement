using RabbitMQService.Interfaces;
using RabbitMQService;
using RabbitMQService.Event;
using Microsoft.AspNetCore.Mvc;
using Common.MicroserviceModels;
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
            app.MapGet("/get-services", (HttpContext httpContext, ServiceContext serviceContext) =>
            {

                return serviceContext.MicroServices.Select(x => x).ToList();
            })
            .WithName("GetMicroservicesStatus");

            app.MapPost("/add-service-status", (HttpContext httpContext, ServiceContext serviceContext, [FromBody] string content, ILogger<Program> logger ) =>
            {
                try
                {
                    var microservice = JsonConvert.DeserializeObject<MicroService>(content);
                    var existingMicroService = serviceContext.MicroServices.FirstOrDefault(x => x.Id == microservice.Id);
                    if (existingMicroService == null)
                    {
                        serviceContext.MicroServices.Add(microservice);
                    }
                    else
                    {
                        existingMicroService.CurrentStatus = microservice.CurrentStatus;
                    }
                    serviceContext.SaveChanges();
                    return Results.Created("/add-service-status", microservice);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.ToString());
                    return Results.Problem(ex.ToString());  
                }
            })
            .WithName("AddMicroservicesStatus");
            app.Run();
        }
    }
}