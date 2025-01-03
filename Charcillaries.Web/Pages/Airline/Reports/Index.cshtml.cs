using Charcillaries.Core;
using Charcillaries.Core.Features.Airline;
using Charcillaries.Core.Features.Service;
using Charcillaries.Data.Views.DtoClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Security.Claims;

namespace Charcillaries.Web.Pages.Airline.Reports;

public class IndexModel(ILogger<IndexModel> logger, IAirlineRepository repo, IStringLocalizer<ServiceLocalization> LS, IStringLocalizer<Global> L, IStringLocalizer<AirlineLocalization> LA) : PageModel
{
    [BindProperty]
    public string ReportType { get; set; } = string.Empty;

    public List<FlightRouteListView> Routes { get; set; } = [];
    public List<AmenitiesListView> Amenities { get; set; } = [];

    public List<ReportData> reportData { get; set; } = [];
    public float AmenityRevenue = 0.0f;

    public async Task<IActionResult> OnGetAsync()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Routes = await repo.GetAirlineRoutesAsync(airlineId);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        logger.LogInformation("Generating reports");

        if (ReportType == "TopSelectedServices")
        {
            await FetchTopSelectedReportData();
            TempData["ReportData"] = JsonConvert.SerializeObject(reportData);
            logger.LogInformation($"Fetched {reportData.Count} report data items.");
            return Partial("_ReportContent", reportData);
        }
        else if (ReportType == "TopRatedServices")
        {
            await FetchTopRatedReportData();
            TempData["ReportData"] = JsonConvert.SerializeObject(reportData);
            logger.LogInformation($"Fetched {reportData.Count} report data items.");
            return Partial("_TopRatedServices", reportData);
        }
        else if (ReportType == "TopRevenue")
        {
            await FetchTopRevenueReportData();
            TempData["ReportData"] = JsonConvert.SerializeObject(reportData);
            logger.LogInformation($"Fetched {reportData.Count} report data items.");
            return Partial("_TopRevenueServices", reportData);
        }
        else
        {
            logger.LogWarning("Unsupported report type.");
            return Page();
        }
    }

    public IActionResult OnPostExportToExcel()
    {
        logger.LogInformation("Exporting to Excel");

        var reportDataJson = TempData["ReportData"] as string;
        if (string.IsNullOrEmpty(reportDataJson))
        {
            logger.LogWarning("No report data available for export.");
            return BadRequest("No report data available for export.");
        }

        var reportData = JsonConvert.DeserializeObject<List<ReportData>>(reportDataJson);

        var stream = new MemoryStream();
        using (var package = new ExcelPackage(stream))
        {
            var worksheet = package.Workbook.Worksheets.Add("Report");
            if (reportData != null && reportData.Any(r => r.TimesSelected != string.Empty))
            {
                worksheet.Cells["A1"].Value = L["name"];
                worksheet.Cells["B1"].Value = LS["times-selected"];
                worksheet.Cells["C1"].Value = LA["number-of-routes"];
                worksheet.Cells["D1"].Value = LS["total-revenue"] + L["egp"];
                worksheet.Cells["E1"].Value = LS["service-status"];
            }
            else if (reportData != null && reportData.Any(r => r.Rating != string.Empty))
            {
                worksheet.Cells["A1"].Value = L["name"];
                worksheet.Cells["B1"].Value = LS["average-rating"];
                worksheet.Cells["C1"].Value = LA["number-of-routes"];
                worksheet.Cells["D1"].Value = LS["total-revenue"] + L["egp"];
                worksheet.Cells["E1"].Value = LS["service-status"];
            }
            else
            {
                worksheet.Cells["A1"].Value = L["name"];
                worksheet.Cells["B1"].Value = LS["total-revenue"] + L["egp"];
                worksheet.Cells["C1"].Value = LA["number-of-routes"];
                worksheet.Cells["D1"].Value = LS["service-status"];
            }

            for (int i = 0; i < reportData?.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = reportData[i].ServiceName;
                if (reportData[i].TimesSelected != string.Empty)
                {
                    worksheet.Cells[i + 2, 2].Value = reportData[i].TimesSelected;
                    worksheet.Cells[i + 2, 3].Value = reportData[i].Routes;
                    worksheet.Cells[i + 2, 4].Value = reportData[i].Revenue;
                    worksheet.Cells[i + 2, 5].Value = reportData[i].Status;
                }
                else if (reportData[i].Rating != string.Empty)
                {
                    worksheet.Cells[i + 2, 2].Value = reportData[i].Rating;
                    worksheet.Cells[i + 2, 3].Value = reportData[i].Routes;
                    worksheet.Cells[i + 2, 4].Value = reportData[i].Revenue;
                    worksheet.Cells[i + 2, 5].Value = reportData[i].Status;
                }
                else
                {
                    worksheet.Cells[i + 2, 2].Value = reportData[i].Revenue;
                    worksheet.Cells[i + 2, 3].Value = reportData[i].Routes;
                    worksheet.Cells[i + 2, 4].Value = reportData[i].Status;
                }
            }

            package.Save();
        }

        stream.Position = 0;
        string excelName = $"Report-{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
    }

    private async Task<List<ReportData>> FetchTopSelectedReportData()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));

        Amenities = await repo.GetReportAmenitiesAsync(airlineId, "TopSelected");
        Amenities = Amenities.OrderByDescending(a => a.RouteAmenities
            .Sum(ra => ra.PassengerAmenitySelections.Count()))
        .Take(5).ToList();
        logger.LogInformation("after retreivinggg");
        if (Amenities == null || !Amenities.Any())
        {
            logger.LogWarning("No amenities found.");
            return [];
        }
        reportData.Clear();

        foreach (var amenity in Amenities)
        {
            var amenityStatus = "";

            var amenityRevenue = await repo.GetAmenityRevenue(amenity.Id);

            var amenitySelected = await repo.GetAmenitySelections(amenity.Id);

            if (amenity.ObjectStatus == 0)
            {
                amenityStatus = LS["disabled"];
            }
            else if (amenity.ObjectStatus == 1)
            {
                amenityStatus = LS["enabled"];
            }

            reportData.Add(new ReportData
            {
                ServiceName = amenity.Name,
                TimesSelected = amenitySelected.ToString(),
                Routes = amenity.RouteAmenities.Count.ToString(),
                Revenue = amenityRevenue.ToString(),
                Status = amenityStatus
            });
        }

        logger.LogInformation($"ReportData has {reportData.Count} items.");
        return reportData;
    }

    private async Task<List<ReportData>> FetchTopRatedReportData()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Amenities = await repo.GetReportAmenitiesAsync(airlineId, "TopRated");

        if (Amenities == null || !Amenities.Any())
        {
            logger.LogWarning("No amenities found.");
            return [];
        }
        reportData.Clear();

        foreach (var amenity in Amenities)
        {
            var amenityStatus = "";
            var amenityRevenue = await repo.GetAmenityRevenue(amenity.Id);
            var amenityRating = await repo.GetAmenityAverageRating(amenity.Id);
            if (amenity.ObjectStatus == 0)
            {
                amenityStatus = LS["disabled"];
            }
            else
            {
                amenityStatus = LS["enabled"];
            }
            reportData.Add(new ReportData
            {
                ServiceName = amenity.Name,
                Rating = amenityRating.ToString(),
                Routes = amenity.RouteAmenities.Count.ToString(),
                Revenue = amenityRevenue.ToString(),
                Status = amenityStatus
            });
        }

        logger.LogInformation($"ReportData has {reportData.Count} items.");
        return reportData;
    }

    private async Task<List<ReportData>> FetchTopRevenueReportData()
    {
        var airlineId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.Sid));
        Amenities = await repo.GetReportAmenitiesAsync(airlineId, "TopSelected");

        if (Amenities == null || !Amenities.Any())
        {
            logger.LogWarning("No amenities found.");
            return [];
        }
        reportData.Clear();

        foreach (var amenity in Amenities)
        {
            var amenityStatus = "";
            var amenityRevenue = await repo.GetAmenityRevenue(amenity.Id);
            if (amenity.ObjectStatus == 0)
            {
                amenityStatus = LS["disabled"];
            }
            else
            {
                amenityStatus = LS["enabled"];
            }
            reportData.Add(new ReportData
            {
                ServiceName = amenity.Name,
                Routes = amenity.RouteAmenities.Count.ToString(),
                Revenue = amenityRevenue.ToString(),
                Status = amenityStatus
            });
        }
        reportData = reportData.OrderByDescending(data => decimal.Parse(data.Revenue)).ToList();
        logger.LogInformation($"ReportData has {reportData.Count} items.");
        return reportData;
    }

    public class ReportData
    {
        public string ServiceName { get; set; } = string.Empty;
        public string TimesSelected { get; set; } = string.Empty;
        public string Revenue { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Routes { get; set; } = string.Empty;
    }
}