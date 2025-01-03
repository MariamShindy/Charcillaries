using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Routes;

public class EditModel(IAirlineRepository repo, ILogger<AddModel> logger, IValidator<RouteUpdateInput> validator)
    : PageModel
{
    [BindProperty] public RouteUpdateInput Route { get; set; } = new();
    public List<string> Airports { get; set; } = [];
    public FlightRouteDetailsView? RouteDetails { get; set; }

    public async Task<IActionResult> OnGetAsync(string routeId)
    {
        RouteDetails = await repo.GetAirlineRouteDetailsAsync(Hash.DecodeToInt(routeId));
        if (RouteDetails == null)
            return NotFound();
        Airports = await repo.GetAirportsAsync();
        Route.AirlineId = RouteDetails.AirlineId;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string routeId)
    {
        Route.AirlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Route.Id = Hash.DecodeToInt(routeId);

        var validationResult = await validator.ValidateAsync(Route);
        validationResult.AddToModelState(ModelState, nameof(Route));
        var routeExists = await repo.CheckExisitngRoute(Route.DepartureAirport, Route.ArrivalAirport, Route.AirlineId);
        if (routeExists)
        {
            ModelState.AddModelError(string.Empty, "This route already exists.");
        }

        if (!ModelState.IsValid)
        {
            Airports = await repo.GetAirportsAsync();
            RouteDetails = await repo.GetAirlineRouteDetailsAsync(Route.Id);
            return Page();
        }

        var result = await repo.SaveRouteAsync(Route);
        logger.LogInformation("route saved");
        Airports = await repo.GetAirportsAsync();
        RouteDetails = await repo.GetAirlineRouteDetailsAsync(Route.Id);
        return Redirect($"/airline/routes/enabled");
    }
}