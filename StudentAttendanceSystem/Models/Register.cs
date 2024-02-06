using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models
{
    public class Register
    {
        public int id { get; set; }
        [Display(Name = "Student Name")]
       
        public string? StudentName { get; set; }
        public string? Course { get; set; }
        public string? Level { get; set; }
       
        public DateTime DateEnrolled { get; set; }
    }
}
