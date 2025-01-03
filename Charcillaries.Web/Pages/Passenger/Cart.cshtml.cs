using Charcillaries.Core;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Passenger;

public class CartModel(
    ILogger<CartModel> logger,
    IPassengerRepository passengerManagementRepository) : PageModel
{
    public double TotalPrice;
    public List<PassengerAmenityListView> PassengerAmenities { get; set; } = [];
    public PassengerFlightDetailsView? Passenger { get; set; }
    public Dictionary<int, double> ItemsPrice { get; set; } = new();
    public int CartItems { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var personId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        logger.LogInformation("person with ID: {personId}", personId);
        PassengerAmenities = await passengerManagementRepository.GetCartItemsAsync(personId);
        CartItems = await passengerManagementRepository.GetNumberOfCartItemsAsync(personId);
        if (PassengerAmenities.Count == 0)
        {
            logger.LogInformation("empty list");
        }

        foreach (var amenity in PassengerAmenities.Where(amenity => amenity.Confirmed == 0))
        {
            logger.LogInformation(amenity.RouteAmenity.Amenity.Name);
            logger.LogInformation(amenity.AmenityId.ToString());
            logger.LogInformation(amenity.Passenger.Flight.FlightRouteId.ToString());
            logger.LogInformation(amenity.RouteAmenity.Id.ToString());
            var price = await passengerManagementRepository.GetPassengerAmenityPriceAsync(amenity.RouteAmenity.Id);
            logger.LogInformation(price.ToString());
            price = Math.Round(price, 2);
            TotalPrice += price;
            ItemsPrice[amenity.Id] = price;
        }

        TotalPrice = Math.Round(TotalPrice, 2);
        logger.LogInformation(TotalPrice.ToString());
        logger.LogInformation("Items are fetched successfully");
        return Page();
    }

    public async Task<IActionResult> OnPostRemoveAsync(string id)
    {
        logger.LogInformation("Attempting to delete selection with ID: {selectionId}", id);
        await passengerManagementRepository.RemovePassengerAmenityAsync(Hash.DecodeToInt(id));
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCheckoutAsync()
    {
        var personId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        logger.LogInformation("Checkout process started.");
        Passenger = await passengerManagementRepository.GetPersonAsync(personId);
        PassengerAmenities = await passengerManagementRepository.GetCartItemsAsync(personId);
        if (Passenger == null)
        {
            logger.LogError("Passenger object is null.");
            return BadRequest("Passenger is not available.");
        }

        foreach (var amenity in PassengerAmenities)
        {
            logger.LogInformation($"Processing amenity ID: {amenity.Id}");
            await passengerManagementRepository.ConfirmPassengerSelectionAsync(amenity.Id);
        }

        logger.LogInformation("Redirecting to the Confirmation page.");
        return RedirectToPage("/passenger/confirmation", new { personId });
    }
}