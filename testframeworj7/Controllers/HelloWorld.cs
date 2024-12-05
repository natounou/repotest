using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using testframeworj7.Models;

namespace testframeworj7.Controllers;

public class HelloWorldController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HelloWorldController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}

