using Charcillaries.Core;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Passenger.Flights;

public class Feedback(
    IPassengerRepository passengerManagementRepository,
    IValidator<RouteFlightFeedbackNewInput> routeFlightFeedbackNewInputValidator,
    IValidator<RouteAmenityFeedbackNewCollectionInput> routeAmenityFeedbackNewCollectionInputValidator,
    IValidator<RouteAmenityFeedbackUpdateCollectionInput> routeAmenityFeedbackUpdateCollectionInputValidator
) : PageModel
{
    public PassengerFlightDetailsView? PassengerFlightDetailsView { get; set; }

    public RouteFlightFeedbackMinimalView? RouteFlightFeedbackMinimalView { get; set; }

    public Dictionary<int, AmenityFeedbackMinimalView> AmenityFeedbackMinimalView { get; set; } = [];

    [BindProperty] public RouteFlightFeedbackNewInput RouteFlightFeedback { get; set; } = new();

    [BindProperty] public RouteAmenityFeedbackNewCollectionInput RouteAmenityFeedbackNew { get; set; } = new();
    [BindProperty] public RouteAmenityFeedbackUpdateCollectionInput RouteAmenityFeedbackUpdate { get; set; } = new();

    [BindProperty] public string FlightId { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string passengerId)
    {
        var decodedPassengerId = Hash.DecodeToInt(passengerId);
        PassengerFlightDetailsView =
            await passengerManagementRepository.GetPassengerAsync(decodedPassengerId);
        if (PassengerFlightDetailsView == null)
            return NotFound();

        RouteFlightFeedbackMinimalView = await passengerManagementRepository
            .GetRouteFlightFeedbackMinimalAsync(decodedPassengerId);
        AmenityFeedbackMinimalView = await passengerManagementRepository
            .GetAmenityFeedbackMinimalAsync(decodedPassengerId);

        RouteFlightFeedback.Comment = RouteFlightFeedbackMinimalView?.Comment;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string passengerId)
    {
        var decodedPassengerId = Hash.DecodeToInt(passengerId);

        RouteFlightFeedback.PassengerId = decodedPassengerId;
        RouteFlightFeedback.FlightId = Hash.DecodeToInt(FlightId);
        RouteAmenityFeedbackNew.RouteAmenityFeedbacksList.RemoveAll(x => x.Rating == null);
        RouteAmenityFeedbackUpdate.RouteAmenityFeedbacksList.RemoveAll(x => x.Rating == null);
        RouteAmenityFeedbackNew.RouteAmenityFeedbacksList.ForEach(routeAmenity =>
            routeAmenity.PassengerId = decodedPassengerId);
        RouteAmenityFeedbackUpdate.RouteAmenityFeedbacksList.ForEach(routeAmenity =>
            routeAmenity.PassengerId = decodedPassengerId);

        var flightFeedbackValidationResult =
            await routeFlightFeedbackNewInputValidator.ValidateAsync(RouteFlightFeedback);
        var amenityFeedbackValidationNewResult =
            await routeAmenityFeedbackNewCollectionInputValidator.ValidateAsync(RouteAmenityFeedbackNew);
        var amenityFeedbackValidationUpdateResult =
            await routeAmenityFeedbackUpdateCollectionInputValidator.ValidateAsync(RouteAmenityFeedbackUpdate);

        flightFeedbackValidationResult.AddToModelState(ModelState, nameof(RouteFlightFeedback));
        amenityFeedbackValidationNewResult.AddToModelState(ModelState, nameof(RouteAmenityFeedbackNew));
        amenityFeedbackValidationUpdateResult.AddToModelState(ModelState, nameof(RouteAmenityFeedbackUpdate));

        if (!ModelState.IsValid)
        {
            PassengerFlightDetailsView = await passengerManagementRepository.GetPassengerAsync(decodedPassengerId);
            if (PassengerFlightDetailsView == null)
                return NotFound();

            RouteFlightFeedbackMinimalView = await passengerManagementRepository
                .GetRouteFlightFeedbackMinimalAsync(decodedPassengerId);
            AmenityFeedbackMinimalView = await passengerManagementRepository
                .GetAmenityFeedbackMinimalAsync(decodedPassengerId);

            RouteFlightFeedback.Comment = RouteFlightFeedbackMinimalView?.Comment;
            return Page();
        }

        // Save feedback
        if (RouteFlightFeedback.Rating.HasValue)
            await passengerManagementRepository.SaveRouteFlightFeedbackAsync(RouteFlightFeedback);

        if (RouteAmenityFeedbackNew.RouteAmenityFeedbacksList.Count != 0)
            await passengerManagementRepository.SaveRouteAmenityFeedbackCollectionAsync(RouteAmenityFeedbackNew);

        if (RouteAmenityFeedbackUpdate.RouteAmenityFeedbacksList.Count != 0)
            await passengerManagementRepository.SaveRouteAmenityFeedbackCollectionAsync(RouteAmenityFeedbackUpdate);

        return Redirect("/passenger/flights/past-flights");
    }
}