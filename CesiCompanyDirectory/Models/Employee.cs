using Microsoft.AspNetCore.Mvc;

namespace CesiCompanyDirectory.Models;

[BindProperties]
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Email { get; set; }
    public string? Picture { get; set; }

    // Foreign key properties
    public int? ServiceId { get; set; }
    public int? SiteId { get; set; }

    // Navigation properties
    public Service? Service { get; set; }
    public Site? Site { get; set; }
}