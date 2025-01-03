using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Services;

public class FeedbackModel(
    ILogger<FeedbackModel> logger,
    IAirlineRepository repo) : PageModel
{
    public List<AmenityFeedbackDetailsView> AmenitiesFeedback { get; set; } = [];

    public async Task OnGetAsync(string serviceId)
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        AmenitiesFeedback = await repo.GetAmenityFeedbackAsync(airlineId, Hash.DecodeToInt(serviceId));

        logger.LogInformation(AmenitiesFeedback.Count > 0
            ? "Feedbacks for amenity found successfully"
            : "There is no feedbacks for that amenity");
    }
}