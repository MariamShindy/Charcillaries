using Charcillaries.Data.DatabaseSpecific;
using Charcillaries.Data.EntityClasses;
using Charcillaries.Data.Views.DtoClasses;
using Charcillaries.Data.Views.Persistence;
using FluentValidation;
using Microsoft.Extensions.Localization;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Charcillaries.Core.Features.TourOperator;

public interface ITourOperatorRepository
{
    Task<TourOperatorDetailsView?> GetTourOperatorAsync(int tourOperatorId);

    Task<bool> SaveTourOperatorAsync(TourOperatorNewInput input);

    Task<bool> SaveTourOperatorAsync(TourOperatorUpdateInput input);

    Task<List<TourOperatorDetailsView>> GetTourOperatorsAsync(int pageNo = 1, int pageSize = Constants.CommonPageSize);

    Task RemoveTourOperatorAsync(int tourOperatorId);

    Task<int> GetNumberOfTourOperators();

    Task<int> GetNumberOfAllFlights(int tourOperatorId);

    Task<int> GetNumberOfUpcomingFlights(int tourOperatorId);

    Task<int> GetNumberOfPassengers(int tourOperatorId);

    Task<List<FlightRouteListView>> GetTourOperatorRoutesAsync(int tourOperatorId);
}

public class TourOperatorNewInput
{
    public string Name { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;

    public TourOperatorEntity ToEntity()
    {
        return new TourOperatorEntity
        {
            Name = Name,
            ContactInfo = ContactInfo
        };
    }

    public class Validator : AbstractValidator<TourOperatorNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(L["name-required"])
                .MaximumLength(100).WithMessage(L["name-max-length"]);
            RuleFor(x => x.ContactInfo)
                .NotEmpty().WithMessage(L["contact-info-required"])
                .MinimumLength(10).WithMessage(L["contact-info-min-length"])
                .MaximumLength(30).WithMessage(L["contact-info-max-length"])
                .Matches(@"^\d+$").WithMessage(L["contact-info-numeric"]);
        }
    }
}

public class TourOperatorUpdateInput
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ContactInfo { get; set; } = string.Empty;

    public TourOperatorEntity ToEntity()
    {
        return new TourOperatorEntity
        {
            Id = Id,
            Name = Name,
            ContactInfo = ContactInfo,
            IsNew = false
        };
    }

    public class Validator : AbstractValidator<TourOperatorNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(L["name-required"])
                .MaximumLength(100).WithMessage(L["name-max-length"]);
            RuleFor(x => x.ContactInfo)
                .NotEmpty().WithMessage(L["contact-info-required"])
                .MinimumLength(10).WithMessage(L["contact-info-min-length"])
                .MaximumLength(30).WithMessage(L["contact-info-max-length"])
                .Matches(@"^\d+$").WithMessage(L["contact-info-numeric"]);
        }
    }
}

public class TourOperatorManagementRepository(DataAccessAdapter adapter)
    : BaseRepository(adapter), ITourOperatorRepository
{
    public async Task<TourOperatorDetailsView?> GetTourOperatorAsync(int tourOperatorId)
    {
        var query = await _meta.TourOperator.Where(t => t.Id == tourOperatorId).ProjectToTourOperatorDetailsView()
            .FirstOrDefaultAsync();
        return query;
    }

    public Task<bool> SaveTourOperatorAsync(TourOperatorNewInput input)
    {
        var entity = input.ToEntity();

        return _adapter.SaveEntityAsync(entity);
    }

    public Task<bool> SaveTourOperatorAsync(TourOperatorUpdateInput input)
    {
        var entity = input.ToEntity();

        return _adapter.SaveEntityAsync(entity);
    }

    public async Task<List<TourOperatorDetailsView>> GetTourOperatorsAsync(int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.TourOperator.Where(a => a.ObjectStatus == Constants.ObjectStatus.Active)
            .TakePage(pageNo, pageSize)
            .ProjectToTourOperatorDetailsView().ToListAsync();

        return query;
    }

    public Task RemoveTourOperatorAsync(int tourOperatorId)
    {
        var e = new TourOperatorEntity
        {
            Id = tourOperatorId,
            ObjectStatus = Constants.ObjectStatus.Disabled,
            IsNew = false
        };

        return _adapter.SaveEntityAsync(e);
    }

    public async Task<int> GetNumberOfTourOperators()
    {
        var query = await _meta.TourOperator.Where(t => t.ObjectStatus == Constants.ObjectStatus.Active).CountAsync();
        return query;
    }

    public async Task<int> GetNumberOfAllFlights(int tourOperatorId)
    {
        var query = await _meta.Flight
            .Where(t => t.ObjectStatus == Constants.ObjectStatus.Active && t.TourOperatorId == tourOperatorId)
            .CountAsync();
        return query;
    }

    public async Task<int> GetNumberOfUpcomingFlights(int tourOperatorId)
    {
        var query = await _meta.Flight.Where(t =>
            t.ObjectStatus == Constants.ObjectStatus.Active && t.TourOperatorId == tourOperatorId &&
            t.DepartureDate >= DateTime.Now).CountAsync();
        return query;
    }

    public async Task<int> GetNumberOfPassengers(int tourOperatorId)
    {
        var query = await _meta.Passenger.Where(t =>
            t.ObjectStatus == Constants.ObjectStatus.Active && t.Flight.TourOperatorId == tourOperatorId).CountAsync();
        return query;
    }

    public async Task<List<FlightRouteListView>> GetTourOperatorRoutesAsync(int tourOperatorId)
    {
        var routes = await _meta.FlightRoute
            .Where(f => f.Flights.Any(flight => flight.TourOperatorId == tourOperatorId))
            .ProjectToFlightRouteListView()
            .ToListAsync();
        return routes;
    }
}