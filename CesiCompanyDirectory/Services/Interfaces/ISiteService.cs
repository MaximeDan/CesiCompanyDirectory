using CesiCompanyDirectory.Models;

namespace CesiCompanyDirectory.Services.Interfaces;

public interface ISiteService
{
    /// <summary>
    /// Retrieves a list of all sites.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of sites.</returns>
    public Task<List<Site>> GetSitesAsync();

    /// <summary>
    /// Retrieves the site with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the site to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the site, or null if not found.</returns>
    Task<Site> GetSiteByIdAsync(int id);

    /// <summary>
    /// Creates a new site.
    /// </summary>
    /// <param name="site">The site to create.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task CreateSiteAsync(Site site);

    /// <summary>
    /// Updates an existing site.
    /// </summary>
    /// <param name="site">The site to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateSiteAsync(Site site);

    /// <summary>
    /// Deletes the site with the specified ID if it has no employees linked to it.
    /// </summary>
    /// <param name="id">The ID of the site to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the site was deleted.</returns>
    Task<bool> DeleteSiteAsync(int id);

    /// <summary>
    /// Checks whether the site with the specified ID has any employees linked to it.
    /// </summary>
    /// <param name="siteId">The ID of the site to check.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the site is empty.</returns>
    public Task<bool> IsSiteEmptyAsync(int siteId);


}