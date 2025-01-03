using Charcillaries.Core.Features.Images;
using Charcillaries.Data.DatabaseSpecific;
using Charcillaries.Data.EntityClasses;
using Charcillaries.Data.Views.DtoClasses;
using Charcillaries.Data.Views.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Charcillaries.Core.Features.Airline;

public interface IAirlineRepository
{
    Task<bool> SaveAirlineAsync(AirlineNewInput input);

    Task<int> GetNumberOfEnabledAmenitiesAsync(int airlineId);

    Task<int> GetNumberOfRoutesAsync(int airlineId);

    Task<int> GetNumberOfUpcomingFlightsAsync(int airlineId);

    Task<int> GetNumberOfRouteEnabledServicesAsync(int routeId);

    Task<List<AmenitiesDetailsView>> GetAmenitiesAsync(int airlineId, int objectStatus = Constants.ObjectStatus.Active);

    Task<List<AmenitiesListView>> GetReportAmenitiesAsync(int airlineId, string type);

    Task<List<RouteAmenityListView>> GetRouteAmenities(int routeId, int objectStatus = Constants.ObjectStatus.Active);

    Task<List<RouteAmenityListView>> GetRouteAmenitiesByAirline(int airlineId,
        int objectStatus = Constants.ObjectStatus.Active);

    Task<RouteAmenityDetailsView?> GetRouteAmenity(int routeAmenityId);

    Task<bool> SaveAirlineAsync(AirlineUpdateInput input);

    Task<List<AmenityFeedbackDetailsView>> GetAmenityFeedbackAsync(int airlineId, int serviceId);

    Task<List<RouteFlightFeedbackDetailsView>> GetFlightFeedbackAsync(int airlineId, int flightId);

    Task<bool> SaveAmenityAsync(AmenityNewInput input);

    Task<bool> SaveAmenityAsync(AmenityUpdateInput input);

    Task<int> SaveRouteAsync(RouteNewInput input);

    Task<bool> SaveRouteAsync(RouteUpdateInput input);

    Task<bool> SaveRouteAmenityAsync(RouteAmenityNewInput input);

    Task<bool> SaveRouteAmenityAsync(RouteAmenityUpdateInput input);

    Task<AmenitiesDetailsView?> GetAmenityAsync(int serviceId);

    Task<AirlineDetailsView?> GetAirlineAsync(int airlineId);

    Task<List<AirlineListView>> GetAirlinesAsync(int pageNo = 1, int pageSize = Constants.CommonPageSize);

    Task RemoveAirlineAsync(int airlineId);

    Task DisableAirlineRouteAsync(int routeId);

    Task EnableAirlineServiceAsync(int amenityId);

    Task DisableAirlineServiceAsync(int amenityId);

    Task EnableAirlineRouteAsync(int routeId);

    Task CancelAirlineFlight(int flightId);

    Task<int> GetNumberOfAirlines();

    Task<List<FlightRouteListView>> GetAirlineRoutesAsync(int airlineId,
        int objectStatus = Constants.ObjectStatus.Active);

    Task<FlightRouteDetailsView?> GetAirlineRouteDetailsAsync(int routeId);

    Task<List<string>> GetAirportsAsync();

    Task<List<FlightRouteListView>> GetUniqueRoutesAsync();

    Task<List<FlightRouteListView>> GetAllAirlineRoutesAsync(int airlineId);

    Task<bool> CheckExisitngRoute(string departureAirport, string arrivalAirport, int airlineId);

    Task<string> CheckExistingAmenity(int routeId, int amenityId);

    Task DisableRouteAmenityAsync(int routeAmenityId);

    Task EnableRouteAmenityAsync(int routeAmenityId);

    Task<float> GetAmenityRevenue(int amenityId);

    Task<int> CheckRouteAmenityStatus(int amenityId, int routeId);

    Task<bool> DeleteAmenityImageAsync(int serviceId);

    Task<int> GetAmenitySelections(int amenityId);

    Task<float> GetAmenityAverageRating(int amenityId);
}

public class AirlineNewInput()
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;

    public AirlineEntity ToEntity()
    {
        return new AirlineEntity
        {
            Name = Name,
            Email = Email,
            ContactInfo = ContactInfo
        };
    }

    public class Validator : AbstractValidator<AirlineNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(L["name-required"])
                .MaximumLength(100).WithMessage(L["name-max-length"]);
            RuleFor(x => x.Email).NotEmpty().WithMessage(L["email-required"])
                .EmailAddress().WithMessage(L["email-invalid"])
                .MaximumLength(255).WithMessage(L["email-max-length"]);
            RuleFor(x => x.ContactInfo).NotEmpty().WithMessage(L["contact-info-required"])
                .MinimumLength(10).WithMessage(L["contact-info-min-length"])
                .MaximumLength(30).WithMessage(L["contact-info-max-length"])
                .Matches(@"^\d+$").WithMessage(L["contact-info-numeric"]);
        }
    }
}

public class AirlineUpdateInput
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;

    public AirlineEntity ToEntity()
    {
        return new AirlineEntity
        {
            Id = Id,
            Name = Name,
            Email = Email,
            ContactInfo = ContactInfo,
            IsNew = false
        };
    }

    public class Validator : AbstractValidator<AirlineUpdateInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(L["name-required"])
                .MaximumLength(100).WithMessage(L["name-max-length"]);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(L["email-required"])
                .EmailAddress().WithMessage(L["email-invalid"])
                .MaximumLength(255).WithMessage(L["email-max-length"]);
            RuleFor(x => x.ContactInfo)
                .NotEmpty().WithMessage(L["contact-info-required"])
                .MinimumLength(10).WithMessage(L["contact-info-min-length"])
                .MaximumLength(30).WithMessage(L["contact-info-max-length"])
                .Matches(@"^\d+$").WithMessage(L["contact-info-numeric"]);
        }
    }
}

public class AmenityNewInput
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public IFormFile? Icon { get; set; }
    public int AirlineId { get; set; }

    public AmenityEntity ToEntity()
    {
        return new AmenityEntity
        {
            AirlineId = AirlineId,
            Name = Name,
            Description = Description
        };
    }

    public class Validator : AbstractValidator<AmenityNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(L["name-required"])
                .MaximumLength(30).WithMessage(L["name-max-length"]);
            RuleFor(x => x.Description).NotEmpty().WithMessage(L["description-required"])
                .MinimumLength(10).WithMessage(L["description-min-length"]);
            RuleFor(x => x.Icon)
                .Custom((icon, context) =>
                {
                    if (icon is null)
                        return;

                    var allowedExtensions = new[] { "jpg", "jpeg", "png", "webp" };
                    var extension = icon?.ContentType.Split("/")[1];
                    if (!allowedExtensions.Contains(extension))
                        context.AddFailure("Icon", "Icon must be a jpg, jpeg, png or webp file");
                });
        }
    }
}

public class AmenityUpdateInput
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public IFormFile? Icon { get; set; }

    public Guid? IconGuid { get; set; }

    public AmenityEntity ToEntity()
    {
        return new AmenityEntity
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Icon = IconGuid ?? (Icon is not null ? Guid.NewGuid() : null),
            IsNew = false
        };
    }

    public class Validator : AbstractValidator<AmenityUpdateInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(L["name-required"])
                .MaximumLength(30).WithMessage(L["name-max-length"]);
            RuleFor(x => x.Description).NotEmpty().WithMessage(L["description-required"])
                .MinimumLength(10).WithMessage(L["description-min-length"]);
            RuleFor(x => x.Icon)
                .Custom((icon, context) =>
                {
                    if (icon is null)
                        return;
                    var allowedExtensions = new[] { "jpg", "jpeg", "png", "webp" };
                    var extension = icon?.ContentType.Split("/")[1];
                    if (!allowedExtensions.Contains(extension))
                        context.AddFailure("Icon", "Icon must be a jpg, jpeg, png or webp file");
                });
        }
    }
}

public class RouteNewInput
{
    public string DepartureAirport { get; set; } = string.Empty;
    public string ArrivalAirport { get; set; } = string.Empty;
    public int AirlineId { get; set; }

    public FlightRouteEntity ToEntity()
    {
        var flightRouteEntity = new FlightRouteEntity
        {
            DepartureAirport = DepartureAirport,
            ArrivalAirport = ArrivalAirport,
            AirlineId = AirlineId,
        };
        return flightRouteEntity;
    }

    public class Validator : AbstractValidator<RouteNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.ArrivalAirport)
                .NotEmpty().WithMessage(L["arrival-airport-required"]);
            RuleFor(x => x.DepartureAirport)
                .NotEmpty().WithMessage(L["departure-airport-required"])
                .NotEqual(x => x.ArrivalAirport)
                .WithMessage(L["same-airport"]);
        }
    }
}

public class RouteUpdateInput
{
    public int Id { get; set; }
    public string DepartureAirport { get; set; } = string.Empty;
    public string ArrivalAirport { get; set; } = string.Empty;
    public int AirlineId { get; set; }

    public FlightRouteEntity ToEntity()
    {
        var flightRouteEntity = new FlightRouteEntity
        {
            Id = Id,
            DepartureAirport = DepartureAirport,
            ArrivalAirport = ArrivalAirport,
            IsNew = false
        };
        return flightRouteEntity;
    }

    public class Validator : AbstractValidator<RouteUpdateInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.ArrivalAirport)
                .NotEmpty().WithMessage(L["arrival-airport-required"]);
            RuleFor(x => x.DepartureAirport)
                .NotEmpty().WithMessage(L["departure-airport-required"])
                .NotEqual(x => x.ArrivalAirport)
                .WithMessage(L["same-airport"]);
        }
    }
}

public class RouteAmenityNewInput
{
    public int FlightRouteId { get; set; }
    public int AmenityId { get; set; }
    public float Price { get; set; }

    public RouteAmenityEntity ToEntity()
    {
        var routeAmenityEntity = new RouteAmenityEntity
        {
            FlightRouteId = FlightRouteId,
            AmenityId = AmenityId,
            Price = Price
        };
        return routeAmenityEntity;
    }

    public class Validator : AbstractValidator<RouteAmenityNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.AmenityId).NotEmpty().WithMessage("Please select a service");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(1.0f).WithMessage(L["price-validation"]).NotEmpty()
                .WithMessage(L["price-empty"]);
        }
    }
}

public class RouteAmenityUpdateInput
{
    public int Id { get; set; }
    public int FlightRouteId { get; set; }
    public int AmenityId { get; set; }
    public float Price { get; set; }

    public RouteAmenityEntity ToEntity()
    {
        var routeAmenityEntity = new RouteAmenityEntity
        {
            Id = Id,
            FlightRouteId = FlightRouteId,
            AmenityId = AmenityId,
            Price = Price,
            IsNew = false
        };
        return routeAmenityEntity;
    }

    public class Validator : AbstractValidator<RouteAmenityUpdateInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.AmenityId).NotEmpty().WithMessage("Please select a service");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(1.0f).WithMessage(L["price-validation"]).NotEmpty()
                .WithMessage(L["price-empty"]);
        }
    }
}

public class AirlineManagementRepository(
    DataAccessAdapter adapter,
    ILogger<AirlineManagementRepository> logger,
    IImageService imageService)
    : BaseRepository(adapter), IAirlineRepository
{
    public Task<bool> SaveAirlineAsync(AirlineNewInput input)
    {
        var entity = input.ToEntity();
        return _adapter.SaveEntityAsync(entity);
    }

    public async Task<bool> SaveAmenityAsync(AmenityNewInput input)
    {
        var entity = input.ToEntity();
        if (input.Icon == null)
            return await _adapter.SaveEntityAsync(entity);

        var fileName = await imageService.UploadImage(input.Icon);
        entity.Icon = Guid.Parse(fileName);
        return await _adapter.SaveEntityAsync(entity);
    }

    public async Task<bool> SaveAmenityAsync(AmenityUpdateInput input)
    {
        var entity = input.ToEntity();
        input.IconGuid = entity.Icon;

        var saved = await _adapter.SaveEntityAsync(entity);
        if (input.Icon == null)
            return saved;

        var fileUploaded = await imageService.UploadImage(input.Icon, input.IconGuid.ToString()!);

        return saved && fileUploaded;
    }

    public Task<bool> SaveAirlineAsync(AirlineUpdateInput input)
    {
        var entity = input.ToEntity();
        return _adapter.SaveEntityAsync(entity);
    }

    public async Task<int> SaveRouteAsync(RouteNewInput input)
    {
        var entity = input.ToEntity();
        logger.LogInformation("id {id}", entity.Id);
        await _adapter.SaveEntityAsync(entity);
        return entity.Id;
    }

    public Task<bool> SaveRouteAsync(RouteUpdateInput input)
    {
        var entity = input.ToEntity();
        logger.LogInformation("id {id}", entity.Id);
        return _adapter.SaveEntityAsync(entity);
    }

    public async Task<bool> SaveRouteAmenityAsync(RouteAmenityNewInput input)
    {
        var entity = input.ToEntity();
        var existingRecord = await _meta.RouteAmenity
            .FirstOrDefaultAsync(ra => ra.FlightRouteId == input.FlightRouteId && ra.AmenityId == input.AmenityId);
        return await _adapter.SaveEntityAsync(entity);
    }

    public async Task<bool> SaveRouteAmenityAsync(RouteAmenityUpdateInput input)
    {
        var entity = input.ToEntity();
        var existingRecord = await _meta.RouteAmenity
            .FirstOrDefaultAsync(ra => ra.FlightRouteId == input.FlightRouteId && ra.AmenityId == input.AmenityId);
        return await _adapter.SaveEntityAsync(entity);
    }

    public async Task<int> GetNumberOfEnabledAmenitiesAsync(int airlineId)
    {
        var query = await _meta.Amenity
            .Where(a => a.ObjectStatus == Constants.ObjectStatus.Active && a.AirlineId == airlineId).CountAsync();
        return query;
    }

    public async Task<AirlineDetailsView?> GetAirlineAsync(int airlineId)
    {
        var query = await _meta.Airline.Where(a => a.Id == airlineId).ProjectToAirlineDetailsView()
            .FirstOrDefaultAsync();
        return query;
    }

    public async Task<int> GetNumberOfRoutesAsync(int airlineId)
    {
        var query = await _meta.FlightRoute
            .Where(f => f.ObjectStatus == Constants.ObjectStatus.Active && f.AirlineId == airlineId).CountAsync();
        return query;
    }

    public async Task<int> GetNumberOfUpcomingFlightsAsync(int airlineId)
    {
        var query = await _meta.Flight.Where(
                f => f.FlightRoute.AirlineId == airlineId &&
                     f.DepartureDate > DateTime.Now &&
                     f.ObjectStatus == Constants.ObjectStatus.Active)
            .CountAsync();
        return query;
    }

    public async Task<List<AirlineListView>> GetAirlinesAsync(int pageNo = 1, int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.Airline.Where(a => a.ObjectStatus == Constants.ObjectStatus.Active)
            .TakePage(pageNo, pageSize)
            .ProjectToAirlineListView()
            .ToListAsync();
        return query;
    }

    public async Task<List<AmenitiesDetailsView>> GetAmenitiesAsync(int airlineId,
        int objectStatus = Constants.ObjectStatus.Active)
    {
        var query = await _meta.Amenity.Where(a => a.ObjectStatus == objectStatus && a.AirlineId == airlineId)
            .ProjectToAmenitiesDetailsView().ToListAsync();
        return query;
    }

    //public Task<List<AmenitiesDetailsView>> GetReportAmenitiesAsync(int airlineId, string type)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<List<AmenitiesListView>> GetReportAmenitiesAsync(int airlineId, string type)
    {
        var query = _meta.Amenity
            .Where(a => a.AirlineId == airlineId)
            .Where(a => a.RouteAmenities
                .Any(ra => ra.PassengerAmenitySelections
                    .Any(pas => pas.Confirmed == 1)));
        var amenities = await query
            .ProjectToAmenitiesListView()
            .ToListAsync();
        if (type == "TopSelected")
        {
            return amenities;
        }
        else if (type == "TopRated")
        {
            amenities = amenities
                .Where(a => a.AmenityFeedbacks.Any()).ToList();
        }

        return amenities;
    }

    public async Task<AmenitiesDetailsView?> GetAmenityAsync(int serviceId)
    {
        var query = await _meta.Amenity.Where(a => a.Id == serviceId).ProjectToAmenitiesDetailsView()
            .FirstOrDefaultAsync();
        return query;
    }

    public async Task<List<AmenityFeedbackDetailsView>> GetAmenityFeedbackAsync(int airlineId, int serviceId)
    {
        var query = await _meta.AmenityFeedback
            .Where(a => a.AmenityId == serviceId && a.ObjectStatus == Constants.ObjectStatus.Active &&
                        a.Amenity.AirlineId == airlineId).ProjectToAmenityFeedbackDetailsView()
            .ToListAsync();
        return query;
    }

    public async Task<List<RouteFlightFeedbackDetailsView>> GetFlightFeedbackAsync(int airlineId, int flightId)
    {
        var query = await _meta.RouteFlightFeedback
            .Where(f => f.FlightId == flightId && f.ObjectStatus == Constants.ObjectStatus.Active &&
                        f.Flight.FlightRoute.AirlineId == airlineId).ProjectToRouteFlightFeedbackDetailsView()
            .ToListAsync();
        return query;
    }

    public async Task RemoveAirlineAsync(int airlineId)
    {
        var airline = await _meta.Airline.FirstOrDefaultAsync(a => a.Id == airlineId);
        if (airline == null)
        {
            logger.LogWarning("Airline with ID: {AirlineId} not found", airlineId);
        }
        else
        {
            airline.ObjectStatus = Constants.ObjectStatus.Disabled;
            await _adapter.SaveEntityAsync(airline, true);
            logger.LogInformation("Successfully marked airline with ID: {AirlineId} as deleted", airlineId);
        }
    }

    public async Task DisableRouteAmenityAsync(int routeAmenitiyId)
    {
        var routeAmenity = await _meta.RouteAmenity.FirstOrDefaultAsync(a => a.Id == routeAmenitiyId);
        if (routeAmenity == null)
        {
            logger.LogWarning("route amenity with ID: {routeAmenitiyId} not found", routeAmenitiyId);
        }
        else
        {
            routeAmenity.ObjectStatus = Constants.ObjectStatus.Disabled;
            await _adapter.SaveEntityAsync(routeAmenity, true);
            logger.LogInformation("Successfully marked route Amenity with ID: {routeAmenityID} as deleted",
                routeAmenitiyId);
        }
    }

    public async Task EnableRouteAmenityAsync(int routeAmenitiyId)
    {
        var routeAmenity = await _meta.RouteAmenity.FirstOrDefaultAsync(a => a.Id == routeAmenitiyId);
        if (routeAmenity == null)
        {
            logger.LogWarning("route amenity with ID: {routeAmenitiyId} not found", routeAmenitiyId);
        }
        else
        {
            routeAmenity.ObjectStatus = Constants.ObjectStatus.Active;
            await _adapter.SaveEntityAsync(routeAmenity, true);
            logger.LogInformation("Successfully marked route Amenity with ID: {routeAmenityID} as enabled",
                routeAmenitiyId);
        }
    }

    public async Task<float> GetAmenityRevenue(int amenityId)
    {
        var confirmedSelectionsQuery = _meta.PassengerAmenitySelection
            .Where(ps =>
                ps.RouteAmenity.AmenityId == amenityId && ps.Confirmed == Constants.ConfirmationStatus.Confirmed)
            .ProjectToPassengerAmenityListView();
        var confirmedSelections = await confirmedSelectionsQuery.ToListAsync();
        foreach (var selection in confirmedSelections)
        {
            if (selection.RouteAmenity == null)
            {
                // Log or handle the case where RouteAmenity is null
                Console.WriteLine($"Null RouteAmenity found for selection with ID: {selection.Id}");
            }
        }

        var totalRevenue = confirmedSelections
            .Where(ps => ps.RouteAmenity != null) // Filter out null RouteAmenity
            .Sum(ps => ps.RouteAmenity.Price);

        // var totalRevenue = await confirmedSelectionsQuery
        //.SumAsync(ps => ps.RouteAmenity.Price);
        return totalRevenue;
    }

    public async Task DisableAirlineRouteAsync(int routeId)
    {
        var route = await _meta.FlightRoute.FirstOrDefaultAsync(a => a.Id == routeId);
        if (route == null)
        {
            logger.LogWarning("Route with ID: {RouteId} not found", routeId);
        }
        else
        {
            route.ObjectStatus = Constants.ObjectStatus.Disabled;
            await _adapter.SaveEntityAsync(route, true);
            logger.LogInformation("Successfully marked route with ID: {AirlineId} as disabled", routeId);
        }
    }

    public async Task EnableAirlineRouteAsync(int routeId)
    {
        var route = await _meta.FlightRoute.FirstOrDefaultAsync(a => a.Id == routeId);
        if (route == null)
        {
            logger.LogWarning("Route with ID: {RouteId} not found", routeId);
        }
        else
        {
            route.ObjectStatus = Constants.ObjectStatus.Active;
            await _adapter.SaveEntityAsync(route, true);
            logger.LogInformation("Successfully marked route with ID: {AirlineId} as enabled", routeId);
        }
    }

    public async Task<List<FlightRouteListView>> GetAirlineRoutesAsync(int airlineId,
        int objectStatus = Constants.ObjectStatus.Active)
    {
        var query = await _meta.FlightRoute.Where(r => r.ObjectStatus == objectStatus && r.AirlineId == airlineId)
            .ProjectToFlightRouteListView().ToListAsync();
        return query;
    }

    public async Task<int> GetNumberOfRouteEnabledServicesAsync(int routeId)
    {
        var query = await _meta.RouteAmenity
            .Where(a => a.FlightRouteId == routeId && a.Amenity.ObjectStatus == Constants.ObjectStatus.Active &&
                        a.ObjectStatus == Constants.ObjectStatus.Active)
            .CountAsync();
        return query;
    }

    public async Task EnableAirlineServiceAsync(int amenityId)
    {
        var amenity = await _meta.Amenity.FirstOrDefaultAsync(a => a.Id == amenityId);
        if (amenity == null)
        {
            logger.LogWarning("Amenity with ID: {amenityId} not found", amenityId);
        }
        else
        {
            amenity.ObjectStatus = Constants.ObjectStatus.Active;
            await _adapter.SaveEntityAsync(amenity, true);
            logger.LogInformation("Successfully marked amenity with ID: {amenityId} as enabled", amenityId);
        }
    }

    public async Task DisableAirlineServiceAsync(int amenityId)
    {
        var amenity = await _meta.Amenity.FirstOrDefaultAsync(a => a.Id == amenityId);
        if (amenity == null)
        {
            logger.LogWarning("Amenity with ID: {amenityId} not found", amenityId);
        }
        else
        {
            amenity.ObjectStatus = Constants.ObjectStatus.Disabled;
            await _adapter.SaveEntityAsync(amenity, true);
            logger.LogInformation("Successfully marked amenity with ID: {amenityId} as disabled", amenityId);
        }
    }

    public async Task CancelAirlineFlight(int flightId)
    {
        var flight = await _meta.Flight.FirstOrDefaultAsync(f => f.Id == flightId);
        if (flight == null)
        {
            logger.LogWarning("flight with ID: {flightId} not found", flightId);
        }
        else
        {
            flight.ObjectStatus = Constants.ObjectStatus.Disabled;
            await _adapter.SaveEntityAsync(flight, true);
            logger.LogInformation("Successfully marked flight with ID: {flightId} as disabled", flightId);
        }
    }

    public async Task<int> GetNumberOfAirlines()
    {
        var query = await _meta.Airline.Where(t => t.ObjectStatus == Constants.ObjectStatus.Active).CountAsync();
        return query;
    }

    public async Task<FlightRouteDetailsView?> GetAirlineRouteDetailsAsync(int routeId)
    {
        var query = await _meta.FlightRoute.Where(r => r.Id == routeId)
            .ProjectToFlightRouteDetailsView().FirstOrDefaultAsync();
        return query;
    }

    public async Task<List<string>> GetAirportsAsync()
    {
        var departureAirports = await _meta.FlightRoute
            .Select(route => route.DepartureAirport)
            .Distinct()
            .ToListAsync();
        var arrivalAirports = await _meta.FlightRoute
            .Select(route => route.ArrivalAirport)
            .Distinct()
            .ToListAsync();
        var allAirports = departureAirports
            .Union(arrivalAirports)
            .Distinct()
            .OrderBy(airport => airport)
            .ToList();
        return allAirports;
    }

    public async Task<List<FlightRouteListView>> GetUniqueRoutesAsync()
    {
        var uniqueDepartureAirports = await _meta.FlightRoute
            .Where(f => f.ObjectStatus == Constants.ObjectStatus.Active)
            .ProjectToFlightRouteListView()
            .ToListAsync();
        return uniqueDepartureAirports;
    }

    public async Task<List<FlightRouteListView>> GetAllAirlineRoutesAsync(int airlineId)
    {
        var routes = await _meta.FlightRoute
            .Where(f => f.AirlineId == airlineId)
            .ProjectToFlightRouteListView()
            .ToListAsync();
        return routes;
    }

    public async Task<bool> CheckExisitngRoute(string departureAirport, string arrivalAirport, int airlineId)
    {
        var query = await _meta.FlightRoute.FirstOrDefaultAsync(fr =>
            fr.DepartureAirport == departureAirport && fr.ArrivalAirport == arrivalAirport &&
            fr.AirlineId == airlineId);
        return query != null;
    }

    public async Task<string> CheckExistingAmenity(int routeId, int amenityId)
    {
        var routeAmenity = await _meta.RouteAmenity
            .FirstOrDefaultAsync(fr => fr.FlightRouteId == routeId && fr.AmenityId == amenityId);
        string result = string.Empty;
        if (routeAmenity != null)
        {
            if (routeAmenity.ObjectStatus == Constants.ObjectStatus.Disabled)
            {
                result = "This service already exists but disabled for this route.";
            }
            else
            {
                result = "This service already exists in this route.";
            }
        }

        return result;
    }

    public async Task<List<RouteAmenityListView>> GetRouteAmenities(int routeId,
        int objectStatus = Constants.ObjectStatus.Active)
    {
        var query = await _meta.RouteAmenity
            .Where(r => r.FlightRouteId == routeId && r.ObjectStatus == objectStatus &&
                        r.Amenity.ObjectStatus == Constants.ObjectStatus.Active).ProjectToRouteAmenityListView()
            .ToListAsync();
        return query;
    }

    public Task<List<RouteAmenityListView>> GetRouteAmenitiesByAirline(int airlineId,
        int objectStatus = Constants.ObjectStatus.Active)
    {
        var query = _meta.RouteAmenity
            .Where(r => r.Amenity.AirlineId == airlineId && r.ObjectStatus == objectStatus)
            .ProjectToRouteAmenityListView()
            .ToListAsync();

        return query;
    }

    public async Task<RouteAmenityDetailsView?> GetRouteAmenity(int routeAmenityId)
    {
        var query = await _meta.RouteAmenity.Where(r => r.Id == routeAmenityId).ProjectToRouteAmenityDetailsView()
            .FirstOrDefaultAsync();
        return query;
    }

    // public async Task<float> GetAmenityRevenue(int amenityId)
    // {
    //     // ToDO: simplify the query
    //     //var query = _meta.RouteAmenity
    //     //    .Where(p => p.AmenityId == amenityId && p.FlightRoute.Flights.Any(f => f.Passengers.Any(p => p.PassengerAmenitySelections.Count(pas => pas.Confirmed == 1) != 0)));
    //
    //     var query = _meta.RouteAmenity
    //         .Where(ra =>
    //             ra.AmenityId == amenityId && ra.Amenity.PassengerAmenitySelections.Any(pas => pas.Confirmed == 1));
    //
    //     var total = await query
    //         .SumAsync(p => p.Price * p.FlightRoute.Flights
    //             .Sum(f => f.Passengers
    //                 .Count(pas => pas.PassengerAmenitySelections
    //                     .Count(pas => pas.Confirmed == 1) != 0)));
    //     // var total = await query
    //     //.SumAsync(ra => ra.Price * ra.Amenity.PassengerAmenitySelections.Count(pas => pas.Confirmed == 1));
    //
    //     return total;
    // }

    // public async Task<int> GetAmenitySelections(int amenityId)
    // {
    //     var query = _meta.PassengerAmenitySelection.Where(p =>
    //         p.AmenityId == amenityId && p.Confirmed == Constants.ConfirmationStatus.Confirmed);
    //     var timesSelected = await query.CountAsync();
    //     return timesSelected;
    // }

    public async Task<int> CheckRouteAmenityStatus(int amenityId, int routeId)
    {
        var query = await _meta.RouteAmenity.Where(r => r.Amenity.Id == amenityId && r.FlightRouteId == routeId)
            .FirstOrDefaultAsync();
        return query.ObjectStatus;
    }

    public async Task<bool> DeleteAmenityImageAsync(int serviceId)
    {
        var entity = _meta.Amenity.FirstOrDefault(a => a.Id == serviceId);
        if (entity?.Icon is null)
            return false;

        var imageDeleted = await imageService.DeleteImage(entity.Icon.ToString()!);
        if (!imageDeleted)
            return false;

        entity.Icon = null;
        return await _adapter.SaveEntityAsync(entity);
    }

    public async Task<int> GetAmenitySelections(int amenityId)
    {
        var query = _meta.PassengerAmenitySelection.Where(p =>
            p.RouteAmenity.AmenityId == amenityId && p.Confirmed == Constants.ConfirmationStatus.Confirmed);
        var timesSelected = await query.CountAsync();
        return timesSelected;
    }

    public async Task<float> GetAmenityAverageRating(int amenityId)
    {
        var query = _meta.Amenity.Where(a => a.Id == amenityId);
        var averageRating = await query.SelectMany(a => a.AmenityFeedbacks)
            .AverageAsync(f => f.Rating);
        return (float)(averageRating ?? 0);
    }

    public async Task<List<string>> GetAirlineAirportsAsync(int airlineId)
    {
        var departureAirports = await _meta.FlightRoute
            .Where(f => f.AirlineId == airlineId)
            .Select(route => route.DepartureAirport)
            .Distinct()
            .ToListAsync();
        var arrivalAirports = await _meta.FlightRoute
            .Where(f => f.AirlineId == airlineId)
            .Select(route => route.ArrivalAirport)
            .Distinct()
            .ToListAsync();
        var allAirports = departureAirports
            .Union(arrivalAirports)
            .Distinct()
            .OrderBy(airport => airport)
            .ToList();
        return allAirports;
    }
}