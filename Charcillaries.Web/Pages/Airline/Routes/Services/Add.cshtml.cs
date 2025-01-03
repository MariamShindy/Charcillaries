using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Airline.Routes.Services;

public class AddModel(
    IAirlineRepository repo,
    ILogger<AddModel> logger) : PageModel
{
    [BindProperty] public RouteAmenityNewInput RouteAmenity { get; set; } = new();
    [BindProperty] public string AmenityId { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)] public string RouteId { get; set; } = string.Empty;

    public FlightRouteDetailsView? Route { get; set; }
    public List<AmenitiesDetailsView> Amenities { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(string routeId)
    {
        RouteId = routeId;
        Route = await repo.GetAirlineRouteDetailsAsync(Hash.DecodeToInt(routeId));
        if (Route == null)
        {
            return NotFound();
        }

        Amenities = await repo.GetAmenitiesAsync(Route.AirlineId);
        logger.LogInformation("amenities fetched successfully");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string routeId)
    {
        logger.LogInformation("adding service");
        RouteAmenity.FlightRouteId = Hash.DecodeToInt(routeId);
        RouteAmenity.AmenityId = Hash.DecodeToInt(AmenityId);
        logger.LogInformation(RouteAmenity.FlightRouteId.ToString());
        logger.LogInformation(RouteAmenity.AmenityId.ToString());
        var existingAmenity = await repo.CheckExistingAmenity(RouteAmenity.FlightRouteId, RouteAmenity.AmenityId);
        if (existingAmenity != string.Empty)
        {
            ModelState.AddModelError(string.Empty, existingAmenity);
        }
        if (!ModelState.IsValid)
        {
            Route = await repo.GetAirlineRouteDetailsAsync(RouteAmenity.FlightRouteId);
            if (Route == null)
            {
                return NotFound();
            }

            Amenities = await repo.GetAmenitiesAsync(Route.AirlineId);

            return Page();
        }

        await repo.SaveRouteAmenityAsync(RouteAmenity);

        return Redirect($"/airline/routes/{routeId}/services/enabled");
    }
}