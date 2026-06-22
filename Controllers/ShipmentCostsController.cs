using Microsoft.AspNetCore.Mvc;
using MiniCore.Logistics.Mvc.Services;
using MiniCore.Logistics.Mvc.ViewModels;

namespace MiniCore.Logistics.Mvc.Controllers;

public class ShipmentCostsController : Controller
{
    private readonly IShipmentCostService _shipmentCostService;

    public ShipmentCostsController(IShipmentCostService shipmentCostService)
    {
        _shipmentCostService = shipmentCostService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken)
    {
        DateTime effectiveStartDate = startDate ?? new DateTime(2025, 5, 1);
        DateTime effectiveEndDate = endDate ?? new DateTime(2025, 5, 31);

        ShipmentCostPageViewModel pageViewModel = new ShipmentCostPageViewModel
        {
            Filter = new ShipmentCostFilterViewModel
            {
                StartDate = effectiveStartDate,
                EndDate = effectiveEndDate
            }
        };

        if (effectiveStartDate.Date > effectiveEndDate.Date)
        {
            ModelState.AddModelError(string.Empty, "La fecha de inicio no puede ser mayor que la fecha fin.");
            return View(pageViewModel);
        }

        IReadOnlyList<ShipmentCostResultViewModel> results = await _shipmentCostService.GetCostsByDriverAndZoneAsync(
            effectiveStartDate,
            effectiveEndDate,
            cancellationToken);

        pageViewModel.Results = results;
        pageViewModel.TotalShipments = results.Sum(result => result.ShipmentCount);
        pageViewModel.TotalKg = results.Sum(result => result.TotalKg);
        pageViewModel.GrandTotalCost = results.Sum(result => result.TotalCost);

        return View(pageViewModel);
    }
}
