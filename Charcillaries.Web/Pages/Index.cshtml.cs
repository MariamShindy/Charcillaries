using Charcillaries.Core;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using MimeKit;

namespace Charcillaries.Web.Pages;

public class Index(IConfiguration _configuration, ILogger<Index> _logger, IStringLocalizer<Global> L) : PageModel
{
    [BindProperty]
    public ContactFormModel ContactForm { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var smtpSettings = _configuration.GetSection("Email");
            var smtpHost = smtpSettings["EmailHost"];
            var smtpPort = int.Parse(smtpSettings["EmailPort"]!);
            var smtpUsername = smtpSettings["EmailUsername"];
            var smtpPassword = smtpSettings["EmailPassword"];
            var message = new MimeMessage
            {
                From = { new MailboxAddress(ContactForm.Name, ContactForm.Email) },
                To = { new MailboxAddress("Mariam Shendy", "mariam.sh998@gmail.com") },
                //To = { new MailboxAddress("Jana Ashraf", "janaashraff1234@gmail.com") },
                Subject = "Charcillaries contact us form",
                Body = new TextPart("html")
                {
                    Text = $@"
                <html>
                <body>
                    <h2>Contact Us Form Feedback</h2>
                    <p><strong>Subject:</strong> {ContactForm.Subject}</p>
                    <p><strong>Name:</strong> {ContactForm.Name}</p>
                    <p><strong>Email:</strong> {ContactForm.Email}</p>
                    <p><strong>Message:</strong></p>
                    <p>{ContactForm.Message}</p>
                </body>
                </html>"
                }
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpUsername, smtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            TempData["SuccessMessage"] = L["modal-success"].Value;
            _logger.LogInformation("Email sent successfully");
            return RedirectToPage();
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while sending email");
            _logger.LogError(ex.Message);
            TempData["ErrorMessage"] = L["modal-failed"].Value;
            return Page();
        }
    }
}

public class ContactFormModel
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}