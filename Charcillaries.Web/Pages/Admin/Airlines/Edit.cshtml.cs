using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Charcillaries.Web.Pages.Admin.Airlines;

public class EditModel(
    ILogger<EditModel> logger,
    IAirlineRepository airlineManagementRepository)
    : PageModel
{
    [BindProperty] public AirlineUpdateInput AirlineInput { get; set; } = new();

    public AirlineDetailsView? AirlineDetailsView { get; set; }

    public async Task<IActionResult> OnGetAsync(string airlineId)
    {
        AirlineDetailsView = await airlineManagementRepository.GetAirlineAsync(Hash.DecodeToInt(airlineId));
        if (AirlineDetailsView == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string airlineId)
    {
        if (!ModelState.IsValid) return Page();
        AirlineInput.Id = Hash.DecodeToInt(airlineId);

        var result = await airlineManagementRepository.SaveAirlineAsync(AirlineInput);
        if (result)
        {
            logger.LogInformation($"Airline with ID {AirlineInput.Id} updated successfully");
            return RedirectToPage("/admin/airlines/index");
        }

        logger.LogWarning($"Failed to update airline with ID {AirlineInput.Id}");
        return Page();
    }
}