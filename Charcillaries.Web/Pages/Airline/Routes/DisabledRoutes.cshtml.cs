using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Routes;

public class DisabledRoutesModel(
    ILogger<DisabledRoutesModel> logger,
    IAirlineRepository airlineManagementRepository) : PageModel
{
    public List<FlightRouteListView> Routes { get; set; } = [];
    public Dictionary<int, int> RouteEnabledServices { get; set; } = [];

    public async Task<IActionResult> OnGetAsync()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        Routes = await airlineManagementRepository.GetAirlineRoutesAsync(airlineId, Constants.ObjectStatus.Disabled);
        logger.LogInformation("Routes are fetched successfully");
        foreach (var route in Routes)
            RouteEnabledServices[route.Id] =
                await airlineManagementRepository.GetNumberOfRouteEnabledServicesAsync(route.Id);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        logger.LogInformation("Attempting to enable route with ID: {RouteId}", id);
        await airlineManagementRepository.EnableAirlineRouteAsync(Hash.DecodeToInt(id));
        return RedirectToPage();
    }
}