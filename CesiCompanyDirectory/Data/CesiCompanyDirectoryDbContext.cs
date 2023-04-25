using CesiCompanyDirectory.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CesiCompanyDirectory.Data;

public class CesiCompanyDirectoryDbContext : IdentityDbContext
{
    public CesiCompanyDirectoryDbContext(DbContextOptions<CesiCompanyDirectoryDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the foreign key relationships between entities
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Service)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.ServiceId);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Site)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.SiteId);

        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasNoKey();
        
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasNoKey();   
        
        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasNoKey();
        
        modelBuilder.Entity<IdentityUserClaim<string>>()
            .HasNoKey();
    }
}