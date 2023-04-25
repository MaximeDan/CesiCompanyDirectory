using CesiCompanyDirectory.Models;

namespace CesiCompanyDirectory.Services.Interfaces;

public interface IEmployeeService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<List<Employee>> GetAllEmployeesAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Employee> GetEmployeeByIdAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="searchTerm"></param>
    /// <returns></returns>
    public Task<Employee[]> SearchByNameAsync(string searchTerm);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    public Task<Employee[]> SearchBySiteAsync(string site);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public Task<Employee[]> SearchByServiceAsync(string service);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public Task AddEmployeeAsync(Employee employee);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public Task UpdateEmployeeAsync(Employee employee);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public Task DeleteEmployeeAsync(int id);
}