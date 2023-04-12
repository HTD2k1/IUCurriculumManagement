using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace RabbitMQClient.Event
{
    public record CurriculumEvent: ICurriculumEvent
    {
        public CurriculumEventType EventType;
        public string Payload { get; set; }
        public Guid Id { get; private init; }
        public DateTime DateTime { get; private init; }

        public CurriculumEvent(CurriculumEventType type, string payLoad, string dateTime=null!)
        {
            Id = Guid.NewGuid();
            DateTime = (dateTime == null) ? DateTime.Now : DateTime.Parse(dateTime);
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
