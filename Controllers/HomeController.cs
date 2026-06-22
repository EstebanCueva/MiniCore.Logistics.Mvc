using Microsoft.AspNetCore.Mvc;

namespace MiniCore.Logistics.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return RedirectToAction("Index", "ShipmentCosts");
    }

    public IActionResult Error()
    {
        return View();
    }
}
