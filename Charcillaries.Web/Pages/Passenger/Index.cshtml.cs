using Charcillaries.Core.Features.Passenger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Passenger;

public class IndexModel(IPassengerRepository repo) : PageModel
{
    public int UpcomingFlights { get; set; }
    public int PastFlights { get; set; }
    public int CartItems { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var personId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Console.WriteLine("person");
        Console.WriteLine(personId);
        UpcomingFlights = await repo.GetNumberOfUpcomingFlightsAsync(personId);
        PastFlights = await repo.GetNumberOfPastFlightsAsync(personId);
        CartItems = await repo.GetNumberOfCartItemsAsync(personId);
        return Page();
    }
}