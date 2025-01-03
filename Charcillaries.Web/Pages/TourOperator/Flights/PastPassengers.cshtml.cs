using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.TourOperator.Flights;

public class PastFlightPassengers(
    IFlightRepository flightManagementRepository, ILogger<UpcomingFlightPassengers> logger
) : PageModel
{
    public List<PassengerListView> PassengerListViews { get; set; } = [];
    public FlightDetailsView? FlightDetailsView { get; set; } = new();
    [BindProperty(SupportsGet = true)] public string FlightId { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string flightId, string? sort)
    {
        var decodedFlightId = Hash.DecodeToInt(flightId);
        FlightDetailsView = await flightManagementRepository.GetFlightAsync(decodedFlightId);
        PassengerListViews = await flightManagementRepository.GetPassengersAsync(decodedFlightId);
        PassengerListViews = sort switch
        {
            "firsNameAsc" => PassengerListViews.OrderBy(p => p.Person.FirstName).ToList(),
            "firstNameDes" => PassengerListViews.OrderByDescending(p => p.Person.FirstName).ToList(),
            "lastNameAsc" => PassengerListViews.OrderBy(p => p.Person.LastName).ToList(),
            "lastNameDes" => PassengerListViews.OrderByDescending(p => p.Person.LastName).ToList(),
            _ => PassengerListViews
        };
        if (FlightDetailsView == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnGetSearch(string searchTerm)
    {
        var decodedFlightId = Hash.DecodeToInt(FlightId);

        logger.LogInformation(searchTerm);
        logger.LogInformation(decodedFlightId.ToString());
        var passengers = await flightManagementRepository.GetPassengersFromSearchAsync(decodedFlightId, searchTerm);

        return Partial("partials/_PastPassengerList", passengers);
    }
}