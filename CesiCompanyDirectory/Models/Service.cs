namespace CesiCompanyDirectory.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation properties
    public ICollection<Employee> Employees { get; set; }
}