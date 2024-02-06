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
    public class RegistersController : Controller
    {
        private readonly StudentAttendSysContext _context;

        public RegistersController(StudentAttendSysContext context)
        {
            _context = context;
        }

        // GET: Registers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Register.ToListAsync());
        }

        // GET: Registers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .FirstOrDefaultAsync(m => m.id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Registers/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Courses = await _context.Course.Select(c => c.CourseName).ToListAsync();
            ViewBag.Levels = await _context.Level.Select(l => l.LevelName).ToListAsync();

            var getCourseData = await _context.Course.ToListAsync();
            var getLevelData = await _context.Level.ToListAsync();


            List<SelectListItem> courselist = new List<SelectListItem>();
            List<SelectListItem> levellist = new List<SelectListItem>();

            foreach (var course in getCourseData)
            {
                courselist.Add(new SelectListItem
                {
                    Text = course.CourseName,
                    Value = course.CourseName
                    //Value = course.CourseId.ToString()
                });
            }
            foreach (var level in getLevelData)
            {
                levellist.Add(new SelectListItem
                {
                    Text = level.LevelName,
                    Value = level.LevelName
                    //Value = course.CourseId.ToString()
                });
            }
            ViewData["CourseData"] = courselist;
            ViewData["LevelData"] = levellist;

            return View();
        }
        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,StudentName,Course,Level,DateEnrolled")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Registers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: Registers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,StudentName,Course,Level,DateEnrolled")] Register register)
        {
            if (id != register.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Registers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Register
                .FirstOrDefaultAsync(m => m.id == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var register = await _context.Register.FindAsync(id);
            if (register != null)
            {
                _context.Register.Remove(register);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.id == id);
        }
    }
}
