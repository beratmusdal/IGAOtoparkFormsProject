using System.Diagnostics;
using IGASecForms.Models;
using Microsoft.AspNetCore.Mvc;

namespace IGASecForms.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
