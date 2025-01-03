using Charcillaries.Core.Features.TourOperator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.TourOperators;

public class AddModel(
    ILogger<AddModel> logger,
    ITourOperatorRepository repo,
    IValidator<TourOperatorNewInput> validator
) : PageModel
{
    [BindProperty] public TourOperatorNewInput TourOperator { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var validationResult = await validator.ValidateAsync(TourOperator);
        validationResult.AddToModelState(ModelState, nameof(TourOperator));

        if (!ModelState.IsValid)
            return Page();

        try
        {
            var result = await repo.SaveTourOperatorAsync(TourOperator);
            if (!result)
            {
                //Todo: show error message
                ModelState.AddModelError("", "Error saving tour operator");
                return Page();
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error saving tour operator");
            return Page();
        }

        //TODO: redirect to correct page
        return RedirectToPage("/Admin/TourOperators/Index");
    }
}