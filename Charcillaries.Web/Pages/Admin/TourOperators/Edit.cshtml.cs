using Charcillaries.Core;
using Charcillaries.Core.Features.TourOperator;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.TourOperators;

public class EditModel(
    ILogger<EditModel> logger,
    ITourOperatorRepository tourOperatorManagementRepository)
    : PageModel
{
    [BindProperty] public TourOperatorUpdateInput TourOperatorInput { get; set; } = new();

    public TourOperatorDetailsView? TourOperatorDetailsView { get; set; }

    public async Task<IActionResult> OnGetAsync(string tourOperatorId)
    {
        TourOperatorDetailsView =
            await tourOperatorManagementRepository.GetTourOperatorAsync(Hash.DecodeToInt(tourOperatorId));

        if (TourOperatorDetailsView == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string tourOperatorId)
    {
        if (!ModelState.IsValid)
            return Page();
        TourOperatorInput.Id = Hash.DecodeToInt(tourOperatorId);

        var result = await tourOperatorManagementRepository.SaveTourOperatorAsync(TourOperatorInput);
        if (result)
        {
            logger.LogInformation($"TourOperator with ID {TourOperatorInput.Id} updated successfully");
            return RedirectToPage("/Admin/TourOperators/Index");
        }

        logger.LogWarning($"Failed to update tourOperator with ID {TourOperatorInput.Id}");
        return Page();
    }
}