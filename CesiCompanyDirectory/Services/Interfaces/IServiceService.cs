using CesiCompanyDirectory.Models;

namespace CesiCompanyDirectory.Services.Interfaces;

public interface IServiceService
{
    /// <summary>
    /// Retrieves a list of all services from the database.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of services.</returns>
    Task<List<Service>> GetServicesAsync();

    /// <summary>
    /// Retrieves a service from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the service to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the service.</returns>
    Task<Service> GetServiceByIdAsync(int id);
    
    /// <summary>
    /// Adds a new service to the database.
    /// </summary>
    /// <param name="service">The service to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task CreateServiceAsync(Service service);
    
    /// <summary>
    /// Updates an existing service in the database.
    /// </summary>
    /// <param name="service">The service to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateServiceAsync(Service service);
    
    /// <summary>
    /// Deletes a service from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the service to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> DeleteServiceAsync(int id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceId"></param>
    /// <returns></returns>
    Task<bool> IsServiceEmptyAsync(int serviceId);
}