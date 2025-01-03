using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Airline.Flights;

public class DetailsModel(
    IFlightRepository repo
) : PageModel
{
    public FlightPassengersDetailsView? FlightPassengersList { get; set; }
    public IList<Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.Passenger> FilteredPassengers { get; set; } = new List<Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.Passenger>();

    [BindProperty(SupportsGet = true)]
    public string? FirstName { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? LastName { get; set; }

    [BindProperty(SupportsGet = true)]
    public bool IsPaid { get; set; }

    public async Task<IActionResult> OnGet(string flightId, string? action = null)
    {
        FlightPassengersList = await repo.GetFlightPassengersAsync(Hash.DecodeToInt(flightId));
        if (FlightPassengersList is null)
            return NotFound();
        if (action == "clear")
        {
            FirstName = null;
            LastName = null;
            IsPaid = false;
        }
        FilteredPassengers = ApplyFilters(FlightPassengersList.Passengers);

        return Page();
    }

    private IList<Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.Passenger> ApplyFilters(IEnumerable<Data.Views.DtoClasses.FlightPassengersDetailsViewTypes.Passenger> passengers)
    {
        if (!string.IsNullOrWhiteSpace(FirstName))
            passengers = passengers.Where(p => p.Person.FirstName.Contains(FirstName, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(LastName))
            passengers = passengers.Where(p => p.Person.LastName.Contains(LastName, StringComparison.OrdinalIgnoreCase));

        if (IsPaid)
            passengers = passengers.Where(p => p.PaymentConfirmation != null);

        return passengers.ToList();
    }
}