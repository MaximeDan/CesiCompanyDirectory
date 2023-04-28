using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IEmployeeService _employeeService;

    // Add these properties
    [BindProperty(SupportsGet = true)]
    public string NameSearchTerm { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string SiteSearchTerm { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public string ServiceSearchTerm { get; set; }
    public IList<Employee> Employees { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
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
    }
}