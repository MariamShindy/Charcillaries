using Charcillaries.Core;
using Charcillaries.Core.Features.Flight;
using Charcillaries.Core.Features.Passenger;
using Charcillaries.Core.Features.Service;
using Charcillaries.Core.Features.TourOperator;
using Charcillaries.Data.Views.DtoClasses;
using Charcillaries.Web.HtmlHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Passenger.Flights;

public class UpcomingFlightsModel(
    ILogger<UpcomingFlightsModel> logger,
    IPassengerRepository passengerManagementRepository,
    ITourOperatorRepository tourOperatorRepository,
    IFlightRepository flightRepository,
    IStringLocalizer<FlightLocalization> LF,
    IStringLocalizer<Global> L,
    IStringLocalizer<ServiceLocalization> LS,
    IStringLocalizer<PassengerLocalization> LP
) : PageModel
{
    public List<PassengerFlightListView> Passengers { get; set; } = [];
    public List<TourOperatorDetailsView> TourOperators { get; set; } = [];

    [BindProperty] public string FlightNumber { get; set; } = string.Empty;
    [BindProperty] public string TourOperatorId { get; set; } = string.Empty;
    [BindProperty] public DateTime DepartureDate { get; set; } = DateTime.Now;

    [BindProperty] public string FlightId { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(string? sort)
    {
        var personId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        Passengers = await passengerManagementRepository.GetUpcomingFlightsAsync(personId);
        logger.LogInformation("Passengers are fetched successfully");
        Passengers = sort switch
        {
            "dateAsc" => Passengers.OrderBy(p => p.Flight.ArrivalDate).ToList(),
            "dateDes" => Passengers.OrderByDescending(p => p.Flight.ArrivalDate).ToList(),
            "destinationAsc" => Passengers.OrderBy(p => p.Flight.FlightRoute.ArrivalAirport).ToList(),
            "destinationDes" => Passengers.OrderByDescending(p => p.Flight.FlightRoute.ArrivalAirport).ToList(),
            _ => Passengers
        };

        TourOperators = await tourOperatorRepository.GetTourOperatorsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostFlightNumberAsync()
    {
        var flight = await flightRepository.GetFlightAsync(FlightNumber);

        if (flight != null)
            return Partial("_UpcomingFlight", flight);

        ModelState.AddModelError("FlightNumber", LF["no-flights-available"]);
        return Partial("_FlightNumberValidation", this);
    }

    public async Task<IActionResult> OnPostFlightDateAsync()
    {
        if (DepartureDate < DateTime.Now)
        {
            ModelState.AddModelError("DepartureDate", LF["date-should-be-future"]);
            return Partial("_DepartureDateValidation", this);
        }

        var flights = await flightRepository.GetFlightAsync(Hash.DecodeToInt(TourOperatorId), DepartureDate);

        if (flights.Count != 0)
            return Partial("_UpcomingFlights", flights);

        ModelState.AddModelError("DepartureDate", LF["no-flights-available"]);
        return Partial("_DepartureDateValidation", this);
    }

    public async Task<IActionResult> OnPostAssignSelfAsync()
    {
        var personId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        var decodedFlightId = Hash.DecodeToInt(FlightId);

        var (saved, passengerId) = await passengerManagementRepository.SavePassengerAsync(personId, decodedFlightId);

        if (!saved)
        {
            ModelState.AddModelError("FlightId",
                passengerId != -2 ? LF["no-flights-available"] : LP["already-assigned"]);

            Response.StatusCode = 201;
            return Partial("_SelfAssignValidations", this);
        }

        var flight = await flightRepository.GetFlightAsync(decodedFlightId);

        var html = $"""
                    <div class="col-12 mb-4">
                        <div class="card h-100 card-silver shadow-sm">
                            <div class="card-header fs-5 fw-bold blue-text">
                                {LF["flight"]} {flight!.FlightNumber}
                            </div>
                            <div class="card-body">
                                <div class="d-flex flex-column flex-md-row justify-content-between align-items-start align-items-md-center">
                                    <div>
                                        <p class="card-text">
                                            <strong>
                                                {LF["from"]}
                                                :
                                            </strong>{flight.FlightRoute.DepartureAirport}
                                            <strong>
                                                || {LF["to"]}
                                                :
                                            </strong>{flight.FlightRoute.ArrivalAirport}
                                        </p>
                                        <p class="card-text">
                                            <strong>
                                                {LF["departure"]}
                                                :
                                            </strong>{Arabic.ConvertToArabicDigitsByCulture(flight.DepartureDate.ToString("h:mm tt"), CultureInfo.CurrentCulture.Name)}
                                            <strong>
                                                {LF["arrival"]}
                                                :
                                            </strong>{Arabic.ConvertToArabicDigitsByCulture(flight.ArrivalDate.ToString("h:mm tt"), CultureInfo.CurrentCulture.Name)}
                                        </p>
                                        <p class="card-text">
                                            <strong>
                                                {L["date"]}
                                                :
                                            </strong> {Arabic.ConvertToArabicDigitsByCulture(flight.DepartureDate.ToString("dd/MM/yyyy"), CultureInfo.CurrentCulture.Name)}
                                        </p>
                                    </div>
                                    <div class="d-flex flex-column mt-3 mt-md-0">
                                        <a href="/passenger/flights/{Hash.EncodeInt(passengerId)}" class="btn blue-button mb-2">
                                            {LF["flight-details"]}
                                        </a>
                                        <a href="/passenger/{Hash.EncodeInt(passengerId)}/flights/{Hash.EncodeInt(flight.FlightRoute.Id)}/services"
                                           class="btn blue-button">
                                            {LS["browse-services"]}
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    """;
        return Content(html);
    }
}