using Charcillaries.Core.Features.Airline;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Airlines;

public class AddModel(
    ILogger<AddModel> logger,
    IAirlineRepository repo,
    IValidator<AirlineNewInput> validator
) : PageModel
{
    [BindProperty] public AirlineNewInput Airline { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var validationResult = await validator.ValidateAsync(Airline);
        validationResult.AddToModelState(ModelState, nameof(Airline));

        if (!ModelState.IsValid)
            return Page();

        try
        {
            var result = await repo.SaveAirlineAsync(Airline);
            if (result)
                return RedirectToPage("Index");

            ModelState.AddModelError("", "Error saving airline");
            return Page();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error saving airline");
            return Page();
        }
    }
}