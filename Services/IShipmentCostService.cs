using MiniCore.Logistics.Mvc.ViewModels;

namespace MiniCore.Logistics.Mvc.Services;

public interface IShipmentCostService
{
    Task<IReadOnlyList<ShipmentCostResultViewModel>> GetCostsByDriverAndZoneAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken);
}
