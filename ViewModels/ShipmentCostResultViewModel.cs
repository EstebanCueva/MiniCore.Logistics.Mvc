namespace MiniCore.Logistics.Mvc.ViewModels;

public class ShipmentCostResultViewModel
{
    public string DriverName { get; set; } = string.Empty;

    public int ShipmentCount { get; set; }

    public decimal TotalKg { get; set; }

    public string ZoneName { get; set; } = string.Empty;

    public decimal RatePerKg { get; set; }

    public decimal TotalCost { get; set; }
}
