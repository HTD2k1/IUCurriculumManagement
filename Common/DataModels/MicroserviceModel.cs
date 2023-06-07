using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Common.MicroserviceModels
{
    public class MicroService
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public Status CurrentStatus
        {
            get
            {
                return StatusLog.LastOrDefault();
            }
            set { StatusLog.Add(value); }
        }
        [JsonIgnore]
        public List<Status> StatusLog { get; private set; } = new List<Status>();
    }

    public class Status
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; init; }
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