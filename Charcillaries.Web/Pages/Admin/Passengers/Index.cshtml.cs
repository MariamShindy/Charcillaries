using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Passengers;

public class IndexModel(
    ILogger<IndexModel> logger,
    IPassengerRepository passengerManagementRepository) : PageModel
{
    public List<PassengerListView> Passengers { get; set; } = [];

    public async Task OnGetAsync(string? sort)
    {
        Passengers = await passengerManagementRepository.GetPassengersAsync();
        logger.LogInformation("Passengers data fetched successfully");

        Passengers = sort switch
        {
            "nameAsc" => Passengers.OrderBy(p => p.Person.FirstName).ThenBy(p => p.Person.LastName).ToList(),
            "nameDes" => Passengers.OrderByDescending(p => p.Person.FirstName)
                .ThenByDescending(p => p.Person.LastName)
                .ToList(),
            "emailAsc" => Passengers.OrderBy(p => p.Person.Email).ToList(),
            "emailDes" => Passengers.OrderByDescending(p => p.Person.Email).ToList(),
            _ => Passengers
        };
    }
}