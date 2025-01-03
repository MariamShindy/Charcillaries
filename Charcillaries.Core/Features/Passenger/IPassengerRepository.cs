using Charcillaries.Data.DatabaseSpecific;
using Charcillaries.Data.EntityClasses;
using Charcillaries.Data.HelperClasses;
using Charcillaries.Data.Linq;
using Charcillaries.Data.Views.DtoClasses;
using Charcillaries.Data.Views.Persistence;
using FluentValidation;
using Microsoft.Extensions.Localization;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SK.Framework;

namespace Charcillaries.Core.Features.Passenger;

public interface IPassengerRepository

{
    Task<(bool, int)> SavePassengerAsync(PassengerNewInput input);

    Task<(bool, int)> SavePassengerAsync(int personId, int flightId);

    Task<bool> SavePassengerSelectionAsync(PassengerSelectionNewInput input);

    Task ConfirmPassengerSelectionAsync(int selectionId);

    Task<bool> SaveRouteFlightFeedbackAsync(RouteFlightFeedbackNewInput input);

    Task<int> SaveRouteAmenityFeedbackCollectionAsync(RouteAmenityFeedbackNewCollectionInput input);

    Task<int> SaveRouteAmenityFeedbackCollectionAsync(RouteAmenityFeedbackUpdateCollectionInput input);

    Task<RouteFlightFeedbackMinimalView?> GetRouteFlightFeedbackMinimalAsync(int passengerId);

    Task<Dictionary<int, AmenityFeedbackMinimalView>> GetAmenityFeedbackMinimalAsync(int passengerId);

    Task<PassengerFlightDetailsView?> GetPassengerAsync(int passengerId);

    Task<PassengerFlightDetailsView?> GetPersonAsync(int passengerId);

    Task<List<PassengerListView>> GetPassengersAsync(int pageNo = 1, int pageSize = Constants.CommonPageSize);

    Task<List<PassengerFlightListView>> GetFlightsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task<List<PassengerAmenityListView>> GetCartItemsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task<List<PassengerFlightListView>> GetUpcomingFlightsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task<List<PassengerFlightListView>> GetPastFlightsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task RemovePassengerAmenityAsync(int passengerAmenityId);

    Task<bool> RemovePassengerAsync(PassengerRemoveInput input);

    Task<double> GetPassengerAmenityPriceAsync(int routeAmenityId);

    Task<int> GetNumberOfPassengersAsync();

    Task<int> GetNumberOfUpcomingFlightsAsync(int personId);

    Task<int> GetNumberOfPastFlightsAsync(int personId);

    Task<int> GetNumberOfCartItemsAsync(int personId);

    Task<List<FlightDetailsView>> GetFilteredUpcomingFlightsAsync(PassengersFlightsFilter filter,
        int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task<List<FlightDetailsView>> GetFilteredPastFlightsAsync(PassengersFlightsFilter filter,
        int pageNo = 1,
        int pageSize = Constants.CommonPageSize);

    Task<int> CheckSelectionStatus(int routeAmenityId, int passengerId);

    Task EnableSelectionAsync(int routeAmenityId, int passengerId);

    Task<List<PassengerListView>> GetPassengersFromSearch(string searchTerm);
}

public class PassengersFlightsFilter : IFilter<FlightDetailsView>
{
    public string? FlightNumber { get; set; }
    public DateTime? DepartureDateAfter { get; set; }
    public DateTime? DepartureDateBefore { get; set; }
    public string? DepartureAirport { get; set; }
    public string? ArrivalAirport { get; set; }
    public int? TourOperatorId { get; set; }
    public int? AirlineId { get; set; }

    public IQueryable<FlightDetailsView> Filter(IQueryable<FlightDetailsView> query, LinqMetaData? meta = null)
    {
        if (!string.IsNullOrEmpty(FlightNumber))
            query = query.Where(x => x.FlightNumber == FlightNumber);
        if (DepartureDateAfter.HasValue)
            query = query.Where(x => x.DepartureDate > DepartureDateAfter);
        if (DepartureDateBefore.HasValue)
            query = query.Where(x => x.DepartureDate < DepartureDateBefore);
        if (!string.IsNullOrEmpty(DepartureAirport))
            query = query.Where(x => x.FlightRoute.DepartureAirport == DepartureAirport);
        if (!string.IsNullOrEmpty(ArrivalAirport))
            query = query.Where(x => x.FlightRoute.ArrivalAirport == ArrivalAirport);
        if (TourOperatorId.HasValue)
            query = query.Where(x => x.TourOperatorId == TourOperatorId);
        if (AirlineId.HasValue)
            query = query.Where(x => x.FlightRoute.AirlineId == AirlineId);
        return query;
    }
}

public class PassengerNewInput
{
    public PersonNewInput Person { get; set; } = new();
    public int FlightId { get; set; }

    public PassengerEntity ToEntity()
    {
        return new PassengerEntity
        {
            FlightId = FlightId,
            Person = new PersonEntity
            {
                FirstName = Person.FirstName,
                LastName = Person.LastName,
                Email = Person.Email,
                PhoneNumber = Person.PhoneNumber,
                PassportNumber = Person.PassportNumber
            }
        };
    }

    public class PersonNewInput
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string? PassportNumber { get; set; } = string.Empty;
    }

    public class Validator : AbstractValidator<PassengerNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.FlightId)
                .NotEmpty().WithMessage(L["flight-required"]);

            RuleFor(x => x.Person.FirstName)
                .NotEmpty().WithMessage(L["first-name-required"])
                .MaximumLength(50).WithMessage(L["first-name-max-length"]);

            RuleFor(x => x.Person.LastName)
                .NotEmpty().WithMessage(L["last-name-required"])
                .MaximumLength(50).WithMessage(L["last-name-max-length"]);

            RuleFor(x => x.Person.Email)
                .NotEmpty().WithMessage(L["email-required"])
                .EmailAddress().WithMessage(L["email-invalid"])
                .MaximumLength(255).WithMessage(L["email-max-length"]);

            RuleFor(x => x.Person.PhoneNumber)
                .NotEmpty().WithMessage(L["contact-info-required"])
                .MinimumLength(10).WithMessage(L["contact-info-min-length"])
                .MaximumLength(30).WithMessage(L["contact-info-max-length"])
                .Matches(@"^\d+$").WithMessage(L["contact-info-numeric"]);

            RuleFor(x => x.Person.PassportNumber)
                .MaximumLength(50).WithMessage(L["passport-number-max-length"]);
        }
    }
}

public class PassengerRemoveInput
{
    public const int ObjectStatus = Constants.ObjectStatus.Disabled;
    public int PassengerId { get; set; }

    public PassengerEntity ToEntity()
    {
        return new PassengerEntity
        {
            Id = PassengerId,
            ObjectStatus = ObjectStatus,
            IsNew = false
        };
    }
}

public class PassengerSelectionNewInput
{
    public int PassengerId { get; set; }
    public int RouteAmenityId { get; set; }
    public string? Customization { get; set; } = string.Empty;

    public PassengerAmenitySelectionEntity ToEntity()
    {
        return new PassengerAmenitySelectionEntity
        {
            PassengerId = PassengerId,
            RouteAmenityId = RouteAmenityId,
            Customization = Customization,
        };
    }

    public class Validator : AbstractValidator<PassengerSelectionNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.PassengerId).NotEmpty().WithMessage(L["passenger-required"]);
            RuleFor(x => x.RouteAmenityId).NotEmpty().WithMessage(L["amenity-required"]);
            RuleFor(x => x.Customization)
                .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.Customization))
                .WithMessage(L["customization-max-length"]);
        }
    }
}

public class RouteFlightFeedbackNewInput
{
    public int? Rating { get; set; }
    public string? Comment { get; set; } = string.Empty;

    DateTime DateCreated { get; } = DateTime.Now.ToLocalTime();
    public int PassengerId { get; set; }
    public int FlightId { get; set; }

    public RouteFlightFeedbackEntity ToEntity()
    {
        return new RouteFlightFeedbackEntity
        {
            Rating = Rating,
            Comment = Comment,
            DateCreated = DateCreated,
            PassengerId = PassengerId,
            FlightId = FlightId
        };
    }

    public class Validator : AbstractValidator<RouteFlightFeedbackNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).When(x => x.Rating.HasValue)
                .WithMessage(L["rating-validation"]);
            RuleFor(x => x.Comment)
                .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.Comment))
                .WithMessage(L["comment-validation"]);
            RuleFor(x => x.DateCreated).NotEmpty().WithMessage(L["date-created-required"]);
            RuleFor(x => x.PassengerId).NotEmpty().WithMessage(L["passenger-required"]);
            RuleFor(x => x.FlightId).NotEmpty().WithMessage(L["flight-required"]);
        }
    }
}

public class RouteAmenityFeedbackNewInput
{
    public int? Rating { get; set; }
    public string? Comment { get; set; } = string.Empty;

    public int PassengerId { get; set; }
    DateTime DateCreated { get; } = DateTime.Now.ToLocalTime();

    public string AmenityId { get; set; } = string.Empty;

    public AmenityFeedbackEntity ToEntity()
    {
        return new AmenityFeedbackEntity
        {
            Rating = Rating,
            Comment = Comment,
            DateCreated = DateCreated,
            PassengerId = PassengerId,
            AmenityId = Hash.DecodeToInt(AmenityId)
        };
    }

    public class Validator : AbstractValidator<RouteAmenityFeedbackNewInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).When(x => x.Rating.HasValue)
                .WithMessage(L["rating-validation"]);
            RuleFor(x => x.Comment)
                .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.Comment))
                .WithMessage(L["comment-validation"]);
            RuleFor(x => x.DateCreated).NotEmpty().WithMessage(L["date-created-required"]);
            RuleFor(x => x.PassengerId).NotEmpty().WithMessage(L["passenger-required"]);
            RuleFor(x => x.AmenityId).NotEmpty().WithMessage(L["amenity-required"]);
        }
    }
}

public class RouteAmenityFeedbackNewCollectionInput
{
    public List<RouteAmenityFeedbackNewInput> RouteAmenityFeedbacksList { get; set; } = [];

    public EntityCollection<AmenityFeedbackEntity> ToEntityCollection()
    {
        var collection = new EntityCollection<AmenityFeedbackEntity>();
        foreach (var item in RouteAmenityFeedbacksList) collection.Add(item.ToEntity());

        return collection;
    }

    public class Validator : AbstractValidator<RouteAmenityFeedbackNewCollectionInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleForEach(x => x.RouteAmenityFeedbacksList).SetValidator(new RouteAmenityFeedbackNewInput.Validator(L));
        }
    }
}

public class RouteAmenityFeedbackUpdateInput
{
    public string Id { get; set; } = string.Empty;
    public int? Rating { get; set; }
    public string? Comment { get; set; } = string.Empty;

    public int PassengerId { get; set; }
    DateTime DateCreated { get; } = DateTime.Now.ToLocalTime();

    public string AmenityId { get; set; } = string.Empty;

    public AmenityFeedbackEntity ToEntity()
    {
        return new AmenityFeedbackEntity
        {
            Id = Hash.DecodeToInt(Id),
            Rating = Rating,
            Comment = Comment,
            DateCreated = DateCreated,
            PassengerId = PassengerId,
            AmenityId = Hash.DecodeToInt(AmenityId),
            IsNew = false
        };
    }

    public class Validator : AbstractValidator<RouteAmenityFeedbackUpdateInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).When(x => x.Rating.HasValue)
                .WithMessage(L["rating-validation"]);
            RuleFor(x => x.Comment)
                .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.Comment))
                .WithMessage(L["comment-validation"]);
            RuleFor(x => x.DateCreated).NotEmpty().WithMessage(L["date-created-required"]);
            RuleFor(x => x.PassengerId).NotEmpty().WithMessage(L["passenger-required"]);
            RuleFor(x => x.AmenityId).NotEmpty().WithMessage(L["amenity-required"]);
        }
    }
}

public class RouteAmenityFeedbackUpdateCollectionInput
{
    public List<RouteAmenityFeedbackUpdateInput> RouteAmenityFeedbacksList { get; set; } = [];

    public EntityCollection<AmenityFeedbackEntity> ToEntityCollection()
    {
        var collection = new EntityCollection<AmenityFeedbackEntity>();
        foreach (var item in RouteAmenityFeedbacksList) collection.Add(item.ToEntity());

        return collection;
    }

    public class Validator : AbstractValidator<RouteAmenityFeedbackUpdateCollectionInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleForEach(x => x.RouteAmenityFeedbacksList)
                .SetValidator(new RouteAmenityFeedbackUpdateInput.Validator(L));
        }
    }
}

public class PassengerManagementRepository(DataAccessAdapter adapter)
    : BaseRepository(adapter), IPassengerRepository
{
    public async Task<(bool, int)> SavePassengerAsync(PassengerNewInput input)
    {
        var entity = input.ToEntity();
        return (await _adapter.SaveEntityAsync(entity), entity.Id);
    }

    public async Task<(bool, int)> SavePassengerAsync(int personId, int flightId)
    {
        var existingPassenger = await _meta.Passenger.FirstOrDefaultAsync(a =>
            a.PersonId == personId && a.FlightId == flightId && a.ObjectStatus == Constants.ObjectStatus.Active);

        if (existingPassenger != null)
            return (false, -2);

        var entity = new PassengerEntity
        {
            PersonId = personId,
            FlightId = flightId
        };
        return (await _adapter.SaveEntityAsync(entity), entity.Id);
    }

    public async Task<bool> SavePassengerSelectionAsync(PassengerSelectionNewInput input) //not working
    {
        try
        {
            var entity = await _meta.PassengerAmenitySelection.FirstOrDefaultAsync(a =>
                a.PassengerId == input.PassengerId && a.RouteAmenityId == input.RouteAmenityId &&
                a.ObjectStatus == Constants.ObjectStatus.Active);

            if (entity == null)
            {
                return await _adapter.SaveEntityAsync(input.ToEntity());
            }

            entity.Customization = input.Customization;
            return await _adapter.SaveEntityAsync(entity);
        }
        catch (Exception)
        {
            return false;
        }
    }

    // public async Task<bool> SavePassengerSelectionAsync(PassengerSelectionNewInput input) //done
    // {
    //     var entity = await _meta.PassengerAmenitySelection.FirstOrDefaultAsync(a =>
    //         a.PassengerId == input.PassengerId && a.AmenityId == input.AmenityId &&
    //         a.ObjectStatus == Constants.ObjectStatus.Active);
    //
    //     if (entity == null)
    //         return await _adapter.SaveEntityAsync(input.ToEntity());
    //
    //     entity.Customization = input.Customization;
    //     return await _adapter.SaveEntityAsync(entity);
    // }

    public async Task<bool> SaveRouteFlightFeedbackAsync(RouteFlightFeedbackNewInput input)
    {
        var entity = await _meta.RouteFlightFeedback.FirstOrDefaultAsync(a =>
            a.PassengerId == input.PassengerId && a.FlightId == input.FlightId &&
            a.ObjectStatus == Constants.ObjectStatus.Active);
        if (entity == null)
        {
            entity = input.ToEntity();
            return await _adapter.SaveEntityAsync(entity);
        }

        entity.Rating = input.Rating;
        entity.Comment = input.Comment;
        entity.DateCreated = DateTime.Now.ToLocalTime();

        return await _adapter.SaveEntityAsync(entity);
    }

    public Task<int> SaveRouteAmenityFeedbackCollectionAsync(RouteAmenityFeedbackNewCollectionInput input)
    {
        var ec = input.ToEntityCollection();

        return _adapter.SaveEntityCollectionAsync(ec);
    }

    public Task<int> SaveRouteAmenityFeedbackCollectionAsync(RouteAmenityFeedbackUpdateCollectionInput input)
    {
        var ec = input.ToEntityCollection();

        return _adapter.SaveEntityCollectionAsync(ec);
    }

    // public async Task<int> SaveRouteAmenityFeedbackCollectionAsync(RouteAmenityFeedbackNewCollectionInput input)
    // {
    //     var entityCollection = new EntityCollection<AmenityFeedbackEntity>();
    //
    //     var amenityFeedbacks = await _meta.AmenityFeedback.Where(a =>
    //         a.PassengerId == input.RouteAmenityFeedbacksList[0].PassengerId &&
    //         a.ObjectStatus == Constants.ObjectStatus.Active).ToListAsync();
    //
    //     foreach (var amenityFeedback in amenityFeedbacks)
    //     {
    //         var newInput = input.RouteAmenityFeedbacksList.FirstOrDefault(a =>
    //             Hash.DecodeToInt(a.AmenityId) == amenityFeedback.AmenityId);
    //
    //         if (newInput == null)
    //             continue;
    //
    //         amenityFeedback.Rating = newInput.Rating;
    //         amenityFeedback.Comment = newInput.Comment;
    //         amenityFeedback.DateCreated = DateTime.Now.ToLocalTime();
    //
    //         input.RouteAmenityFeedbacksList.Remove(newInput);
    //         entityCollection.Add(amenityFeedback);
    //     }
    //
    //     entityCollection.AddRange(input.ToEntityCollection());
    //
    //     return await _adapter.SaveEntityCollectionAsync(entityCollection);
    // }

    public async Task<RouteFlightFeedbackMinimalView?> GetRouteFlightFeedbackMinimalAsync(int passengerId)
    {
        var query = await _meta.RouteFlightFeedback
            .Where(a => a.PassengerId == passengerId && a.ObjectStatus == Constants.ObjectStatus.Active)
            .ProjectToRouteFlightFeedbackMinimalView().FirstOrDefaultAsync();

        return query;
    }

    public async Task<Dictionary<int, AmenityFeedbackMinimalView>> GetAmenityFeedbackMinimalAsync(int passengerId)
    {
        var query = await _meta.AmenityFeedback
            .Where(a => a.PassengerId == passengerId && a.ObjectStatus == Constants.ObjectStatus.Active)
            .ProjectToAmenityFeedbackMinimalView()
            .ToDictionaryAsync(a => a.AmenityId);

        return query;
    }

    public async Task<PassengerFlightDetailsView?> GetPassengerAsync(int passengerId)
    {
        var query = await _meta.Passenger.Where(p => p.Id == passengerId).ProjectToPassengerFlightDetailsView()
            .FirstOrDefaultAsync();
        return query;
    }

    public async Task<PassengerFlightDetailsView?> GetPersonAsync(int personId)
    {
        var query = await _meta.Passenger.Where(p => p.PersonId == personId).ProjectToPassengerFlightDetailsView()
            .FirstOrDefaultAsync();
        return query;
    }

    public async Task<List<PassengerListView>> GetPassengersAsync(int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.Passenger.Where(a => a.ObjectStatus == Constants.ObjectStatus.Active)
            .TakePage(pageNo, pageSize)
            .ProjectToPassengerListView().ToListAsync();
        return query;
    }

    public async Task<List<PassengerFlightListView>> GetFlightsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.Passenger
            .Where(a => a.ObjectStatus == Constants.ObjectStatus.Active && a.PersonId == personId)
            .TakePage(pageNo, pageSize)
            .ProjectToPassengerFlightListView().ToListAsync();
        return query;
    }

    public async Task<List<PassengerAmenityListView>> GetCartItemsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.PassengerAmenitySelection
            .Where(a => a.ObjectStatus == Constants.ObjectStatus.Active && a.Passenger.Person.Id == personId &&
                        a.Passenger.Flight.DepartureDate >= DateTime.Now &&
                        a.Confirmed == Constants.ConfirmationStatus.Pending)
            .TakePage(pageNo, pageSize)
            .ProjectToPassengerAmenityListView().ToListAsync();
        return query;
    }

    public async Task<List<PassengerFlightListView>> GetUpcomingFlightsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.Passenger
            .Where(p => p.Flight.ObjectStatus == Constants.ObjectStatus.Active && p.PersonId == personId &&
                        p.Flight.DepartureDate >= DateTime.Now).TakePage(pageNo, pageSize)
            .ProjectToPassengerFlightListView().ToListAsync();
        return query;
    }

    public async Task<List<PassengerFlightListView>> GetPastFlightsAsync(int personId, int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = await _meta.Passenger
            .Where(p => p.Flight.ObjectStatus == Constants.ObjectStatus.Active && p.PersonId == personId &&
                        p.Flight.DepartureDate < DateTime.Now).TakePage(pageNo, pageSize)
            .ProjectToPassengerFlightListView().ToListAsync();
        return query;
    }

    public Task<bool> RemovePassengerAsync(PassengerRemoveInput input)
    {
        var entity = input.ToEntity();
        return _adapter.SaveEntityAsync(entity);
    }

    public async Task RemovePassengerAmenityAsync(int selectionId)
    {
        var selection = await _meta.PassengerAmenitySelection.FirstOrDefaultAsync(a => a.Id == selectionId);
        if (selection != null)
        {
            selection.ObjectStatus = Constants.ObjectStatus.Disabled;
            await _adapter.SaveEntityAsync(selection, true);
        }
    }

    public async Task<double> GetPassengerAmenityPriceAsync(int routeAmenityId)
    {
        var selection =
            await _meta.RouteAmenity.Where(p => p.Id == routeAmenityId).FirstOrDefaultAsync();
        double price = 0.0;
        if (selection != null)
        {
            price = selection.Price;
        }

        return price;
    }

    public async Task ConfirmPassengerSelectionAsync(int selectionId)
    {
        var selection = await _meta.PassengerAmenitySelection.FirstOrDefaultAsync(a => a.Id == selectionId);
        if (selection != null)
        {
            selection.Confirmed = Constants.ConfirmationStatus.Confirmed;
            await _adapter.SaveEntityAsync(selection, true);
        }
    }

    public async Task<int> GetNumberOfPassengersAsync()
    {
        var query = await _meta.Passenger.Where(t => t.ObjectStatus == Constants.ObjectStatus.Active).CountAsync();
        return query;
    }

    public async Task<int> GetNumberOfUpcomingFlightsAsync(int personId)
    {
        var query = await _meta.Passenger.Where(t =>
            t.Flight.ObjectStatus == Constants.ObjectStatus.Active && t.PersonId == personId &&
            t.Flight.DepartureDate >= DateTime.Now).CountAsync();
        return query;
    }

    public async Task<int> GetNumberOfPastFlightsAsync(int personId)
    {
        var query = await _meta.Passenger.Where(t =>
            t.Flight.ObjectStatus == Constants.ObjectStatus.Active && t.PersonId == personId &&
            t.Flight.DepartureDate < DateTime.Now).CountAsync();
        return query;
    }

    public async Task<int> GetNumberOfCartItemsAsync(int personId)
    {
        var query = await _meta.PassengerAmenitySelection
            .Where(a => a.ObjectStatus == Constants.ObjectStatus.Active && a.Passenger.Person.Id == personId &&
                        a.Passenger.Flight.DepartureDate >= DateTime.Now &&
                        a.Confirmed == Constants.ConfirmationStatus.Pending).CountAsync();
        return query;
    }

    public Task<List<FlightDetailsView>> GetFilteredUpcomingFlightsAsync(
        PassengersFlightsFilter filter, int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = _meta.Flight
            .Where(f => f.ObjectStatus == Constants.ObjectStatus.Active && f.DepartureDate >= DateTime.Now)
            .ProjectToFlightDetailsView();
        query = filter.Filter(query, _meta);
        var pagedQuery = query
            .TakePage(pageNo, pageSize);
        return pagedQuery.ToListAsync();
    }

    public Task<List<FlightDetailsView>> GetFilteredPastFlightsAsync(PassengersFlightsFilter filter,
        int pageNo = 1,
        int pageSize = Constants.CommonPageSize)
    {
        var query = _meta.Flight
            .Where(f => f.ObjectStatus == Constants.ObjectStatus.Active && f.DepartureDate < DateTime.Now)
            .ProjectToFlightDetailsView();
        query = filter.Filter(query, _meta);
        var pagedQuery = query
            .TakePage(pageNo, pageSize);
        return pagedQuery.ToListAsync();
    }

    public async Task<int> CheckSelectionStatus(int routeAmenityId, int passengerId)
    {
        {
            var amenityId = await _meta.RouteAmenity
                .Where(ra => ra.Id == routeAmenityId)
                .Select(ra => ra.AmenityId)
                .FirstOrDefaultAsync();
            var query = await _meta.PassengerAmenitySelection
                .Where(p => p.PassengerId == passengerId && p.RouteAmenity.AmenityId == amenityId)
                .FirstOrDefaultAsync();
            if (query == null)
            {
                return 0;
            }
            else if (query.Confirmed == Constants.ConfirmationStatus.Confirmed)
            {
                return 1;
            }
            else if (query.ObjectStatus == Constants.ObjectStatus.Disabled)
            {
                return 2;
            }

            return 3;
        }
    }

    public async Task EnableSelectionAsync(int routeAmenityId, int passengerId)
    {
        var amenityId = await _meta.RouteAmenity
            .Where(ra => ra.Id == routeAmenityId)
            .Select(ra => ra.AmenityId)
            .FirstOrDefaultAsync();
        var query = await _meta.PassengerAmenitySelection
            .Where(p => p.PassengerId == passengerId && p.RouteAmenityId == routeAmenityId).FirstOrDefaultAsync();
        if (query.ObjectStatus == Constants.ObjectStatus.Disabled)
        {
            query.ObjectStatus = Constants.ObjectStatus.Active;
            await _adapter.SaveEntityAsync(query, true);
        }
    }

    // public async Task<int> CheckSelectionStatus(int routeAmenityId, int passengerId) //doneeeeeeeeeee
    // {
    //     var amenityId = _meta.RouteAmenity
    //         .Where(ra => ra.Id == routeAmenityId)
    //         .Select(ra => ra.AmenityId)
    //         .FirstOrDefault();
    //     var query = await _meta.PassengerAmenitySelection
    //         .Where(p => p.PassengerId == passengerId && p.AmenityId == amenityId).FirstOrDefaultAsync();
    //     if (query == null)
    //     {
    //         return 0;
    //     }
    //     else if (query.Confirmed == Constants.ConfirmationStatus.Confirmed)
    //     {
    //         return 1;
    //     }
    //     else if (query.ObjectStatus == Constants.ObjectStatus.Disabled)
    //     {
    //         return 2;
    //     }
    //
    //     return 3;
    // }

    // public async Task EnableSelectionAsync(int routeAmenityId, int passengerId) //doneeeeeeeee
    // {
    //     var amenityId = _meta.RouteAmenity
    //         .Where(ra => ra.Id == routeAmenityId)
    //         .Select(ra => ra.AmenityId)
    //         .FirstOrDefault();
    //     var query = await _meta.PassengerAmenitySelection
    //         .Where(p => p.PassengerId == passengerId && p.AmenityId == amenityId).FirstOrDefaultAsync();
    //     if (query.ObjectStatus == Constants.ObjectStatus.Disabled)
    //     {
    //         query.ObjectStatus = Constants.ObjectStatus.Active;
    //         await _adapter.SaveEntityAsync(query, true);
    //     }
    // }

    public async Task<List<PassengerListView>> GetPassengersFromSearch(string searchTerm)
    {
        var passengers = await _meta.Passenger
            .Where(p => p.Person.FirstName.Contains(searchTerm) || p.Person.LastName.Contains(searchTerm))
            .ProjectToPassengerListView()
            .ToListAsync();
        return passengers;
    }
}