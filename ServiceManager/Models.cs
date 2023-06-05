using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace ServiceManager
{
    public class ServiceContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public string DbPath { get; }
        public DbSet<MicroService> MicroServices { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public ServiceContext(IConfiguration configuration)
        {
              _configuration= configuration;    
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(_configuration.GetConnectionString("MicroservicesDatabase"));
    }

    public class MicroService
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }

        public Status currentStatus
        {
            get
            {
                return StatusLog.LastOrDefault();
            }
            set { StatusLog.Add(value); }
        }
        [JsonIgnore]
        public List<Status> StatusLog { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public DateTime DateTime { get; }
        public StatusType ServiceStatus { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusType
    {
        Online,
        NotFound,
        Error
    }
}