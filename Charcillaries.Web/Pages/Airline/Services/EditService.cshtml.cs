using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Airline.Services;

public class EditServiceModel(
    IAirlineRepository repo,
    ILogger<EditServiceModel> logger,
    IValidator<AmenityUpdateInput> validator) : PageModel
{
    public AmenitiesDetailsView? Service { get; set; } = new();
    [BindProperty] public AmenityUpdateInput ServiceInput { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string serviceId)
    {
        Service = await repo.GetAmenityAsync(Hash.DecodeToInt(serviceId));

        if (Service == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string serviceId)
    {
        ServiceInput.Id = Hash.DecodeToInt(serviceId);

        var validationResult = await validator.ValidateAsync(ServiceInput);
        validationResult.AddToModelState(ModelState, nameof(ServiceInput));

        if (!ModelState.IsValid)
        {
            Service = await repo.GetAmenityAsync(ServiceInput.Id);
            return Page();
        }

        var result = await repo.SaveAmenityAsync(ServiceInput);
        if (result)
        {
            logger.LogInformation($"Amenity with ID {ServiceInput.Id} updated successfully");
            return Redirect($"/airline/services/enabled");
        }

        logger.LogWarning($"Failed to update Amenity with ID {ServiceInput.Id}");
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string serviceId)
    {
        var decodedServiceId = Hash.DecodeToInt(serviceId);

        var result = await repo.DeleteAmenityImageAsync(decodedServiceId);

        if (!result)
        {
            logger.LogWarning($"Failed to delete Amenity with ID {decodedServiceId}");
            Service = await repo.GetAmenityAsync(ServiceInput.Id);
            return Page();
        }

        logger.LogInformation($"Amenity with ID {decodedServiceId} deleted successfully");
        return Redirect("/airline/services/enabled");
    }
}