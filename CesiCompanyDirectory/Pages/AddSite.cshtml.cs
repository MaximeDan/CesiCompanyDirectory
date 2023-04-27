using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class AddSite : PageModel
{
    private readonly ISiteService _siteService;

    public AddSite(ISiteService siteService)
    {
        _siteService = siteService;
    }

    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAddSite([FromForm] Site site)
    {
        var siteToAdd = new Site
        {
            Name = site.Name,
            City = site.City
        };

        await _siteService.CreateSiteAsync(siteToAdd);
        
        return RedirectToPage("/Sites");
    }
}