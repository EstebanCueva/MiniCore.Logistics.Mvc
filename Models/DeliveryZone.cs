using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniCore.Logistics.Mvc.Models;

[Table("Zonas")]
public class DeliveryZone
{
    [Key]
    [Column("id_zona")]
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    [Column("nombre_zona")]
    public string ZoneName { get; set; } = string.Empty;

    [Column("tarifa_por_kg", TypeName = "decimal(10,2)")]
    public decimal RatePerKg { get; set; }

    public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
