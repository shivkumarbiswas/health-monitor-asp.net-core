using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthMonitor.Model;

namespace HealthMonitor.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HealthController : Controller
    {
        private readonly IHealthRepository _healthRepository;

        public HealthController(IHealthRepository healthRepository)
        {
            _healthRepository = healthRepository;
        }
        
        [HttpGet]
        [Route("service")]
        public async Task<IEnumerable<Service>> GetServices()
        {
            return await _healthRepository.GetServices();
        }

        [HttpPost]
        [Route("service")]
        public void AddService([FromBody] Service item)
        {
            _healthRepository.AddService(new Service
            {
                ServiceId = item.ServiceId,
                ServiceName = item.ServiceName,
                Owners = item.Owners,
                DownTime = item.DownTime
            });
        }

        [HttpGet]
        [Route("serviceStatus")]
        public async Task<IEnumerable<ServiceStatus>> GetServiceStatuses()
        {
            return await _healthRepository.GetServiceStatuses();
        }

        [HttpPost]
        [Route("serviceStatus")]
        public void AddServiceStatus([FromBody] ServiceStatus item)
        {
            _healthRepository.AddServiceStatus(new ServiceStatus
            {
                ServiceId = item.ServiceId,
                DateTime = item.DateTime,
                ErrorLevel = item.ErrorLevel,
                DetailInfo = item.DetailInfo
            });
        }
    }
}
    