using Charcillaries.Core;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Passengers;

public class FlightDetailsModel(IPassengerRepository repo) : PageModel
{
    public PassengerFlightDetailsView? Passenger { get; set; }

    public async Task<IActionResult> OnGet(string passengerId)
    {
        Passenger = await repo.GetPassengerAsync(Hash.DecodeToInt(passengerId));

        if (Passenger == null)
            return NotFound();
        return Page();
    }
}