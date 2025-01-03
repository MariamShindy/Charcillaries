using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Routes;

public class AddModel(
    IAirlineRepository repo,
    ILogger<AddModel> logger,
    IValidator<RouteNewInput> validator,
    IStringLocalizer<Global> L) : PageModel
{
    [BindProperty] public RouteNewInput Route { get; set; } = new();
    [BindProperty] public RouteAmenityNewInput RouteAmenity { get; set; } = new();
    public List<string> Airports { get; set; } = [];
    public List<AmenitiesDetailsView> Amenities { get; set; } = [];
    public List<ServiceData> serviceData { get; set; } = [];

    [BindProperty]
    public string ServiceId { get; set; } = string.Empty;

    [BindProperty]
    public float ServicePrice { get; set; } = 0.0f;

    public async Task<IActionResult> OnGetAsync()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        Airports = await repo.GetAirportsAsync();
        Amenities = await repo.GetAmenitiesAsync(airlineId);
        Route.AirlineId = airlineId;

        var existingServices = TempData["ServiceData"] as string;
        if (!string.IsNullOrEmpty(existingServices))
        {
            serviceData = JsonConvert.DeserializeObject<List<ServiceData>>(existingServices) ?? new List<ServiceData>();
            TempData.Keep("ServiceData");
        }
        else
        {
            serviceData = new List<ServiceData>();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        logger.LogInformation("adding route");
        var existingServices = TempData["ServiceData"] as string;
        if (!string.IsNullOrEmpty(existingServices))
        {
            serviceData = JsonConvert.DeserializeObject<List<ServiceData>>(existingServices) ?? new List<ServiceData>();
            TempData.Keep("ServiceData");
        }
        else
        {
            serviceData = new List<ServiceData>();
        }

        Route.AirlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        var validationResult = await validator.ValidateAsync(Route);
        validationResult.AddToModelState(ModelState, nameof(Route));
        var routeExists = await repo.CheckExisitngRoute(Route.DepartureAirport, Route.ArrivalAirport, Route.AirlineId);
        if (routeExists)
        {
            ModelState.AddModelError(string.Empty, L["route-exists"]);
        }
        if (!ModelState.IsValid)
        {
            Airports = await repo.GetAirportsAsync();
            Amenities = await repo.GetAmenitiesAsync(Route.AirlineId);

            logger.LogInformation("not valid");
            return Page();
        }

        foreach (var service in serviceData)
        {
            var duplicateServices = serviceData.Count(s => s.ServiceId == service.ServiceId);
            if (duplicateServices > 1)
            {
                ModelState.AddModelError(string.Empty, "You cannot add the same service more than one time.");
            }
            if (!ModelState.IsValid)
            {
                Airports = await repo.GetAirportsAsync();
                Amenities = await repo.GetAmenitiesAsync(Route.AirlineId);

                logger.LogInformation("not valid");
                return Page();
            }
        }
        var routeId = await repo.SaveRouteAsync(Route);
        logger.LogInformation($"RouteId: {routeId}");
        foreach (var service in serviceData)
        {
            logger.LogInformation("entred");

            RouteAmenity.AmenityId = service.ServiceId;
            RouteAmenity.Price = service.Price;
            RouteAmenity.FlightRouteId = routeId;
            var result = await repo.SaveRouteAmenityAsync(RouteAmenity);
        }
        TempData.Remove("ServiceData");
        return Redirect("/airline/routes/enabled");
    }

    public async Task<IActionResult> OnPostServices()
    {
        logger.LogInformation("adding services to the route");
        var existingServices = TempData["ServiceData"] as string;
        if (!string.IsNullOrEmpty(existingServices))
        {
            serviceData = JsonConvert.DeserializeObject<List<ServiceData>>(existingServices) ?? new List<ServiceData>();
        }
        var serviceId = Hash.DecodeToInt(ServiceId);
        await FetchServicesData(serviceId, ServicePrice);
        TempData["ServiceData"] = JsonConvert.SerializeObject(serviceData);
        logger.LogInformation($"Fetched {serviceData.Count} serviceData items.");
        return Partial("_SelectedServices", serviceData);
    }

    private async Task<List<ServiceData>> FetchServicesData(int serviceId, float price)
    {
        logger.LogInformation($"Fetch services data: {serviceId}");
        logger.LogInformation($"Fetch services data: {price}");
        var service = await repo.GetAmenityAsync(serviceId);
        if (service == null)
        {
            return new List<ServiceData>();
        }

        serviceData.Add(new ServiceData
        {
            ServiceName = service.Name,
            Price = price,
            ServiceId = serviceId
        });
        logger.LogInformation($"ReportData has {serviceData.Count} items.");
        if (serviceData?.Count() > 0)
            return serviceData;
        return new List<ServiceData>();
    }

    public IActionResult OnPostDelete(string serviceId)
    {
        logger.LogInformation("deleting");
        if (TempData["ServiceData"] != null)
        {
            var existingServices = TempData["ServiceData"] as string;

            if (!string.IsNullOrEmpty(existingServices))
            {
                serviceData = JsonConvert.DeserializeObject<List<ServiceData>>(existingServices) ?? new List<ServiceData>();
            }
        }
        else
        {
            logger.LogWarning("No service data found in TempData.");
        }

        var service = serviceData.FirstOrDefault(s => s.ServiceId == Hash.DecodeToInt(serviceId));
        logger.LogInformation($"deleteing this service{serviceId}");
        if (service != null)
        {
            logger.LogInformation($"deleteing this service{serviceId}");
            serviceData.Remove(service);
            TempData["ServiceData"] = JsonConvert.SerializeObject(serviceData);
        }
        return Content("");
    }

    public class ServiceData
    {
        public string ServiceName { get; set; } = string.Empty;
        public int ServiceId { get; set; }
        public float Price { get; set; } = 0.0f;
    }
}