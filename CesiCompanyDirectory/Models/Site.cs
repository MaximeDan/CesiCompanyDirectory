using Microsoft.AspNetCore.Mvc;

namespace CesiCompanyDirectory.Models;

[BindProperties]
public class Site
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Employee> Employees { get; set; }
}