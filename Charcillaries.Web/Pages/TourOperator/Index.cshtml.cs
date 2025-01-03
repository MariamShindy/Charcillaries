using Charcillaries.Core.Features.TourOperator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.TourOperator;

public class IndexModel(
    ILogger<IndexModel> logger,
    ITourOperatorRepository repo) : PageModel
{
    public int UpcomingFlights { get; set; }
    public int TotalFlights { get; set; }
    public int Passengers { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var tourOperatorId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        UpcomingFlights = await repo.GetNumberOfUpcomingFlights(tourOperatorId);
        logger.LogInformation(UpcomingFlights.ToString());
        TotalFlights = await repo.GetNumberOfAllFlights(tourOperatorId);
        logger.LogInformation(TotalFlights.ToString());
        Passengers = await repo.GetNumberOfPassengers(tourOperatorId);
        logger.LogInformation(Passengers.ToString());
        logger.LogInformation("Data fetched successfully");
        return Page();
    }
}