using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.TourOperator.Flights;

public class UpcomingFlightPassengers(
    IFlightRepository flightManagementRepository,
    IPassengerRepository passengerManagementRepository,
    IValidator<PassengerNewInput> passengerNewInputValidator,
    ILogger<UpcomingFlightPassengers> logger
)
    : PageModel
{
    public List<PassengerListView> PassengerListViews { get; set; } = [];
    public FlightDetailsView? FlightDetailsView { get; set; } = new();

    [BindProperty] public PassengerNewInput PassengerNewInput { get; set; } = new();
    [BindProperty(SupportsGet = true)] public string FlightId { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string flightId, string? sort)
    {
        var decodedFlightId = Hash.DecodeToInt(flightId);
        FlightDetailsView = await flightManagementRepository.GetFlightAsync(decodedFlightId);
        PassengerListViews = await flightManagementRepository.GetPassengersAsync(decodedFlightId);
        PassengerListViews = sort switch
        {
            "firsNameAsc" => PassengerListViews.OrderBy(p => p.Person.FirstName).ToList(),
            "firstNameDes" => PassengerListViews.OrderByDescending(p => p.Person.FirstName).ToList(),
            "lastNameAsc" => PassengerListViews.OrderBy(p => p.Person.LastName).ToList(),
            "lastNameDes" => PassengerListViews.OrderByDescending(p => p.Person.LastName).ToList(),
            _ => PassengerListViews
        };
        if (FlightDetailsView == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string flightId)
    {
        PassengerNewInput.FlightId = Hash.DecodeToInt(flightId);

        var validationResult = await passengerNewInputValidator.ValidateAsync(PassengerNewInput);
        validationResult.AddToModelState(ModelState, nameof(PassengerNewInput));

        if (!validationResult.IsValid)
            return Partial("partials/AddPassengerErrorMessages", this);

        var (_, passengerId) = await passengerManagementRepository.SavePassengerAsync(PassengerNewInput);
        return Partial("partials/Passenger", (PassengerNewInput, passengerId));
    }

    public async Task<IActionResult> OnPostDelete(string passengerId)
    {
        logger.LogInformation(passengerId);
        var passengerRemoveInput = new PassengerRemoveInput { PassengerId = Hash.DecodeToInt(passengerId) };

        var removed = await passengerManagementRepository.RemovePassengerAsync(passengerRemoveInput);
        if (!removed)
        {
            Response.StatusCode = 500;
            return Content("");
        }

        Response.StatusCode = 200;
        return Content("");
    }

    public async Task<IActionResult> OnGetSearch(string searchTerm)
    {
        var decodedFlightId = Hash.DecodeToInt(FlightId);

        logger.LogInformation(searchTerm);
        logger.LogInformation(decodedFlightId.ToString());
        var passengers = await flightManagementRepository.GetPassengersFromSearchAsync(decodedFlightId, searchTerm);

        return Partial("partials/_PassengerList", passengers);
    }
}