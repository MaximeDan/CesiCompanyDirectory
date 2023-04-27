using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class AddService : PageModel
{
    
    private readonly IServiceService _serviceService;

    public AddService(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAddService([FromForm] Service service)
    {
        var serviceToAdd = new Service
        {
            Name = service.Name
        };

        await _serviceService.CreateServiceAsync(serviceToAdd);

        return RedirectToPage("/Services");
    }
}