using Charcillaries.Core;
using Charcillaries.Core.Features.TourOperator;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.TourOperators;

public class DetailsModel(ITourOperatorRepository repo)
    : PageModel
{
    public TourOperatorDetailsView? TourOperator { get; set; }

    public async Task<IActionResult> OnGet(string tourOperatorId)
    {
        TourOperator = await repo.GetTourOperatorAsync(Hash.DecodeToInt(tourOperatorId));

        if (TourOperator == null)
            return NotFound();
        return Page();
    }
}