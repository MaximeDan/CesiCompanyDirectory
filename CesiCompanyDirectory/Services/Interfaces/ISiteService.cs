using CesiCompanyDirectory.Models;

namespace CesiCompanyDirectory.Services.Interfaces;

public interface ISiteService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<List<Site>> GetSitesAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Site> GetSiteByIdAsync(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    Task CreateSiteAsync(Site site);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="site"></param>
    /// <returns></returns>
    Task UpdateSiteAsync(Site site);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteSiteAsync(int id);
}