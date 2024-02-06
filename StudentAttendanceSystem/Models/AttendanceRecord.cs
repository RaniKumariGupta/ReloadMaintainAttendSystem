namespace StudentAttendanceSystem.Models
{
    public class AttendanceRecord
    {
        public int id { get; set; }
        public string? StudentName { get; set; }
        public string? Course { get; set; }
        public string? Level { get; set; }
        public DateTime DateOfAttendance { get; set; }
        public bool IsPresent { get; set; }
    }
}
