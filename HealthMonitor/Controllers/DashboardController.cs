using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitor.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HealthMonitor.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHealthRepository _healthRepository;

        public DashboardController(IHealthRepository healthRepository)
        {
            _healthRepository = healthRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> services = await _healthRepository.GetServices();

            IEnumerable<ServiceStatus> serviceStatuses = await _healthRepository.GetServiceStatuses();
            GetDataPoints(serviceStatuses.ToList(), services.Select(x=>x.ServiceId).ToList());


            return View(services);
        }

        private void GetDataPoints(List<ServiceStatus> serviceStatuses, List<string> services)
        {
            ViewBag.DataPoints = new Dictionary<ErrorLevel, string>();

            var serviceStatusGroups = serviceStatuses
                                        .GroupBy(s => new { s.ErrorLevel })
                                        .Select(g => new
                                        {
                                            g.Key.ErrorLevel,
                                            ServiceStatuses = g.OrderBy(x=>x.ServiceId).ToList()
                                        });

            foreach (var serviceStatusGroup in serviceStatusGroups)
            {
                
                var dataPoints = new List<DataPoint>();


                var servs = serviceStatusGroup.ServiceStatuses
                                .GroupBy(s => new { s.ServiceId })
                                .Select(g => new
                                {
                                    g.Key.ServiceId,
                                    Count = g.ToList().Count()
                                });

                foreach (var service in servs)
                {
                    var dataPoint = new DataPoint()
                    {
                        y = service.Count,
                        label = "MicroService " + service.ServiceId
                    };

                    dataPoints.Add(dataPoint);
                }

                ViewBag.DataPoints[serviceStatusGroup.ErrorLevel] = JsonConvert.SerializeObject(dataPoints);
            }
        }
    }

    public class DataPoint
    {
        public int y;
        public string label;
    }
}