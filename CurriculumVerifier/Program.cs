using MySqlConnector;
using Microsoft.Extensions.Configuration;
using CurriculumVerifier.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CurriculumVerifier
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