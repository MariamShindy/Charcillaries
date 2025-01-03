using Charcillaries.Core.Features.Airline;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Core.Features.TourOperator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin;

public class IndexModel(ILogger<IndexModel> logger,
    ITourOperatorRepository tourOperatorManagementRepository,
    IAirlineRepository airlineManagementRepository,
    IPassengerRepository passengerManagementRepository) : PageModel
{
    public int TourOperators { get; set; }
    public int Airlines { get; set; }
    public int Passengers { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        TourOperators = await tourOperatorManagementRepository.GetNumberOfTourOperators();
        Airlines = await airlineManagementRepository.GetNumberOfAirlines();
        Passengers = await passengerManagementRepository.GetNumberOfPassengersAsync();
        logger.LogInformation("Data fetched successfully");
        return Page();
    }
}