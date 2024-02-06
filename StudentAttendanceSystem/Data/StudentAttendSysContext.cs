using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Models;

    public class StudentAttendSysContext : DbContext
    {
        public StudentAttendSysContext (DbContextOptions<StudentAttendSysContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAttendanceSystem.Models.Register> Register { get; set; } = default!;

public DbSet<StudentAttendanceSystem.Models.Login> Login { get; set; } = default!;

public DbSet<StudentAttendanceSystem.Models.Course> Course { get; set; } = default!;

public DbSet<StudentAttendanceSystem.Models.Level> Level { get; set; } = default!;

public DbSet<StudentAttendanceSystem.Models.Dashboard> Dashboard { get; set; } = default!;

public DbSet<StudentAttendanceSystem.Models.AttendanceRecord> AttendanceRecord { get; set; } = default!;
    }
