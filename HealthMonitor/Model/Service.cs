using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.Model
{
    public class Service
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string ServiceId { get; set; }

        public string ServiceName { get; set; }

        public List<string> Owners { get; set; }

        public double DownTime { get; set; }
    }
}
