using System;
using System.Collections.Generic;
namespace ServiceManager.Models
{
    public class ServiceContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<MicroService> MicroServices { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public ServiceContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "microservices.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class MicroService
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }

        public Status currentStatus
        {
            get
            {
                return StatusLog.LastOrDefault();
            }
        }
        [JsonIgnore]
        public List<Status> StatusLog { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public DateTime DateTime { get;}
        public StatusType ServiceStatus { get; set; }    
    }

    public enum StatusType
    {
        Online,
        NotFound,
        Error
    }
}