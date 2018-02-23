using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.Model
{
    public class HealthContext
    {
        private readonly IMongoDatabase _database = null;

        public HealthContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Service> Service
        {
            get
            {
                return _database.GetCollection<Service>("Service");
            }
        }

        public IMongoCollection<ServiceStatus> ServiceStatus
        {
            get
            {
                return _database.GetCollection<ServiceStatus>("ServiceStatus");
            }
        }
    }
}
