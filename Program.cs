using Microsoft.EntityFrameworkCore;
using MiniCore.Logistics.Mvc.Data;
using MiniCore.Logistics.Mvc.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LogisticsDbContext>(optionsBuilder =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=logistics.db";

    optionsBuilder.UseSqlite(connectionString);
});

builder.Services.AddScoped<IShipmentCostService, ShipmentCostService>();

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    LogisticsDbContext dbContext = scope.ServiceProvider.GetRequiredService<LogisticsDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ShipmentCosts}/{action=Index}/{id?}");

app.Run();
