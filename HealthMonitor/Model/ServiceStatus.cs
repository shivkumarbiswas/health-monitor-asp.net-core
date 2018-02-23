using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.Model
{
    public class ServiceStatus
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string ServiceId { get; set; }

        public DateTime DateTime { get; set; }

        public ErrorLevel ErrorLevel { get; set; }

        public string DetailInfo { get; set; }
    }
}
