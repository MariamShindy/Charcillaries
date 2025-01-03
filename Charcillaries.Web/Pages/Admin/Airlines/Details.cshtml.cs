using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Airlines;

public class DetailsModel(IAirlineRepository repo)
    : PageModel
{
    public AirlineDetailsView? Airline { get; set; }

    public async Task<IActionResult> OnGet(string airlineId)
    {
        Airline = await repo.GetAirlineAsync(Hash.DecodeToInt(airlineId));
        if (Airline == null)
            return NotFound();

        return Page();
    }
}