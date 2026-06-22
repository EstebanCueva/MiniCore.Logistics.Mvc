using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniCore.Logistics.Mvc.Models;

[Table("Repartidor")]
public class DeliveryDriver
{
    [Key]
    [Column("id_repartidor")]
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    [Column("nombre")]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(160)]
    [Column("email")]
    public string? Email { get; set; }

    public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
