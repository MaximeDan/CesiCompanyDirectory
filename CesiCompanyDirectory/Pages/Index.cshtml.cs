using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IEmployeeService _employeeService;

    public IList<Employee> AllEmployees { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

    public async Task OnGet()
    {
        AllEmployees = await _employeeService.GetAllEmployeesAsync();
    }
}