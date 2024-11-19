using Microsoft.AspNetCore.Mvc;

namespace Wallet.Wise.WebApp.Controllers;

public class RecordsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}