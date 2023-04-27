using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class EmployeeDetails : PageModel
{
    private readonly IEmployeeService _employeeService;
    private readonly ISiteService _siteService;
    private readonly IServiceService _serviceService;
    
    
    public Employee Employee;
    public Site? Site;
    public Service? Service;
    public ICollection<Site> AllSites;
    public ICollection<Service> AllServices;

    
    public EmployeeDetails(IServiceService serviceService, ISiteService siteService, IEmployeeService employeeService)
    {
        _serviceService = serviceService;
        _siteService = siteService;
        _employeeService = employeeService;
    }

    public async Task OnGet(int employeeId)
    {
        if (employeeId != null)
        {
            Employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
            if (Employee.Site is not null)
            {
                Site = await _siteService.GetSiteByIdAsync(Employee.Site.Id);
            }
            else
            {
                Site = new Site();
            }
            
            if (Employee.Service is not null)
            {
                Service = await _serviceService.GetServiceByIdAsync(Employee.Service.Id);
            }
            else
            {
                Service = new Service();
            }
        }
    
        AllSites = await _siteService.GetSitesAsync();
        AllServices = await _serviceService.GetServicesAsync();
    }
    
    public async Task<IActionResult> OnPostUpdateEmployee(int employeeId, [FromForm] Employee employee)
    {
        var employeeInput = new Employee
        {
            Id = employeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.PhoneNumber,
            MobileNumber = employee.MobileNumber,
            Email = employee.Email,
        };

        if (employee.ServiceId != null)
        {
            employeeInput.ServiceId = employee.ServiceId;
        }
    
        if (employee.SiteId != null)
        {
            employeeInput.SiteId = employee.SiteId;
        }
        if (User.IsInRole("Admin"))
        {
            Employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
            if (Employee != null)
            {
                Employee.FirstName = employeeInput.FirstName;
                Employee.LastName = employeeInput.LastName;
                Employee.PhoneNumber = employeeInput.PhoneNumber;
                Employee.MobileNumber = employeeInput.MobileNumber;
                Employee.Email = employeeInput.Email;
                Employee.ServiceId = employeeInput.ServiceId;
                Employee.SiteId = employeeInput.SiteId;
                Employee.Picture = employeeInput.Picture;
                await _employeeService.UpdateEmployeeAsync(Employee);
            }
        }
        
        return RedirectToPage("./EmployeeDetails", new {employeeId = Employee.Id });
    }
}