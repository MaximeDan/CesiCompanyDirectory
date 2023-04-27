using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class Sites : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ISiteService _siteService;

    public IList<Site> AllSite { get; set; }

    public Sites(ILogger<IndexModel> logger, ISiteService siteService)
    {
        _logger = logger;
        _siteService = siteService;
    }

    public async Task OnGet()
    {
        AllSite = await _siteService.GetSitesAsync();
    }
}