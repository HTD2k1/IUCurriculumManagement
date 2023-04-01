using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace RabbitMQClient.Event
{
    public record CurriculumEvent: Event
    {
        public CurriculumEventType EventType;
        public string Payload { get; init; }

        public CurriculumEvent(CurriculumEventType type, string payLoad)
        {
            EventType = type;
            Payload= payLoad;
        }
        
        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetQueueName() => $"curriculum-{EventType}";
    }

    public enum CurriculumEventType
    {
        accepted,
        created,
        declined,
        processed,
        error
    }
}
