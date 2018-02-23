using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.Model
{
    public interface IHealthRepository
    {
        Task AddService(Service item);

        Task<IEnumerable<Service>> GetServices();

        Task AddServiceStatus(ServiceStatus item);

        Task<IEnumerable<ServiceStatus>> GetServiceStatuses();
    }
}
