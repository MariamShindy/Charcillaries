using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Services;

public class DisabledServicesModel(
    ILogger<DisabledServicesModel> logger,
    IAirlineRepository airlineManagementRepository) : PageModel
{
    public List<AmenitiesDetailsView> DisabledAmenties { get; set; } = [];

    public async Task OnGetAsync()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        DisabledAmenties =
            await airlineManagementRepository.GetAmenitiesAsync(airlineId, Constants.ObjectStatus.Disabled);
        logger.LogInformation(DisabledAmenties.Count > 0
            ? "Disabled amenties found successfully"
            : "There is no disabled amenties");
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        logger.LogInformation("Attempting to enable amenity with ID: {AmenityId}", id);
        await airlineManagementRepository.EnableAirlineServiceAsync(Hash.DecodeToInt(id));
        return RedirectToPage();
    }
}