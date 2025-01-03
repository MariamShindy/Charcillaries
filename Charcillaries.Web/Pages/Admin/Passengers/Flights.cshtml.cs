using Charcillaries.Core;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Passengers;

public class FlightsModel(
    ILogger<FlightsModel> logger,
    IPassengerRepository passengerManagementRepository) : PageModel
{
    public PassengerFlightDetailsView? Passenger { get; set; }
    public List<PassengerFlightListView> Flights { get; set; } = [];

    public async Task<IActionResult> OnGetAsync(string personId)
    {
        var decodedPersonId = Hash.DecodeToInt(personId);
        Passenger = await passengerManagementRepository.GetPersonAsync(decodedPersonId);
        if (Passenger == null)
            return NotFound();
        Flights = await passengerManagementRepository.GetFlightsAsync(decodedPersonId);

        logger.LogInformation("Flights are fetched successfully");

        return Page();
    }
}