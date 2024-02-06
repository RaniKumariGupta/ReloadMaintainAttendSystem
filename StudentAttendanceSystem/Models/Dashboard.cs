using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        public string? StudentName { get; set; }

        public string? Course { get; set; }

        public string? Level { get; set; }

        [Display(Name = "Date of Attendance")]
        [DataType(DataType.Date)]
        public DateTime DateOfAttendance { get; set; }
        public bool isPresent { get; set; }
    }
}
