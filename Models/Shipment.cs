using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniCore.Logistics.Mvc.Models;

[Table("Envios")]
public class Shipment
{
    [Key]
    [Column("id_envio")]
    public int Id { get; set; }

    [Column("id_repartidor")]
    public int DeliveryDriverId { get; set; }

    [Column("id_zona")]
    public int DeliveryZoneId { get; set; }

    [Column("peso_kg", TypeName = "decimal(10,2)")]
    public decimal WeightKg { get; set; }

    [Column("fecha_envio")]
    public DateTime ShipmentDate { get; set; }

    public DeliveryDriver DeliveryDriver { get; set; } = null!;

    public DeliveryZone DeliveryZone { get; set; } = null!;
}
