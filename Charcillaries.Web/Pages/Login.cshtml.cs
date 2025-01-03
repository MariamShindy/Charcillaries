using Charcillaries.Core.Features.Identity;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Charcillaries.Web.Pages;

public class Login(
    IIdentityRepository repo,
    IValidator<LoginInput> validator
)
    : PageModel
{
    [BindProperty] public LoginInput Input { get; set; } = new();

    [BindProperty(SupportsGet = true)] public string? ReturnUrl { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var validationResult = await validator.ValidateAsync(Input);
        validationResult.AddToModelState(ModelState, nameof(Input));

        if (!ModelState.IsValid)
            return Page();

        var user = await repo.GetUserAsync(Input.Email);
        if (user == null)
        {
            ModelState.AddModelError("loginError", "User not found.");
            return Page();
        }

        PasswordHasher<string> hasher = new();
        var result = hasher.VerifyHashedPassword(string.Empty, user.Password, Input.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("loginError", "Invalid password.");
            return Page();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Role, user.Role.Name)
        };

        switch (user.Role.Name)
        {
            case "Airline":
                claims.Add(new Claim(ClaimTypes.Sid, user.AirlineId.ToString()!));
                break;

            case "Tour Operator":
                claims.Add(new Claim(ClaimTypes.Sid, user.TourOperatorId.ToString()!));
                break;

            case "Passenger":
                claims.Add(new Claim(ClaimTypes.Sid, user.PersonId.ToString()));
                break;

            case "Admin":
                break;
        }

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(principal);

        return LocalRedirect(!string.IsNullOrEmpty(ReturnUrl)
            ? ReturnUrl
            : "/" + user.Role.Name.ToLower().Replace(" ", "-"));
    }
}