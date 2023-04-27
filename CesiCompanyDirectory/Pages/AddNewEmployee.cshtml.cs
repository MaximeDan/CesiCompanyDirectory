using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class AddNewEmployee : PageModel
{
    
    private readonly IEmployeeService _employeeService;
    private readonly ISiteService _siteService;
    private readonly IServiceService _serviceService;

    public ICollection<Site> AllSites;
    public ICollection<Service> AllServices;

    public AddNewEmployee(IEmployeeService employeeService, ISiteService siteService, IServiceService serviceService)
    {
        _employeeService = employeeService;
        _siteService = siteService;
        _serviceService = serviceService;
        AllServices = _serviceService.GetServicesAsync().Result;
        AllSites = _siteService.GetSitesAsync().Result;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAddEmployee([FromForm] Employee employee)
    {
        var employeeToAdd = new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.PhoneNumber,
            MobileNumber = employee.MobileNumber,
            Email = employee.Email,
            SiteId = employee.SiteId,
            ServiceId = employee.ServiceId
        };

        await _employeeService.AddEmployeeAsync(employeeToAdd);
        
        var addedEmployee = await _employeeService.GetEmployeeByIdAsync(employeeToAdd.Id);

        return RedirectToPage("./EmployeeDetails", new { employeeId = addedEmployee.Id });
    }
}