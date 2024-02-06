using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models
{
    public class Login
    {
        public int id { get; set; }
        public string? Email { get; set; }      
        public string? Password { get; set; }
    }
}
