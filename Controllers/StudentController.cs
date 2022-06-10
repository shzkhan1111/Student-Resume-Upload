using Microsoft.AspNetCore.Mvc;
using shahzaib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shahzaib.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext )
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> students = applicationDbContext.Students;
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                applicationDbContext.Students.Add(student);
                applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }

        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
                return NotFound();
            var std = applicationDbContext.Students.Find(id);

            if (std == null)
            {
                return NotFound();

            }

            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            
            var std = applicationDbContext.Students.Find(student.Id);
            std.Name = student.Name;
            std.CNIC = student.CNIC;

            applicationDbContext.Students.Update(std);
            applicationDbContext.SaveChanges();
            if (std == null)
            {
                return NotFound();

            }

            return RedirectToAction("Index");
        }

    }
}
