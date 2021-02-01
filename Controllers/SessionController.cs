using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moment2_mvc.Models;
using Newtonsoft.Json;

namespace moment2_mvc.Controllers
{
    public class SessionController : Controller
    {
        // Read existing data.
        [HttpGet]
        public IActionResult Index()
        {
            string s = HttpContext.Session.GetString("SavedList");
            List<CourseModel> coursesList = new List<CourseModel>();

            // Get session variable if string is not null or empty.
            if ((s != null) || (s == ""))
            {
                coursesList = JsonConvert.DeserializeObject<List<CourseModel>>(s);
            }
            else
            {
                coursesList = new List<CourseModel>
                {
                    new CourseModel(0, "DT102G", "ASP.NET Core med C#", "https://www.miun.se/utbildning/kursplaner-och-utbildningsplaner/Sok-kursplan/kursplan/?kursplanid=22325", "B")
                };
            }

            string s2 = JsonConvert.SerializeObject(coursesList);
            // Session variable saving.
            HttpContext.Session.SetString("SavedList", s2);
            return View(coursesList);
        }

        // Delete data.
        [HttpGet]
        public IActionResult Delete(int id)
        {
            string s = HttpContext.Session.GetString("SavedList");
            List<CourseModel> coursesList = new List<CourseModel>();

            if ((s != null) || (s == ""))
            {
                coursesList = JsonConvert.DeserializeObject<List<CourseModel>>(s);
            }
            else
            {
                return RedirectToAction("Index");
            }
            coursesList.RemoveAll(x => x.Id == id);
            s = JsonConvert.SerializeObject(coursesList);
            // Session variable saving.
            HttpContext.Session.SetString("SavedList", s);

            return RedirectToAction("Index");
        }
    }
}
