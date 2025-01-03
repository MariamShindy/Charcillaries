using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Services;

public class EnabledServicesModel(
    ILogger<EnabledServicesModel> logger,
    IAirlineRepository airlineManagementRepository) : PageModel
{
    public List<AmenitiesDetailsView> EnabledAmenties { get; set; } = [];

    public async Task OnGetAsync()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        EnabledAmenties = await airlineManagementRepository.GetAmenitiesAsync(airlineId);

        logger.LogInformation(EnabledAmenties.Count > 0
            ? "Enabled amenties found successfully"
            : "There is no enabled amenties");
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        logger.LogInformation("Attempting to disable amenity with ID: {AmenityId}", id);
        await airlineManagementRepository.DisableAirlineServiceAsync(Hash.DecodeToInt(id));
        return RedirectToPage();
    }
}