using CesiCompanyDirectory.Data;
using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CesiCompanyDirectory.Services;

public class ServiceService : IServiceService
{
    
    private readonly CesiCompanyDirectoryDbContext _dbContext;

    public ServiceService(CesiCompanyDirectoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<Service>> GetServicesAsync()
    {
        return await _dbContext.Services.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Service> GetServiceByIdAsync(int id)
    {
        return await _dbContext.Services.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task CreateServiceAsync(Service service)
    {
        _dbContext.Services.Add(service);
        await _dbContext.SaveChangesAsync();    
    }

    /// <inheritdoc />
    public async Task UpdateServiceAsync(Service service)
    {
        _dbContext.Entry(service).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<bool> DeleteServiceAsync(int id)
    {
        var service = await _dbContext.Services.FindAsync(id);

        if (service == null)
        {
            return false;
        }

        if (!await IsServiceEmptyAsync(id))
        {
            return false;
        }

        _dbContext.Services.Remove(service);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> IsServiceEmptyAsync(int serviceId)
    {
        return !await _dbContext.Employees.AnyAsync(e => e.ServiceId == serviceId);
    }
}