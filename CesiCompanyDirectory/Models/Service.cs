using Microsoft.AspNetCore.Mvc;

namespace CesiCompanyDirectory.Models;

[BindProperties]
public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Employee> Employees { get; set; }
}