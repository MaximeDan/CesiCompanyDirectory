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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the foreign key relationships between entities
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Service)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.ServiceId)
            .IsRequired(false);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Site)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.SiteId)
            .IsRequired(false);

        modelBuilder.Entity<Employee>()
            .ToTable(nameof(Employee));
        
        modelBuilder.Entity<Site>()
            .ToTable(nameof(Site));
        
        modelBuilder.Entity<Service>()
            .ToTable(nameof(Service));

        modelBuilder.Entity<IdentityUser>(b =>
        {
            // Primary key
            b.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            b.ToTable("Users");

            // A concurrency token for use with the optimistic concurrency checking
            b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            b.Property(u => u.UserName).HasMaxLength(256);
            b.Property(u => u.NormalizedUserName).HasMaxLength(256);
            b.Property(u => u.Email).HasMaxLength(256);
            b.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            b.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            b.HasMany<IdentityUserLogin<string>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            b.HasMany<IdentityUserToken<string>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(b =>
        {
            // Primary key
            b.HasKey(uc => uc.Id);

            // Maps to the UserClaims table
            b.ToTable("UserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(b =>
        {
            // Composite primary key consisting of the LoginProvider and the key to use
            // with that provider
            b.HasKey(l => new {l.LoginProvider, l.ProviderKey});

            // Limit the size of the composite key columns due to common DB restrictions
            b.Property(l => l.LoginProvider).HasMaxLength(128);
            b.Property(l => l.ProviderKey).HasMaxLength(128);

            // Maps to the UserLogins table
            b.ToTable("UserLogins");
        });

        modelBuilder.Entity<IdentityUserToken<string>>(b =>
        {
            // Composite primary key consisting of the UserId, LoginProvider and Name
            b.HasKey(t => new {t.UserId, t.LoginProvider, t.Name});

            // Limit the size of the composite key columns due to common DB restrictions
            b.Property(t => t.LoginProvider).HasMaxLength(256);
            b.Property(t => t.Name).HasMaxLength(256);

            // Maps to the UserTokens table
            b.ToTable("UserTokens");
        });

        modelBuilder.Entity<IdentityRole>(b =>
        {
            // Primary key
            b.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the Roles table
            b.ToTable("Roles");

            // A concurrency token for use with the optimistic concurrency checking
            b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            b.Property(u => u.Name).HasMaxLength(256);
            b.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            b.HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            b.HasMany<IdentityRoleClaim<string>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
        {
            // Primary key
            b.HasKey(rc => rc.Id);

            // Maps to the RoleClaims table
            b.ToTable("RoleClaims");
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            // Primary key
            b.HasKey(r => new {r.UserId, r.RoleId});

            // Maps to the UserRoles table
            b.ToTable("UserRoles");
        });
    }
}