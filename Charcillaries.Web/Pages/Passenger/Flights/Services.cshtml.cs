using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Passenger.Flights;

public class ServicesModel(
    ILogger<ServicesModel> logger,
    IFlightRepository flightManagementRepository) : PageModel
{
    public FlightRouteDetailsView? FlightRouteAmenities { get; set; }

    public int PassengerId { get; set; }

    public async Task<IActionResult> OnGetAsync(string flightRouteId, string passengerId)
    {
        FlightRouteAmenities =
            await flightManagementRepository.GetFlightRouteAmenitiesAsync(Hash.DecodeToInt(flightRouteId));
        if (FlightRouteAmenities == null)
            return NotFound();
        logger.LogInformation("Amenties in the flight found");

        PassengerId = Hash.DecodeToInt(passengerId);
        return Page();
    }
}