using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CesiCompanyDirectory.Data;
using CesiCompanyDirectory.Services;
using CesiCompanyDirectory.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CesiCompanyDirectoryDbContext>(options =>
    options.UseNpgsql(connectionString).UseCamelCaseNamingConvention());
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ISiteService, SiteService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CesiCompanyDirectoryDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Migrate the database on startup
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<CesiCompanyDirectoryDbContext>();
context.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();