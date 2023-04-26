using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CesiCompanyDirectory.Core;

public class RoleExistsAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var roleManager = (RoleManager<IdentityRole>)validationContext
            .GetService(typeof(RoleManager<IdentityRole>));

        var roles = Task.Run(async () => await roleManager?.Roles.Select(r => r.Name).ToListAsync())
            .GetAwaiter().GetResult();
        if (!roles.Contains((string)value))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}