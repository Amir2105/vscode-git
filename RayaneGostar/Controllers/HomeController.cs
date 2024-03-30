using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RayaneGostar.Models;

namespace RayaneGostar.Controllers;

public class HomeController : SiteBaseController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}    

