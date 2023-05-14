﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService
{
    public class RabbitMQSettings
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
        public string ServiceName { get; set; }
        public List<string> PublishQueues { get; set; }  
        public List<string> SubscribeQueues { get; set; }
    }
}
