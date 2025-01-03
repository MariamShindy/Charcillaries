using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline;

public class IndexModel(
    ILogger<IndexModel> logger,
    IAirlineRepository airlineManagementRepository) : PageModel
{
    [BindProperty] public AirlineDetailsView? Airline { get; set; }

    public int NumOfEnabledServices { get; set; }
    public int NumOfDisabledServices { get; set; }
    public int NumOfRoutes { get; set; }
    public int NumOfUpcomingFlights { get; set; }

    public async Task OnGetAsync()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        Airline = await airlineManagementRepository.GetAirlineAsync(airlineId);
        if (Airline?.Amenities != null)
        {
            NumOfEnabledServices = await airlineManagementRepository.GetNumberOfEnabledAmenitiesAsync(airlineId);
            NumOfDisabledServices = Airline.Amenities.Count - NumOfEnabledServices;
        }

        NumOfUpcomingFlights = await airlineManagementRepository.GetNumberOfUpcomingFlightsAsync(airlineId);
        NumOfRoutes = await airlineManagementRepository.GetNumberOfRoutesAsync(airlineId);
        logger.LogInformation("Airline found successfully");
    }
}