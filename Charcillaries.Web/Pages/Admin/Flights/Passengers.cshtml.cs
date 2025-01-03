using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Flights;

public class PassengersModel(
    ILogger<PassengersModel> logger,
    IFlightRepository flightManagementRepository) : PageModel
{
    public List<PassengerListView> Passengers { get; set; } = [];
    public FlightDetailsView? Flight { get; set; }

    public async Task<IActionResult> OnGetAsync(string flightId, string? sort)
    {
        var decodedFlightId = Hash.DecodeToInt(flightId);
        Passengers = await flightManagementRepository.GetPassengersAsync(decodedFlightId);

        Flight = await flightManagementRepository.GetFlightAsync(decodedFlightId);
        if (Flight == null)
            return NotFound();

        logger.LogInformation("Passengers are fetched successfully");

        Passengers = sort switch
        {
            "nameAsc" => Passengers.OrderBy(p => p.Person.FirstName).ThenBy(p => p.Person.LastName).ToList(),
            "nameDes" => Passengers.OrderByDescending(p => p.Person.FirstName)
                .ThenByDescending(p => p.Person.LastName)
                .ToList(),
            "emailAsc" => Passengers.OrderBy(p => p.Person.Email).ToList(),
            "emailDes" => Passengers.OrderByDescending(p => p.Person.Email).ToList(),
            _ => Passengers
        };
        return Page();
    }
}