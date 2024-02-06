using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceSystem.Models;

namespace StudentAttendanceSystem.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly StudentAttendSysContext _context;

        public DashboardsController(StudentAttendSysContext context)
        {
            _context = context;
        }

        // GET: Dashboards
        public IActionResult Index()
        {
            // Fetch student data
            var students = _context.Register.Select(s => new Dashboard
            {
                StudentName = s.StudentName,
                Course = s.Course,
                Level = s.Level,
                StudentId = s.id,
            }).ToList();

            // Populate ViewBag with available courses and levels
            ViewBag.Courses = _context.Register.Select(s => s.Course).Distinct().ToList();
            ViewBag.Levels = _context.Register.Select(s => s.Level).Distinct().ToList();
            // Pass student data to the view
            return View(students);

            /*return View(await _context.Dashboard.ToListAsync());*/
        }

        [HttpPost]
        public IActionResult Index([FromBody] List<Dashboard> modelData)
        {
            return Json("Data Added successfully");
            try
            {
                // Ensure the ModelState is valid before proceeding
                if (ModelState.IsValid)
                {
                    // Save attendance to the database
                    _context.Dashboard.AddRange((IEnumerable<Dashboard>)modelData);
                    _context.SaveChanges();

                    // Redirect to the attendance view or another appropriate page
                    return RedirectToAction("Index");
                }

                // If ModelState is not valid, return to the same view with validation errors
                var students = _context.Register.ToList();
                return View("Index", students);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult SaveAttendance([FromBody] List<Dashboard> attendanceList)
        {
            try
            {
                // Ensure the ModelState is valid before proceeding
                if (ModelState.IsValid)
                {
                    // Save attendance to the database
                    _context.Dashboard.AddRange(attendanceList);
                    _context.SaveChanges();

                    // Redirect to the attendance view or another appropriate page
                    return RedirectToAction("Index");
                }

                // If ModelState is not valid, return to the same view with validation errors
                var students = _context.Dashboard.ToList();
                return View("Index", students);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log the error)
                return View("Error");
            }

        }

        /*[HttpPost]
        public IActionResult SaveData([FromBody] AttendanceRecord data)
        {
            // Save data to the database
            _context.AttendanceRecord.Add(data);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        // New action to display saved data in another table
        public IActionResult DisplayData()
        {
            var savedData = _context.AttendanceRecord.ToList();
            return View(savedData);
        }*/

        private bool DashboardExists(int Id)
        {
            return _context.Dashboard.Any(e => e.Id == Id);
        }
    }
}
