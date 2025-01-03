using Charcillaries.Core.Features.Flight;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Flights;

public class IndexModel(ILogger<IndexModel> logger, IFlightRepository flightManagementRepository)
    : PageModel
{
    public List<FlightListView> Flights { get; set; } = [];

    public async Task OnGetAsync(string? sort)
    {
        Flights = await flightManagementRepository.GetFlightsAsync();
        logger.LogInformation("Flights data fetched successfully");

        Flights = sort switch
        {
            "flightNumberAsc" => Flights.OrderBy(f => f.FlightNumber).ToList(),
            "flightNumberDes" => Flights.OrderByDescending(f => f.FlightNumber).ToList(),
            "numberOfSeatsAsc" => Flights.OrderBy(f => f.NumberOfSeats).ToList(),
            "numberOfSeatsDes" => Flights.OrderByDescending(f => f.NumberOfSeats).ToList(),
            _ => Flights
        };
    }
}