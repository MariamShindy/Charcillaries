using Charcillaries.Data.DatabaseSpecific;
using Charcillaries.Data.Views.DtoClasses;
using Charcillaries.Data.Views.Persistence;
using FluentValidation;
using Microsoft.Extensions.Localization;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Charcillaries.Core.Features.Identity;

public interface IIdentityRepository
{
    // login and register
    Task<UserView?> GetUserAsync(string email);

    // Password reset     //new
    Task<UserView?> GetUserByResetTokenAsync(string resetToken);

    Task UpdateUserAsync(UserView user);
}

public class LoginInput
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public class Validator : AbstractValidator<LoginInput>
    {
        public Validator(IStringLocalizer<Global> L)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(L["email-required"])
                .EmailAddress().WithMessage(L["email-invalid"]);
            RuleFor(x => x.Password).NotEmpty().WithMessage(L["password-required"]);
        }
    }
}

public class IdentityRepository(DataAccessAdapter adapter)
    : BaseRepository(adapter), IIdentityRepository
{
    public async Task<UserView?> GetUserAsync(string email)
    {
        var query = await _meta.User.Where(x => x.Person.Email == email)
            .ProjectToUserView().FirstOrDefaultAsync();

        return query;
    }

    //new
    public async Task<UserView?> GetUserByResetTokenAsync(string resetToken)
    {
        var query = await _meta.User.Where(x => x.ResetToken == resetToken && x.ResetTokenExpiration > DateTime.UtcNow.ToLocalTime())
            .ProjectToUserView().FirstOrDefaultAsync();

        return query;
    }

    //new
    public async Task UpdateUserAsync(UserView user)
    {
        var entity = await _meta.User.FirstOrDefaultAsync(x => x.Person.Email == user.Person.Email);
        if (entity != null)
        {
            entity.Password = user.Password;
            entity.ResetToken = user.ResetToken;
            entity.ResetTokenExpiration = user.ResetTokenExpiration;

            await _adapter.SaveEntityAsync(entity);
        }
    }
}