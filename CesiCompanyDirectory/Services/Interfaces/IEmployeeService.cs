using CesiCompanyDirectory.Models;

namespace CesiCompanyDirectory.Services.Interfaces;

public interface IEmployeeService
{
    /// <summary>
    /// Gets all employees from the database.
    /// </summary>
    /// <returns>An asynchronous operation that returns a list of all employees.</returns>
    public Task<List<Employee>> GetAllEmployeesAsync();

    /// <summary>
    /// Gets an employee from the database by their ID.
    /// </summary>
    /// <param name="id">The ID of the employee to get.</param>
    /// <returns>An asynchronous operation that returns the employee with the given ID, or null if not found.</returns>
    public Task<Employee> GetEmployeeByIdAsync(int id);

    /// <summary>
    /// Searches for employees in the database by name.
    /// </summary>
    /// <param name="searchTerm">The search term to match against the first or last name of employees.</param>
    /// <returns>An asynchronous operation that returns an array of employees that match the search term.</returns>
    public Task<Employee[]> SearchByNameAsync(string searchTerm);

    /// <summary>
    /// Searches for employees in the database by site.
    /// </summary>
    /// <param name="site">The name of the site to match against the site name of employees.</param>
    /// <returns>An asynchronous operation that returns an array of employees that match the site name.</returns>
    public Task<Employee[]> SearchBySiteAsync(string site);

    /// <summary>
    /// Searches for employees in the database by service.
    /// </summary>
    /// <param name="service">The name of the service to match against the service name of employees.</param>
    /// <returns>An asynchronous operation that returns an array of employees that match the service name.</returns>
    public Task<Employee[]> SearchByServiceAsync(string service);

    /// <summary>
    /// Adds a new employee to the database.
    /// </summary>
    /// <param name="employee">The employee object to add.</param>
    /// <returns>An asynchronous operation that returns the added employee object.</returns>
    public Task AddEmployeeAsync(Employee employee);

    /// <summary>
    /// Updates an existing employee in the database.
    /// </summary>
    /// <param name="employee">The employee object to update.</param>
    /// <returns>An asynchronous operation that returns the updated employee object.</returns>
    public Task UpdateEmployeeAsync(Employee employee);

    /// <summary>
    /// Deletes an employee from the database by their ID.
    /// </summary>
    /// <param name="id">The ID of the employee to delete.</param>
    /// <returns>An asynchronous operation.</returns>
    public Task DeleteEmployeeAsync(int id);
}