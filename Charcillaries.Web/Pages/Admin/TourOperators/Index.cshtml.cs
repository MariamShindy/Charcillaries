using Charcillaries.Core;
using Charcillaries.Core.Features.TourOperator;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.TourOperators;

public class IndexModel(
    ILogger<IndexModel> logger,
    ITourOperatorRepository tourOperatorManagementRepository) : PageModel
{
    public List<TourOperatorDetailsView> TourOperators { get; set; } = [];

    public async Task OnGetAsync(string? sort)
    {
        TourOperators = await tourOperatorManagementRepository.GetTourOperatorsAsync();
        switch (sort)
        {
            case "nameAsc":
                TourOperators = TourOperators.OrderBy(t => t.Name).ToList();
                break;

            case "nameDes":
                TourOperators = TourOperators.OrderByDescending(t => t.Name).ToList();
                break;
        }

        logger.LogInformation("TourOperators data fetched successfully");
    }

    public async Task<IActionResult> OnPost(string id)
    {
        await tourOperatorManagementRepository.RemoveTourOperatorAsync(Hash.DecodeToInt(id));
        logger.LogInformation("deleted tour operator with ID: {TourOperatorId}", id);
        return RedirectToPage();
    }
}