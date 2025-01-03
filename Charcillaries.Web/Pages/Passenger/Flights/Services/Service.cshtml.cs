using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Charcillaries.Web.Pages.Passenger.Flights.Services;

public class Service(
    IFlightRepository flightRepo,
    IPassengerRepository passengerRepo,
    IValidator<PassengerSelectionNewInput> validator,
    ILogger<Service> logger,
    IStringLocalizer<Global> L) : PageModel
{
    public RouteAmenityDetailsView? RouteAmenitiesDetailsView { get; set; } = new();

    [BindProperty] public PassengerSelectionNewInput PassengerSelectionNewInput { get; set; } = new();
    [BindProperty] public string FlightRouteId { get; set; } = string.Empty;
    [BindProperty] public string AmenityId { get; set; } = string.Empty;
    public int selectionStatus { get; set; }

    public async Task<IActionResult> OnGetAsync(string passengerId, string flightRouteAmenityId)
    {
        RouteAmenitiesDetailsView = await flightRepo.GetFlightRouteAmenityAsync(Hash.DecodeToInt(flightRouteAmenityId));

        if (RouteAmenitiesDetailsView == null)
            return NotFound();
        selectionStatus =
            await passengerRepo.CheckSelectionStatus(Hash.DecodeToInt(flightRouteAmenityId),
                Hash.DecodeToInt(passengerId));
        logger.LogInformation(selectionStatus.ToString());
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string flightRouteAmenityId, string passengerId)
    {
        var decodedPassengerId = Hash.DecodeToInt(passengerId);
        PassengerSelectionNewInput.PassengerId = decodedPassengerId;

        PassengerSelectionNewInput.RouteAmenityId = Hash.DecodeToInt(AmenityId);

        ModelState.Clear();
        var validationResult = await validator.ValidateAsync(PassengerSelectionNewInput);
        validationResult.AddToModelState(ModelState, nameof(PassengerSelectionNewInput));

        foreach (var error in validationResult.Errors) Console.WriteLine(error.ErrorMessage);

        if (!ModelState.IsValid)
        {
            RouteAmenitiesDetailsView =
                await flightRepo.GetFlightRouteAmenityAsync(Hash.DecodeToInt(flightRouteAmenityId));
            Console.WriteLine("Model state is not valid");
            return Page();
        }

        selectionStatus =
            await passengerRepo.CheckSelectionStatus(Hash.DecodeToInt(flightRouteAmenityId),
                Hash.DecodeToInt(passengerId));
        if (selectionStatus == 0)
        {
            // Save passenger selection
            await passengerRepo.SavePassengerSelectionAsync(PassengerSelectionNewInput);
            TempData["SuccessMessage"] = L["successfully-added"].Value;
            TempData.Keep();
            logger.LogInformation(TempData["SuccessMessage"]?.ToString());
        }
        else if (selectionStatus == 2)
        {
            await passengerRepo.EnableSelectionAsync(Hash.DecodeToInt(flightRouteAmenityId),
                Hash.DecodeToInt(passengerId));
            TempData["SuccessMessage"] = L["successfully-added"].Value;
            TempData.Keep();
        }

        return RedirectToAction("Services", new { passengerId, FlightRouteId });
    }
}