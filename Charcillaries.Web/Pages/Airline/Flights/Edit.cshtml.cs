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

public class EditModel(
    IFlightRepository repo,
    ITourOperatorRepository tourOperatorRepo,
    IAirlineRepository airlineRepo,
    IValidator<FlightUpdateInput> validator
) : PageModel
{
    [BindProperty] public FlightUpdateInput Flight { get; set; } = new();
    [BindProperty] public string FlightRouteId { get; set; } = string.Empty;
    [BindProperty] public string TourOperatorId { get; set; } = string.Empty;

    public List<FlightRouteListView> Routes { get; set; } = [];

    public List<TourOperatorDetailsView> TourOperators { get; set; } = [];

    public FlightRouteDetailsView? FlightRouteAmenities { get; set; } = new();

    public FlightDetailsView? FlightDetailsView { get; set; } = new();

    public async Task OnGet(string id)
    {
        await GetLists(Hash.DecodeToInt(id));
    }

    public async Task<IActionResult> OnPostRoutesAsync()
    {
        Flight.FlightRouteId = Hash.DecodeToInt(FlightRouteId);

        FlightRouteAmenities = await repo.GetFlightRouteAmenitiesAsync(Flight.FlightRouteId);
        if (FlightRouteAmenities == null)
            return NotFound();

        return Partial("_FlightRouteAmenities", FlightRouteAmenities);
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        Flight.Id = Hash.DecodeToInt(id);
        Flight.FlightRouteId = Hash.DecodeToInt(FlightRouteId);
        Flight.TourOperatorId = Hash.DecodeToInt(TourOperatorId);

        var validationResult = await validator.ValidateAsync(Flight);
        validationResult.AddToModelState(ModelState, nameof(Flight));

        if (!ModelState.IsValid)
        {
            await GetLists(Flight.Id);
            return Page();
        }

        var result = await repo.SaveFlightAsync(Flight);

        if (result)
            return Redirect("/airline/flights/upcoming");

        ModelState.AddModelError(string.Empty, "An error occurred while saving the flight");
        await GetLists(Flight.Id);

        // Flight.ArrivalDate = Flight.ArrivalDate.AddSeconds(Flight.ArrivalDate.Second * -1);
        // Flight.DepartureDate = Flight.DepartureDate.();

        return Page();
    }

    public async Task<IActionResult> GetLists(int id)
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        Routes = await airlineRepo.GetAirlineRoutesAsync(airlineId);
        TourOperators = await tourOperatorRepo.GetTourOperatorsAsync();
        FlightDetailsView = await repo.GetFlightAsync(id);

        if (FlightDetailsView is null)
            return NotFound();

        Flight.DepartureDate = FlightDetailsView.DepartureDate.ToLocalTime()
            .AddSeconds(FlightDetailsView.DepartureDate.Second * -1);
        Flight.ArrivalDate = FlightDetailsView.ArrivalDate.ToLocalTime()
            .AddSeconds(FlightDetailsView.ArrivalDate.Second * -1);

        if (Routes.Count != 0)
            FlightRouteAmenities = await repo.GetFlightRouteAmenitiesAsync(FlightDetailsView.FlightRoute.Id);

        return Page();
    }
}