using Microsoft.EntityFrameworkCore;
using MiniCore.Logistics.Mvc.Data;
using MiniCore.Logistics.Mvc.Models;
using MiniCore.Logistics.Mvc.ViewModels;

namespace MiniCore.Logistics.Mvc.Services;

public class ShipmentCostService : IShipmentCostService
{
    private readonly LogisticsDbContext _dbContext;

    public ShipmentCostService(LogisticsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<ShipmentCostResultViewModel>> GetCostsByDriverAndZoneAsync(
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken)
    {
        DateTime normalizedStartDate = startDate.Date;
        DateTime normalizedEndDate = endDate.Date;

        List<Shipment> shipments = await _dbContext.Shipments
            .AsNoTracking()
            .Include(shipment => shipment.DeliveryDriver)
            .Include(shipment => shipment.DeliveryZone)
            .Where(shipment => shipment.ShipmentDate >= normalizedStartDate
                && shipment.ShipmentDate <= normalizedEndDate)
            .OrderBy(shipment => shipment.DeliveryDriver.FullName)
            .ThenBy(shipment => shipment.DeliveryZone.ZoneName)
            .ToListAsync(cancellationToken);

        Dictionary<string, ShipmentCostAccumulator> accumulators = new Dictionary<string, ShipmentCostAccumulator>();

        foreach (Shipment shipment in shipments)
        {
            string key = string.Concat(shipment.DeliveryDriverId.ToString(), "-", shipment.DeliveryZoneId.ToString());
            decimal shipmentCost = shipment.WeightKg * shipment.DeliveryZone.RatePerKg;

            if (!accumulators.TryGetValue(key, out ShipmentCostAccumulator? accumulator))
            {
                accumulator = new ShipmentCostAccumulator
                {
                    DriverName = shipment.DeliveryDriver.FullName,
                    ZoneName = shipment.DeliveryZone.ZoneName,
                    RatePerKg = shipment.DeliveryZone.RatePerKg,
                    ShipmentCount = 0,
                    TotalKg = 0m,
                    TotalCost = 0m
                };

                accumulators.Add(key, accumulator);
            }

            accumulator.ShipmentCount += 1;
            accumulator.TotalKg += shipment.WeightKg;
            accumulator.TotalCost += shipmentCost;
        }

        List<ShipmentCostResultViewModel> results = accumulators.Values
            .Select(accumulator => new ShipmentCostResultViewModel
            {
                DriverName = accumulator.DriverName,
                ShipmentCount = accumulator.ShipmentCount,
                TotalKg = accumulator.TotalKg,
                ZoneName = accumulator.ZoneName,
                RatePerKg = accumulator.RatePerKg,
                TotalCost = accumulator.TotalCost
            })
            .OrderBy(result => result.DriverName)
            .ThenBy(result => result.ZoneName)
            .ToList();

        return results;
    }
}
