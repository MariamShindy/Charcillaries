using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Airlines;

public class IndexModel(ILogger<IndexModel> logger, IAirlineRepository airlineManagementRepository)
    : PageModel
{
    public List<AirlineListView> Airlines { get; set; } = [];

    public async Task OnGet(string? sort)
    {
        Airlines = await airlineManagementRepository.GetAirlinesAsync();
        logger.LogInformation("Airlines data fetched successfully");
        Airlines = sort switch
        {
            "nameAsc" => Airlines.OrderBy(a => a.Name).ToList(),
            "nameDes" => Airlines.OrderByDescending(a => a.Name).ToList(),
            "emailAsc" => Airlines.OrderBy(a => a.Email).ToList(),
            "emailDes" => Airlines.OrderByDescending(a => a.Email).ToList(),
            _ => Airlines
        };
    }

    public async Task<IActionResult> OnPost(string id)
    {
        logger.LogInformation("Attempting to delete airline with ID: {AirlineId}", Hash.DecodeToInt(id));
        await airlineManagementRepository.RemoveAirlineAsync(Hash.DecodeToInt(id));
        return RedirectToPage();
    }
}