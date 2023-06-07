using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Common.MicroserviceModels;
namespace ServiceManager
{
    public class ServiceContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _appEnv;
        public DbSet<MicroService> MicroServices { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public ServiceContext(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration= configuration;    
            _appEnv= env;
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {   
            var string1 = _configuration.GetConnectionString("MicroservicesDatabase");
            var string2 = _appEnv.ContentRootPath;
            var connectionString = string.Format(string1, string2);
            options.UseSqlite(connectionString);
        }
    }
}