using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class UpdateDeleteSite : PageModel
{
    private readonly ISiteService _siteService;

    public Site? Site;

    public UpdateDeleteSite(ISiteService siteService)
    {
        _siteService = siteService;
    }

    public async Task OnGet(int siteId)
    {
        Site = await _siteService.GetSiteByIdAsync(siteId);
    }
    
    /// <summary>
    /// Updates the site with the specified ID with the provided data.
    /// </summary>
    /// <param name="siteId">The ID of the site to update.</param>
    /// <param name="site">The updated data for the site.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<IActionResult> OnPostUpdateSite(int siteId, [FromForm] Site site)
    {
        var siteInput = new Site
        {
            Id = siteId,
            Name = site.Name,
            City = site.City
        };

        // Get the existing site data from the database
        Site = await _siteService.GetSiteByIdAsync(siteId);

        // Update the site if it exists
        if (Site != null)
        {
            Site.Name = siteInput.Name;
            Site.City = siteInput.City;
            await _siteService.UpdateSiteAsync(Site);
        }

        return RedirectToPage("./Sites");
    }

    /// <summary>
    /// Deletes the site with the specified ID if it is empty (i.e., has no employees linked to it).
    /// Otherwise, sets an error message in TempData and redirects to the Sites page.
    /// </summary>
    /// <param name="siteId">The ID of the site to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<IActionResult> OnPostDeleteSite(int siteId)
    {
        // Check if the site has any employees linked to it
        bool isSiteEmpty = await _siteService.IsSiteEmptyAsync(siteId);

        // If the site is not empty, set an error message and redirect to the Sites page
        if (!isSiteEmpty)
        {
            TempData["ErrorMessage"] = "Cannot delete site because it has employees linked to it.";
            return RedirectToPage("./Sites");
        }

        // Otherwise, delete the site
        await _siteService.DeleteSiteAsync(siteId);

        return RedirectToPage("./Sites");
    }

}