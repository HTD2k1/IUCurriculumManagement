using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient.Event
{
    public record Event
    {   
        public Event() { 
        
        }
        public Guid Id { get; private init; } 
        public DateTime dateTime { get; private init; } 
    }
}
