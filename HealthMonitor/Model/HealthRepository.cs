using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.Model
{
    public class HealthRepository : IHealthRepository
    {
        private readonly HealthContext _context = null;

        public HealthRepository(IOptions<Settings> settings)
        {
            _context = new HealthContext(settings);
        }

        public async Task AddService(Service item)
        {
            try
            {
                await _context.Service.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            try
            {
                var documents = await _context.Service.Find(_ => true).ToListAsync();
                return documents;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddServiceStatus(ServiceStatus item)
        {
            try
            {
                await _context.ServiceStatus.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<ServiceStatus>> GetServiceStatuses()
        {
            try
            {
                var documents = await _context.ServiceStatus.Find(_ => true).ToListAsync();
                return documents;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
