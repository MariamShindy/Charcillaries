using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Airline.Routes;

public class DetailsModel(IAirlineRepository repo) : PageModel
{
    public FlightRouteDetailsView? Route { get; set; }

    public async Task<IActionResult> OnGetAsync(string routeId)
    {
        Route = await repo.GetAirlineRouteDetailsAsync(Hash.DecodeToInt(routeId));
        if (Route == null)
        {
            return NotFound();
        }

        return Page();
    }
}