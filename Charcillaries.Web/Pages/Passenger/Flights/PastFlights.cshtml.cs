using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Passenger.Flights;

public class PastFlightsModel(
    ILogger<PastFlightsModel> logger,
    IPassengerRepository passengerManagementRepository) : PageModel
{
    public List<PassengerFlightListView> Passengers { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(string? sort)
    {
        var personId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Passengers = await passengerManagementRepository.GetPastFlightsAsync(personId);
        logger.LogInformation("Passengers are fetched successfully");
        Passengers = sort switch
        {
            "dateAsc" => Passengers.OrderBy(p => p.Flight.ArrivalDate).ToList(),
            "dateDes" => Passengers.OrderByDescending(p => p.Flight.ArrivalDate).ToList(),
            "destinationAsc" => Passengers.OrderBy(p => p.Flight.FlightRoute.ArrivalAirport).ToList(),
            "destinationDes" => Passengers.OrderByDescending(p => p.Flight.FlightRoute.ArrivalAirport).ToList(),
            _ => Passengers
        };
        return Page();
    }
}