using Microsoft.AspNetCore.Identity;

namespace CesiCompanyDirectory.Models;

public class User : IdentityUser
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
}