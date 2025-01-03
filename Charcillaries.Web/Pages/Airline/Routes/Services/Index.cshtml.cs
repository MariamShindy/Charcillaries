using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Airline.Routes.Services;

public class IndexModel(IAirlineRepository repo, ILogger<IndexModel> logger) : PageModel
{
    public List<RouteAmenityListView> RouteAmenities { get; set; } = [];
    public FlightRouteDetailsView? Route { get; set; }

    [BindProperty(SupportsGet = true)] public string RouteId { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string routeId)
    {
        var decodedRouteId = Hash.DecodeToInt(routeId);
        RouteAmenities = await repo.GetRouteAmenities(decodedRouteId);
        Route = await repo.GetAirlineRouteDetailsAsync(decodedRouteId);
        if (Route == null)
        {
            return NotFound();
        }

        RouteId = routeId;
        logger.LogInformation("route amenities are fetched");
        return Page();
    }

    public async Task<IActionResult> OnPost(string id)
    {
        logger.LogInformation("Attempting to delete route amenity with ID: {RouteAmenity}", id);
        await repo.DisableRouteAmenityAsync(Hash.DecodeToInt(id));
        return RedirectToPage();
    }
}