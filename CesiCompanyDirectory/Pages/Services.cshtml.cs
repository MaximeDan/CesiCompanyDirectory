using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class Services : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IServiceService _serviceService;

    public IList<Service> AllService { get; set; }

    public Services(ILogger<IndexModel> logger, IServiceService serviceService)
    {
        _logger = logger;
        _serviceService = serviceService;
    }

    public async Task OnGet()
    {
        AllService = await _serviceService.GetServicesAsync();
    }
}