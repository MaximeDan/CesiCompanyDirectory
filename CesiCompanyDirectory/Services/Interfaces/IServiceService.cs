using CesiCompanyDirectory.Models;

namespace CesiCompanyDirectory.Services.Interfaces;

public interface IServiceService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public  Task<List<Service>> GetServicesAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Service> GetServiceByIdAsync(int id);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    Task CreateServiceAsync(Service service);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    Task UpdateServiceAsync(Service service);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteServiceAsync(int id);
}