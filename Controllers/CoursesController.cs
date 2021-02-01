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
    public class CoursesController : Controller
    {

        // Read existing data.
        [HttpGet]
        public IActionResult Index()
        {
            string s = HttpContext.Session.GetString("SavedList");
            MergeCourseClasses mergedObj = new MergeCourseClasses();

            // Get session variable and deserialize if string is not/empty.
            if ((s != null) || (s == ""))
            {
                mergedObj.CourseDetailList = JsonConvert.DeserializeObject<List<CourseModel>>(s);
            }
            else
            {
                List<CourseModel> courseList = new List<CourseModel>
                {
                    new CourseModel(0, "DT102G", "ASP.NET Core med C#", "https://www.miun.se/utbildning/kursplaner-och-utbildningsplaner/Sok-kursplan/kursplan/?kursplanid=22325", "B")         
                };
                mergedObj.CourseDetailList = courseList; 
            }

            string s2 = JsonConvert.SerializeObject(mergedObj.CourseDetailList);
            // Session variable saving.
            HttpContext.Session.SetString("SavedList", s2);
            return View(mergedObj);
        }

        // Save posted data from form.
        [HttpPost]
        public IActionResult Index(MergeCourseClasses c)
        {
            string s = HttpContext.Session.GetString("SavedList");
            MergeCourseClasses mergedObj = new MergeCourseClasses();

            if ((s != null) || (s == ""))
            {
                mergedObj.CourseDetailList = JsonConvert.DeserializeObject<List<CourseModel>>(s);          
            }
            else
            {
                return RedirectToAction("Index");
            }

            // Validate input fields before posting.
            if (ModelState.IsValid)
            {
                mergedObj.CourseDetails.Id = c.CourseDetails.Id;
                mergedObj.CourseDetails.Code = c.CourseDetails.Code;
                mergedObj.CourseDetails.Name = c.CourseDetails.Name;
                mergedObj.CourseDetails.Url = c.CourseDetails.Url;
                mergedObj.CourseDetails.Progression = c.CourseDetails.Progression;
                mergedObj.CourseDetailList.Add(mergedObj.CourseDetails);

                s = JsonConvert.SerializeObject(mergedObj.CourseDetailList);
                HttpContext.Session.SetString("SavedList", s);

                return RedirectToAction("Index");
            }
            return View(mergedObj);
        }

        // Delete data.
        [HttpGet]
        public IActionResult Delete(int id)
        {
            string s = HttpContext.Session.GetString("SavedList");
            MergeCourseClasses mergedObj = new MergeCourseClasses();

            if ((s != null) || (s == ""))
            {
                mergedObj.CourseDetailList = JsonConvert.DeserializeObject<List<CourseModel>>(s);
            }
            else
            {
                return RedirectToAction("Index");
            }
            mergedObj.CourseDetailList.RemoveAll(x => x.Id == id);
            s = JsonConvert.SerializeObject(mergedObj.CourseDetailList);
            HttpContext.Session.SetString("SavedList", s);

            return RedirectToAction("Index");
        }
    }
}
