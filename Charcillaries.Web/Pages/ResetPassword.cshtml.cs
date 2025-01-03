using Charcillaries.Core.Features.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages;

public class ResetPasswordModel(IIdentityRepository _identityRepository) : PageModel
{
    [BindProperty]
    public string Token { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    public void OnGet(string token)
    {
        Token = token;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _identityRepository.GetUserByResetTokenAsync(Token);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid token or token expired.");
            return Page();
        }

        user.Password = new PasswordHasher<string>().HashPassword(string.Empty, Password);
        user.ResetToken = null;
        user.ResetTokenExpiration = null;

        await _identityRepository.UpdateUserAsync(user);

        return RedirectToPage("/ResetPasswordConfirmation");
    }
}