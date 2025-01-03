using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Core.Features.TourOperator;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Flights;

public class AddModel(
    IFlightRepository repo,
    ITourOperatorRepository tourOperatorRepo,
    IAirlineRepository airlineRepo,
    IValidator<FlightNewInput> validator
) : PageModel
{
    [BindProperty] public FlightNewInput Flight { get; set; } = new();
    [BindProperty] public string FlightRouteId { get; set; } = string.Empty;
    [BindProperty] public string TourOperatorId { get; set; } = string.Empty;

    public List<FlightRouteListView> Routes { get; set; } = [];

    public List<TourOperatorDetailsView> TourOperators { get; set; } = [];

    public FlightRouteDetailsView? FlightRouteAmenities { get; set; }

    public async Task OnGet()
    {
        await GetLists();
    }

    public async Task<IActionResult> OnPostRoutesAsync()
    {
        Flight.FlightRouteId = Hash.DecodeToInt(FlightRouteId);

        FlightRouteAmenities = await repo.GetFlightRouteAmenitiesAsync(Flight.FlightRouteId);
        if (FlightRouteAmenities == null)
            return NotFound();

        return Partial("_FlightRouteAmenities", FlightRouteAmenities);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Flight.FlightRouteId = Hash.DecodeToInt(FlightRouteId);
        Flight.TourOperatorId = Hash.DecodeToInt(TourOperatorId);

        var validationResult = await validator.ValidateAsync(Flight);
        validationResult.AddToModelState(ModelState, nameof(Flight));

        if (!ModelState.IsValid)
        {
            await GetLists();
            return Page();
        }

        var result = await repo.SaveFlightAsync(Flight);

        if (result)
            return Redirect("/airline/flights/upcoming");

        ModelState.AddModelError(string.Empty, "An error occurred while saving the flight");
        await GetLists();
        return Page();
    }

    public async Task GetLists()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        Routes = await airlineRepo.GetAirlineRoutesAsync(airlineId);
        TourOperators = await tourOperatorRepo.GetTourOperatorsAsync();

        if (Routes.Count != 0)
            FlightRouteAmenities = await repo.GetFlightRouteAmenitiesAsync(Routes[0].Id);
    }
}