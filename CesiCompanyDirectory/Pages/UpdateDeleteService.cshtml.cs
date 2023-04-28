using CesiCompanyDirectory.Models;
using CesiCompanyDirectory.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CesiCompanyDirectory.Pages;

public class UpdateDeleteService : PageModel
{
    private readonly IServiceService _serviceService;

    public Service? Service;

    public UpdateDeleteService(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public async Task OnGet(int serviceId)
    {
        Service = await _serviceService.GetServiceByIdAsync(serviceId);
    }

    /// <summary>
    /// Handles updating a service with the specified ID.
    /// </summary>
    /// <param name="serviceId">The ID of the service to update.</param>
    /// <param name="service">The updated service object.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<IActionResult> OnPostUpdateService(int serviceId, [FromForm] Service service)
    {
        var serviceInput = new Service
        {
            Id = serviceId,
            Name = service.Name,
        };

        Service = await _serviceService.GetServiceByIdAsync(serviceId);
        if (Service != null)
        {
            // Update the service with the new data
            Service.Name = serviceInput.Name;
            await _serviceService.UpdateServiceAsync(Service);
        }

        // Redirect back to the services page
        return RedirectToPage("./Services");
    }

    /// <summary>
    /// Handles deleting a service with the specified ID.
    /// </summary>
    /// <param name="serviceId">The ID of the service to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<IActionResult> OnPostDeleteService(int serviceId)
    {
        // Check if there are any employees linked to the service
        bool serviceDeleted = await _serviceService.DeleteServiceAsync(serviceId);

        if (serviceDeleted)
        {
            // Service was deleted, redirect to page
            return RedirectToPage("./Services");
        }

        // Service was not deleted, display an error message
        TempData["ErrorMessage"] = "Cannot delete service - employees are linked to it.";
        return Page();
    }

}