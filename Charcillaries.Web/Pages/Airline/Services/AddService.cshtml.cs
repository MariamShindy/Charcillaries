using Charcillaries.Core.Features.Airline;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Services;

public class AddServiceModel(
    ILogger<AddServiceModel> logger,
    IAirlineRepository repo,
    IValidator<AmenityNewInput> validator) : PageModel
{
    [BindProperty] public AmenityNewInput Amenity { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        Amenity.AirlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        var validationResult = await validator.ValidateAsync(Amenity);
        validationResult.AddToModelState(ModelState, nameof(Amenity));

        if (!ModelState.IsValid)
            return Page();

        try
        {
            var result = await repo.SaveAmenityAsync(Amenity);
            if (result)
                return Redirect($"/airline/services/enabled");

            ModelState.AddModelError("", "Error saving service");
            return Page();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error saving service");
            return Page();
        }
    }
}