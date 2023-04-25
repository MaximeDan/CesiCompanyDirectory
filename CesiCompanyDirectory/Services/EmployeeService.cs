using CesiCompanyDirectory.Data;
using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CesiCompanyDirectory.Services;

public class EmployeeService : IEmployeeService
{
    
    private readonly CesiCompanyDirectoryDbContext _context;

    public EmployeeService(CesiCompanyDirectoryDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees
            .Include(e => e.Service)
            .Include(e => e.Site)
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Service)
            .Include(e => e.Site)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    /// <inheritdoc />
    public async Task<Employee[]> SearchByNameAsync(string searchTerm)
    {
        return await _context.Employees
            .Where(e => e.FirstName.Contains(searchTerm) || e.LastName.Contains(searchTerm))
            .ToArrayAsync();
    }

    /// <inheritdoc />
    public async Task<Employee[]> SearchBySiteAsync(string site)
    {
        return await _context.Employees
            .Where(e => e.Site.Name == site)
            .ToArrayAsync();
    }

    /// <inheritdoc />
    public async Task<Employee[]> SearchByServiceAsync(string service)
    {
        return await _context.Employees
            .Where(e => e.Service.Name == service)
            .ToArrayAsync();
    }


    /// <inheritdoc />
    public async Task AddEmployeeAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}