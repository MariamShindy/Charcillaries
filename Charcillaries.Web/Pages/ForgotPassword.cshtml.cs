using Charcillaries.Core;
using Charcillaries.Core.Features.Identity;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using MimeKit;

namespace Charcillaries.Web.Pages;

public class ForgotPasswordModel(IConfiguration _configuration, ILogger<ForgotPasswordModel> _logger, IIdentityRepository _identityRepository, IStringLocalizer<Global> L, BaseUrl baseUrl) : PageModel
{
    [BindProperty]
    public string Email { get; set; } = string.Empty;

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _identityRepository.GetUserAsync(Email);
        if (user == null)
        {
            _logger.LogWarning($"User not found with email --> {Email}!!");
            return RedirectToPage("/InvalidEmail");
        }
        _logger.LogInformation($"User found with email --> {Email}!!");

        var resetToken = Guid.NewGuid().ToString();
        var resetTokenExpiration = DateTime.UtcNow.AddHours(1).ToLocalTime(); ;

        user.ResetToken = resetToken;
        user.ResetTokenExpiration = resetTokenExpiration;

        await _identityRepository.UpdateUserAsync(user);

        await SendResetEmailAsync(Email, resetToken);

        return RedirectToPage("/ForgotPasswordConfirmation");
    }

    private async Task SendResetEmailAsync(string userEmail, string resetToken)
    {
        var emailSettings = _configuration.GetSection("Email").Get<EmailSettings>();

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(emailSettings?.DefaultSenderName, emailSettings?.DefaultSenderEmail));
        message.To.Add(new MailboxAddress("", userEmail));
        message.Subject = L["email-subject"];

        message.Body = new TextPart("html")
        {
            Text = $@"
        <html>
            <body>
                <h1>{L["email-body"]}</h1>
                <h3><a href='{baseUrl.Url}/reset-password?token={resetToken}'>{L["reset-password"]}</a></h3>
            </body>
        </html>"
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(emailSettings?.EmailHost, emailSettings?.EmailPort ?? 587, false);
            await client.AuthenticateAsync(emailSettings?.EmailUsername, emailSettings?.EmailPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}

public class EmailSettings
{
    public string EmailHost { get; set; } = string.Empty;
    public int EmailPort { get; set; }
    public string EmailUsername { get; set; } = string.Empty;
    public string EmailPassword { get; set; } = string.Empty;
    public string DefaultSenderEmail { get; set; } = string.Empty;
    public string DefaultSenderName { get; set; } = string.Empty;
}