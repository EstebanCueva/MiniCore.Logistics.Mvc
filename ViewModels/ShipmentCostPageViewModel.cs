namespace MiniCore.Logistics.Mvc.ViewModels;

public class ShipmentCostPageViewModel
{
    public ShipmentCostFilterViewModel Filter { get; set; } = new ShipmentCostFilterViewModel();

    public IReadOnlyList<ShipmentCostResultViewModel> Results { get; set; } = new List<ShipmentCostResultViewModel>();

    public int TotalShipments { get; set; }

    public decimal TotalKg { get; set; }

    public decimal GrandTotalCost { get; set; }
}
