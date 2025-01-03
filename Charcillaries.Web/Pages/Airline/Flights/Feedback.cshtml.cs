using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Flights;

public class FeedbackModel(
    ILogger<FeedbackModel> logger,
    IAirlineRepository repo,
    IFlightRepository flightRepo) : PageModel
{
    public List<RouteFlightFeedbackDetailsView>? FlightsFeedback { get; set; }
    public FlightDetailsView? FlightDetails { get; set; }

    public async Task OnGetAsync(string flightId)
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        var decodedFlightId = Hash.DecodeToInt(flightId);

        FlightsFeedback = await repo.GetFlightFeedbackAsync(airlineId, decodedFlightId);
        FlightDetails = await flightRepo.GetFlightAsync(decodedFlightId);
        logger.LogInformation(FlightsFeedback.Count > 0
            ? "Feedbacks for flight found successfully"
            : "There is no feedbacks for that flight");
    }
}