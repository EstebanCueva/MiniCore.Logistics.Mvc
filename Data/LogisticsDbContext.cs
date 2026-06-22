using Microsoft.EntityFrameworkCore;
using MiniCore.Logistics.Mvc.Models;

namespace MiniCore.Logistics.Mvc.Data;

public class LogisticsDbContext : DbContext
{
    public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options)
        : base(options)
    {
    }

    public DbSet<DeliveryDriver> DeliveryDrivers => Set<DeliveryDriver>();

    public DbSet<Shipment> Shipments => Set<Shipment>();

    public DbSet<DeliveryZone> DeliveryZones => Set<DeliveryZone>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DeliveryDriver>(ConfigureDeliveryDriver);
        modelBuilder.Entity<DeliveryZone>(ConfigureDeliveryZone);
        modelBuilder.Entity<Shipment>(ConfigureShipment);

        SeedData(modelBuilder);
    }

    private static void ConfigureDeliveryDriver(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryDriver> builder)
    {
        builder.Property(driver => driver.FullName).IsRequired().HasMaxLength(120);
        builder.Property(driver => driver.Email).HasMaxLength(160);
    }

    private static void ConfigureDeliveryZone(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryZone> builder)
    {
        builder.Property(zone => zone.ZoneName).IsRequired().HasMaxLength(80);
        builder.Property(zone => zone.RatePerKg).HasPrecision(10, 2);
    }

    private static void ConfigureShipment(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Shipment> builder)
    {
        builder.Property(shipment => shipment.WeightKg).HasPrecision(10, 2);

        builder.HasOne(shipment => shipment.DeliveryDriver)
            .WithMany(driver => driver.Shipments)
            .HasForeignKey(shipment => shipment.DeliveryDriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(shipment => shipment.DeliveryZone)
            .WithMany(zone => zone.Shipments)
            .HasForeignKey(shipment => shipment.DeliveryZoneId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeliveryDriver>().HasData(
            new { Id = 1, FullName = "Andrés Hidalgo", Email = "andres.hidalgo@logistica.com" },
            new { Id = 2, FullName = "Camila Torres", Email = "camila.torres@logistica.com" },
            new { Id = 3, FullName = "Luis Andrade", Email = "luis.andrade@logistica.com" },
            new { Id = 4, FullName = "Daniela Molina", Email = "daniela.molina@logistica.com" }
        );

        modelBuilder.Entity<DeliveryZone>().HasData(
            new { Id = 1, ZoneName = "Norte", RatePerKg = 1.50m },
            new { Id = 2, ZoneName = "Sur", RatePerKg = 2.00m },
            new { Id = 3, ZoneName = "Centro", RatePerKg = 1.25m },
            new { Id = 4, ZoneName = "Valle", RatePerKg = 1.80m }
        );

        modelBuilder.Entity<Shipment>().HasData(
            new { Id = 1, DeliveryDriverId = 1, DeliveryZoneId = 1, WeightKg = 5.00m, ShipmentDate = new DateTime(2025, 5, 2) },
            new { Id = 2, DeliveryDriverId = 1, DeliveryZoneId = 1, WeightKg = 6.00m, ShipmentDate = new DateTime(2025, 5, 5) },
            new { Id = 3, DeliveryDriverId = 1, DeliveryZoneId = 1, WeightKg = 7.00m, ShipmentDate = new DateTime(2025, 5, 9) },
            new { Id = 4, DeliveryDriverId = 1, DeliveryZoneId = 1, WeightKg = 8.00m, ShipmentDate = new DateTime(2025, 5, 12) },
            new { Id = 5, DeliveryDriverId = 1, DeliveryZoneId = 1, WeightKg = 6.00m, ShipmentDate = new DateTime(2025, 5, 25) },

            new { Id = 6, DeliveryDriverId = 2, DeliveryZoneId = 2, WeightKg = 4.00m, ShipmentDate = new DateTime(2025, 5, 3) },
            new { Id = 7, DeliveryDriverId = 2, DeliveryZoneId = 2, WeightKg = 6.00m, ShipmentDate = new DateTime(2025, 5, 16) },
            new { Id = 8, DeliveryDriverId = 2, DeliveryZoneId = 2, WeightKg = 8.00m, ShipmentDate = new DateTime(2025, 5, 28) },

            new { Id = 9, DeliveryDriverId = 3, DeliveryZoneId = 3, WeightKg = 10.00m, ShipmentDate = new DateTime(2025, 6, 2) },

            new { Id = 10, DeliveryDriverId = 4, DeliveryZoneId = 1, WeightKg = 3.50m, ShipmentDate = new DateTime(2025, 5, 6) },
            new { Id = 11, DeliveryDriverId = 4, DeliveryZoneId = 2, WeightKg = 5.25m, ShipmentDate = new DateTime(2025, 5, 15) },
            new { Id = 12, DeliveryDriverId = 4, DeliveryZoneId = 4, WeightKg = 4.00m, ShipmentDate = new DateTime(2025, 5, 21) },
            new { Id = 13, DeliveryDriverId = 4, DeliveryZoneId = 3, WeightKg = 2.75m, ShipmentDate = new DateTime(2025, 4, 26) }
        );
    }
}
