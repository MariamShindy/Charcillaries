using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Flights;

public class DetailsModel(IFlightRepository flightRepo)
    : PageModel
{
    public FlightDetailsView? Flight { get; set; }

    public async Task<IActionResult> OnGet(string flightId)
    {
        Flight = await flightRepo.GetFlightAsync(Hash.DecodeToInt(flightId));

        if (Flight == null)
            return NotFound();
        return Page();
    }
}