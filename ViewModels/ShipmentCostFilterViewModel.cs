using System.ComponentModel.DataAnnotations;

namespace MiniCore.Logistics.Mvc.ViewModels;

public class ShipmentCostFilterViewModel
{
    [Display(Name = "Fecha Inicio")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = new DateTime(2025, 5, 1);

    [Display(Name = "Fecha Fin")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; } = new DateTime(2025, 5, 31);
}
