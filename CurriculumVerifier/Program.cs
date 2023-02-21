using MySqlConnector;
using Microsoft.Extensions.Configuration;
using CurriculumService.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CurriculumService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
     
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
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