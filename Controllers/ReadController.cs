using Microsoft.AspNetCore.Mvc;

public class ReadController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
