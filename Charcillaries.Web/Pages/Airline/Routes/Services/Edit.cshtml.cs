using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Airline.Routes.Services;

public class EditModel(IAirlineRepository repo, ILogger<AddModel> logger, IValidator<RouteAmenityUpdateInput> validator)
    : PageModel
{
    [BindProperty] public RouteAmenityUpdateInput RouteAmenity { get; set; } = new();
    [BindProperty] public string AmenityId { get; set; } = string.Empty;
    [BindProperty] public string FlightRouteId { get; set; } = string.Empty;
    public RouteAmenityDetailsView? RouteAmenityDetails { get; set; }

    public async Task<IActionResult> OnGetAsync(string routeAmenityId)
    {
        RouteAmenityDetails = await repo.GetRouteAmenity(Hash.DecodeToInt(routeAmenityId));
        if (RouteAmenityDetails == null)
            return NotFound();
        logger.LogInformation("route amenity fetched");
        FlightRouteId = Hash.EncodeInt(RouteAmenityDetails.FlightRouteId);
        AmenityId = Hash.EncodeInt(RouteAmenityDetails.AmenityId);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string routeAmenityId)
    {
        RouteAmenity.AmenityId = Hash.DecodeToInt(AmenityId);
        RouteAmenity.FlightRouteId = Hash.DecodeToInt(FlightRouteId);
        RouteAmenity.Id = Hash.DecodeToInt(routeAmenityId);

        var validationResult = await validator.ValidateAsync(RouteAmenity);
        validationResult.AddToModelState(ModelState, nameof(RouteAmenity));
        if (!ModelState.IsValid)
        {
            RouteAmenityDetails = await repo.GetRouteAmenity(RouteAmenity.Id);
            return Page();
        }

        var result = await repo.SaveRouteAmenityAsync(RouteAmenity);
        logger.LogInformation("route amenity saved");
        RouteAmenityDetails = await repo.GetRouteAmenity(RouteAmenity.Id);
        return Redirect($"/airline/routes/{FlightRouteId}/services/enabled");
    }
}