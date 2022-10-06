using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment_1.Entities;
using Assignment_1.Models;

namespace Assignment_1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext context)
        {
            _studentDbContext = context;
        }


        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Programs = await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync(),
                ActiveStudent = await _studentDbContext.Students.FindAsync(id)
            };

            return View(studentViewModel);
        }


        [HttpPost()]
        public async Task<IActionResult> Edit(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                studentViewModel.ActiveStudent.GetAge();
                studentViewModel.ActiveStudent.GetGpaScale();
                _studentDbContext.Students.Update(studentViewModel.ActiveStudent);
                await _studentDbContext.SaveChangesAsync();
                return RedirectToAction("List", "Students");
            }
            else
            {
                studentViewModel.Programs = await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync();
                return View(studentViewModel);
            }
        }

        [HttpGet()]
        public IActionResult Delete(int id)
        {
            var student = _studentDbContext.Students.Find(id);
            return View(student);
        }

        
        [HttpPost()]
        public async Task<IActionResult> DeleteConfirmed(Student student)
        {
           _studentDbContext.Students.Remove(student);
            await _studentDbContext.SaveChangesAsync();
            return RedirectToAction("List", "Students");
        }
    }
}
