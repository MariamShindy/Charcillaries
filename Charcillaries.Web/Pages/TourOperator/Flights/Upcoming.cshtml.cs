using Charcillaries.Core.Features.Passenger;
using Charcillaries.Core.Features.TourOperator;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.TourOperator.Flights;

public class UpComingFlightsModel(
    ILogger<UpComingFlightsModel> logger,
    IPassengerRepository passengerRepository,
    ITourOperatorRepository repo) : PageModel
{
    public List<FlightRouteListView> AirlineRoutes { get; set; } = [];
    public List<FlightDetailsView> FilteredTourOperatorsFlights { get; set; } = [];

    [BindProperty(SupportsGet = true)] public PassengersFlightsFilter Filter { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string? sort, DateTime? departureAfter,
        DateTime? departureBefore, string? departureAirport, string? arrivalAirport)
    {
        var tourOperatorId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Filter = new PassengersFlightsFilter
        {
            DepartureDateAfter = departureAfter,
            DepartureDateBefore = departureBefore,
            DepartureAirport = departureAirport,
            ArrivalAirport = arrivalAirport,
            TourOperatorId = tourOperatorId
        };
        AirlineRoutes = await repo.GetTourOperatorRoutesAsync(tourOperatorId);
        FilteredTourOperatorsFlights =
            await passengerRepository.GetFilteredUpcomingFlightsAsync(Filter);
        logger.LogInformation("Flights are fetched successfully");
        FilteredTourOperatorsFlights = sort switch
        {
            "flightNumberAsc" => FilteredTourOperatorsFlights.OrderBy(f => f.FlightNumber).ToList(),
            "flightNumberDes" => FilteredTourOperatorsFlights.OrderByDescending(f => f.FlightNumber).ToList(),
            _ => FilteredTourOperatorsFlights
        };
        return Page();
    }
}