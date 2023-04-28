using CesiCompanyDirectory.Data;
using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CesiCompanyDirectory.Services;

class SiteService : ISiteService
{
    private readonly CesiCompanyDirectoryDbContext _dbContext;

    public SiteService(CesiCompanyDirectoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<Site>> GetSitesAsync()
    {
        return await _dbContext.Sites.ToListAsync();
    }

    /// <inheritdoc />
    public async Task<Site> GetSiteByIdAsync(int id)
    {
        return await _dbContext.Sites.FindAsync(id);
    }

    /// <inheritdoc />
    public async Task CreateSiteAsync(Site site)
    {
        _dbContext.Sites.Add(site);
        await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateSiteAsync(Site site)
    {
        _dbContext.Entry(site).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<bool> DeleteSiteAsync(int id)
    {
        var site = await _dbContext.Sites.FindAsync(id);

        if (site == null)
        {
            return false;
        }

        if (!await IsSiteEmptyAsync(id))
        {
            return false;
        }

        _dbContext.Sites.Remove(site);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc />
    public async Task<bool> IsSiteEmptyAsync(int siteId)
    {
        return !await _dbContext.Employees.AnyAsync(e => e.SiteId == siteId);
    }

}