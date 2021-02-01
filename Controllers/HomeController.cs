using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moment2_mvc.Models;
using Newtonsoft.Json;

namespace moment2_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Info = "This paragraph is brought to you by ViewBag.";
            return View();
        }
    }

}
