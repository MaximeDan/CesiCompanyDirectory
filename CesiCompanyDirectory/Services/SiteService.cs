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

    public async Task<List<Site>> GetSitesAsync()
    {
        return await _dbContext.Sites.ToListAsync();
    }

    public async Task<Site> GetSiteByIdAsync(int id)
    {
        return await _dbContext.Sites.FindAsync(id);
    }

    public async Task CreateSiteAsync(Site site)
    {
        _dbContext.Sites.Add(site);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateSiteAsync(Site site)
    {
        _dbContext.Entry(site).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteSiteAsync(int id)
    {
        var site = await GetSiteByIdAsync(id);
        _dbContext.Sites.Remove(site);
        await _dbContext.SaveChangesAsync();
        
    }
}