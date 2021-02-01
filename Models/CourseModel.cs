using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace moment2_mvc.Models
{
    public class CourseModel
    {
        // Empty constructor
        public CourseModel() { }

        // Constructor to fill an object
        public CourseModel(int id, string code, string name, string url, string progression)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.Url = url;
            this.Progression = progression;
        }

        // Properties and validation 
        [Required]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        [MaxLength(2, ErrorMessage = "Max 2 signs")]
        public string Progression { get; set; }
    }

    public class Courses
    {
        public List<CourseModel> CourseDetailList { get; set; }
    }

    // Class for being able to display multiple models in one viewv.
    public class MergeCourseClasses
    {
        public CourseModel CourseDetails { get; set; }
        public List<CourseModel> CourseDetailList { get; set; }

        public MergeCourseClasses()
        {
            this.CourseDetails = new CourseModel();
        }
    }
}
