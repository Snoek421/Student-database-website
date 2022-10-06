﻿using Assignment_1.Entities;
using Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentsController(StudentDbContext context)
        {
            _studentDbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var allStudents = await _studentDbContext.Students.Include(m => m.SchoolProgram).OrderBy(m => m.FirstName).ToListAsync();
            return View(allStudents);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Programs = await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync(),
                ActiveStudent = new Student()
            };
            return View(studentViewModel);
        }


        [HttpPost()]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid) // if input is valid then add student to the database and redirect back to list action
            {
                studentViewModel.ActiveStudent.GetAge();
                studentViewModel.ActiveStudent.GetGpaScale();
                await _studentDbContext.Students.AddAsync(studentViewModel.ActiveStudent);
                _studentDbContext.SaveChanges();
                return RedirectToAction("List", "students");
            }
            else // if it is invalid then just return the create view again
            {
                studentViewModel.Programs =  await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync();
                return View(studentViewModel);
            }
        }
    }
}
