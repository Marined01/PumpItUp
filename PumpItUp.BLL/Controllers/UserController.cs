using Microsoft.AspNetCore.Mvc;

namespace PumpItUp.BLL.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}