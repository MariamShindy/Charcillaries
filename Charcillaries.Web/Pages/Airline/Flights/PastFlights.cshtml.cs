using Charcillaries.Core.Features.Airline;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Flights;

public class PastFlightsModel(
    IPassengerRepository passengerRepository,
    IAirlineRepository airlineRepository) : PageModel
{
    public List<FlightDetailsView> Flights { get; set; } = [];
    public List<FlightRouteListView> AirlineRoutes { get; set; } = [];
    [BindProperty(SupportsGet = true)] public PassengersFlightsFilter Filter { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(string? sort, DateTime? departureAfter,
        DateTime? departureBefore, string? departureAirport, string? arrivalAirport)
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Filter = new PassengersFlightsFilter
        {
            DepartureDateAfter = departureAfter,
            DepartureDateBefore = departureBefore,
            DepartureAirport = departureAirport,
            ArrivalAirport = arrivalAirport,
            AirlineId = airlineId
        };
        AirlineRoutes = await airlineRepository.GetAllAirlineRoutesAsync(airlineId);
        Flights = await passengerRepository.GetFilteredPastFlightsAsync(Filter);
        Flights = sort switch
        {
            "flightNumberAsc" => Flights.OrderBy(f => f.FlightNumber).ToList(),
            "flightNumberDes" => Flights.OrderByDescending(f => f.FlightNumber).ToList(),
            _ => Flights
        };
        return Page();
    }
}