using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Passenger.Flights;

public class TripDetailsModel(
    ILogger<TripDetailsModel> logger,
    IPassengerRepository passengerManagementRepository,
    IAirlineRepository airlineManagementRepository) : PageModel
{
    public PassengerFlightDetailsView? Passenger { get; set; }

    public async Task<IActionResult> OnGetAsync(string passengerId)
    {
        Passenger = await passengerManagementRepository.GetPassengerAsync(Hash.DecodeToInt(passengerId));
        if (Passenger == null)
            return NotFound();
        logger.LogInformation($"passenger with Id {passengerId} id found");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        logger.LogInformation("Attempting to cancel trip with ID: {flightId}", id);
        await airlineManagementRepository.CancelAirlineFlight(Hash.DecodeToInt(id));
        //Edit
        return Redirect("/passenger/flights/upcoming-flights");
    }
}