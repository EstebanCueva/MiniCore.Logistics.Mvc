namespace MiniCore.Logistics.Mvc.Services;

internal sealed class ShipmentCostAccumulator
{
    public string DriverName { get; set; } = string.Empty;

    public string ZoneName { get; set; } = string.Empty;

    public decimal RatePerKg { get; set; }

    public int ShipmentCount { get; set; }

    public decimal TotalKg { get; set; }

    public decimal TotalCost { get; set; }
}
