using Charcillaries.Data.DatabaseSpecific;
using Charcillaries.Data.EntityClasses;
using Charcillaries.Data.Views.DtoClasses;
using Charcillaries.Data.Views.Persistence;
using FluentValidation;
using Microsoft.Extensions.Localization;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Charcillaries.Core.Features.Flight;

public interface IFlightRepository
{
    Task<FlightDetailsView?> GetFlightAsync(int flightId);

    Task<FlightDetailsView?> GetFlightAsync(string flightNumber);

    Task<List<FlightListView>> GetFlightAsync(int tourOperatorId, DateTime departureDate);

    Task<List<FlightListView>> GetFlightsAsync(int pageNo = 1, int pageSize = Constants.CommonPageSize);

    Task<List<FlightRouteListView>> GetFlightRoutesAsync(int pageNo = 1, int pageSize = Constants.CommonPageSize);

    Task<FlightRouteDetailsView?> GetFlightRouteAmenitiesAsync(int flightId);

    Task<bool> SaveFlightAsync(FlightNewInput input);

    Task<bool> SaveFlightAsync(FlightUpdateInput input);

    Task<List<PassengerListView>> GetPassengersAsync(int flightId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task<FlightPassengersDetailsView?> GetFlightPassengersAsync(int flightId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task<RouteAmenityDetailsView?> GetFlightRouteAmenityAsync(int flightRouteAmenityId);

    Task<List<PassengerListView>> GetPassengersFromSearchAsync(int flightId, string searchTerm, int pageNo = 1,
        int pageSize = Constants.CommonPageSize);
}

public class FlightNewInput
{
    public int NumberOfSeats { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }

    public int FlightRouteId { get; set; }
    public int TourOperatorId { get; set; }

    public FlightEntity ToEntity()
    {
        return new FlightEntity
        {
            FlightNumber = FlightNumber,
            DepartureDate = DepartureDate,
            ArrivalDate = ArrivalDate,
            NumberOfSeats = NumberOfSeats,
            FlightRouteId = FlightRouteId,
            TourOperatorId = TourOperatorId
        };
    }

    public class Validator : AbstractValidator<FlightNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.FlightNumber)
                .NotEmpty().WithMessage(L["flight-number-required"])
                .MaximumLength(10).WithMessage(L["flight-number-max-length"]);

            RuleFor(x => x.DepartureDate)
                .NotEmpty().WithMessage(L["departure-date-required"]);

            RuleFor(x => x.ArrivalDate)
                .NotEmpty().WithMessage(L["arrival-date-required"])
                .GreaterThan(x => x.DepartureDate).WithMessage(L["arrival-date-greater-than-departure"]);

            RuleFor(x => x.NumberOfSeats)
                .NotEmpty().WithMessage(L["number-of-seats-required"])
                .GreaterThanOrEqualTo(0).WithMessage(L["number-of-seats-greater-than-or-equal"]);
        }
    }
}

public class FlightUpdateInput
{
    public int Id { get; set; }
    public int NumberOfSeats { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }

    public int FlightRouteId { get; set; }
    public int TourOperatorId { get; set; }

    public FlightEntity ToEntity()
    {
        return new FlightEntity
        {
            FlightNumber = FlightNumber,
            DepartureDate = DepartureDate,
            ArrivalDate = ArrivalDate,
            NumberOfSeats = NumberOfSeats,
            FlightRouteId = FlightRouteId,
            TourOperatorId = TourOperatorId,
            Id = Id,
            IsNew = false
        };
    }

    public class Validator : AbstractValidator<FlightUpdateInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.FlightNumber)
                .NotEmpty().WithMessage(L["flight-number-required"])
                .MaximumLength(10).WithMessage(L["flight-number-max-length"]);

            RuleFor(x => x.DepartureDate)
                .NotEmpty().WithMessage(L["departure-date-required"]);

            RuleFor(x => x.ArrivalDate)
                .NotEmpty().WithMessage(L["arrival-date-required"])
                .GreaterThan(x => x.DepartureDate).WithMessage(L["arrival-date-greater-than-departure"]);

            RuleFor(x => x.NumberOfSeats)
                .NotEmpty().WithMessage(L["number-of-seats-required"])
                .GreaterThanOrEqualTo(0).WithMessage(L["number-of-seats-greater-than-or-equal"]);
        }
    }
}

public class FlightManagementRepository(DataAccessAdapter adapter)
    : BaseRepository(adapter), IFlightRepository
{
    public async Task<FlightDetailsView?> GetFlightAsync(int flightId)
    {
        var query = await _meta.Flight.Where(f => f.Id == flightId).ProjectToFlightDetailsView().FirstOrDefaultAsync();
        return query;
    }

    public async Task<FlightDetailsView?> GetFlightAsync(string flightNumber)
    {
        var query = await _meta.Flight.Where(f =>
            f.FlightNumber == flightNumber
            && f.DepartureDate >= DateTime.Now
            && f.ObjectStatus == Constants.ObjectStatus.Active
        ).ProjectToFlightDetailsView().FirstOrDefaultAsync();
        return query;
    }

    public async Task<List<FlightListView>> GetFlightAsync(int tourOperatorId, DateTime departureDate)
    {
        var query = await _meta.Flight.Where(f =>
            f.TourOperatorId == tourOperatorId
            && f.DepartureDate >= departureDate && f.DepartureDate <= departureDate.AddDays(1)
            && f.ObjectStatus == Constants.ObjectStatus.Active
        ).ProjectToFlightListView().ToListAsync();

        return query;
    }

    public async Task<List<FlightListView>> GetFlightsAsync(int pageNo = 1, int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.Flight.Where(a => a.ObjectStatus == Constants.ObjectStatus.Active)
            .TakePage(pageNo, pageSize)
            .ProjectToFlightListView().ToListAsync();
        return query;
    }

    public async Task<List<FlightRouteListView>> GetFlightRoutesAsync(int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        List<FlightRouteListView>? query;

        if (pageNo < 1 || pageSize < 1)
            query = await _meta.FlightRoute.Where(a => a.ObjectStatus == Constants.ObjectStatus.Active)
                .ProjectToFlightRouteListView()
                .ToListAsync();
        else
            query = await _meta.FlightRoute.Where(a => a.ObjectStatus == Constants.ObjectStatus.Active)
                .TakePage(pageNo, pageSize)
                .ProjectToFlightRouteListView().ToListAsync();

        return query;
    }

    public async Task<List<PassengerListView>> GetPassengersAsync(int flightId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.Passenger
            .Where(a => a.ObjectStatus == Constants.ObjectStatus.Active && a.FlightId == flightId)
            .TakePage(pageNo, pageSize)
            .ProjectToPassengerListView().ToListAsync();
        return query;
    }

    public async Task<List<PassengerListView>> GetPassengersFromSearchAsync(int flightId, string searchTerm,
        int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var lowerCaseSearchTerm = searchTerm.ToLower();

        var query = await _meta.Passenger
            .Where(p => p.ObjectStatus == Constants.ObjectStatus.Active
                        && p.FlightId == flightId
                        && (p.Person.FirstName.ToLower().Contains(lowerCaseSearchTerm)
                            || p.Person.LastName.ToLower().Contains(lowerCaseSearchTerm)))
            .TakePage(pageNo, pageSize)
            .ProjectToPassengerListView()
            .ToListAsync();

        return query;
    }

    public Task<FlightPassengersDetailsView?> GetFlightPassengersAsync(int flightId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var projectionParams = new FlightPassengersDetailsViewProjectionParams();
        projectionParams.FlightRouteProjectionParams.RouteAmenitiesProjectionParams
            .LinqWhereClause = f => f.Amenity.ObjectStatus == Constants.ObjectStatus.Active;
        projectionParams.PassengersProjectionParams.PassengerAmenitySelectionsProjectionParams
            .LinqWhereClause = f => f.RouteAmenity.Amenity.ObjectStatus == Constants.ObjectStatus.Active;
        var query = _meta.Flight.Where(f => f.Id == flightId && f.ObjectStatus == Constants.ObjectStatus.Active)
            .ProjectToFlightPassengersDetailsView(projectionParams).FirstOrDefaultAsync();
        return query;
    }

    public Task<bool> SaveFlightAsync(FlightNewInput input)
    {
        var entity = input.ToEntity();
        return _adapter.SaveEntityAsync(entity);
    }

    public Task<bool> SaveFlightAsync(FlightUpdateInput input)
    {
        var entity = input.ToEntity();
        return _adapter.SaveEntityAsync(entity);
    }

    public async Task<FlightRouteDetailsView?> GetFlightRouteAmenitiesAsync(int flightRouteId)
    {
        var projectionParams = new FlightRouteDetailsViewProjectionParams
        {
            RouteAmenitiesProjectionParams =
            {
                LinqWhereClause = f =>
                    f.Amenity.ObjectStatus == Constants.ObjectStatus.Active
            }
        };
        var query = await _meta.FlightRoute
            .Where(f => f.Id == flightRouteId)
            .ProjectToFlightRouteDetailsView(projectionParams)
            .FirstOrDefaultAsync();
        return query;
    }

    public async Task<RouteAmenityDetailsView?> GetFlightRouteAmenityAsync(int flightRouteAmenityId)
    {
        var query = await _meta.RouteAmenity
            .Where(x => x.Id == flightRouteAmenityId && x.ObjectStatus == Constants.ObjectStatus.Active)
            .ProjectToRouteAmenityDetailsView()
            .FirstOrDefaultAsync();

        return query;
    }
}