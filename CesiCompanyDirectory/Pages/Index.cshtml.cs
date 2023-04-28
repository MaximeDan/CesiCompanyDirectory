using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IEmployeeService _employeeService;
    private readonly IServiceService _serviceService;
    private readonly ISiteService _siteService;

    // Add these properties
    [BindProperty(SupportsGet = true)]
    public string NameSearchTerm { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string SiteSearchTerm { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string ServiceSearchTerm { get; set; }
    public IList<Employee> Employees { get; set; }
    
    public List<Site> Sites { get; set; }
    public List<Service> Services { get; set; }


    public IndexModel(ILogger<IndexModel> logger, IEmployeeService employeeService, ISiteService siteService, IServiceService serviceService)
    {
        _logger = logger;
        _employeeService = employeeService;
        _siteService = siteService;
        _serviceService = serviceService;
    }

    public async Task OnGet()
    {
        if (!string.IsNullOrEmpty(NameSearchTerm))
        {
            Employees = await _employeeService.SearchByNameAsync(NameSearchTerm);
        }
        else if (!string.IsNullOrEmpty(SiteSearchTerm))
        {
            Employees = await _employeeService.SearchBySiteAsync(SiteSearchTerm);
        }
        else if (!string.IsNullOrEmpty(ServiceSearchTerm))
        {
            Employees = await _employeeService.SearchByServiceAsync(ServiceSearchTerm);
        }
        else
        {
            Employees = await _employeeService.GetAllEmployeesAsync();
        }
        
        Sites = await _siteService.GetSitesAsync();
        Services = await _serviceService.GetServicesAsync();
    }
}