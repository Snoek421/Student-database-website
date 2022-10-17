using Assignment_1.Entities;
using Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment_1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentDbContext _studentDbContext; //construct a database context to interact with the database on the server

        public StudentsController(StudentDbContext context) //assign context instance to private context
        {
            _studentDbContext = context;
        }

        //some things are done asynchronously to improve responsiveness of web app

        [HttpGet("/students")]
        public async Task<IActionResult> List()
        {
            var allStudents = await _studentDbContext.Students.Include(m => m.SchoolProgram).OrderBy(m => m.LastName).ToListAsync(); //create list of students and programs to be sent to the list page
            return View(allStudents); //send list of students and programs to list page
        }

        [HttpGet("/students/new_student")]
        public async Task<IActionResult> Create()
        {
            StudentViewModel studentViewModel = new StudentViewModel() //create viewmodel to be sent to the create page
            {
                Programs = await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync(), //fill list of programs with list of program names from database
                ActiveStudent = new Student() //prepare new student instance to hold the newly created student's details
            };
            return View(studentViewModel); //send viewmodel to the create page
        }


        [HttpPost("/students/new_student")]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid) // if input is valid then add student to the database and redirect back to list action
            {
                studentViewModel.ActiveStudent.GetAge(); //generate student age based on input date of birth
                studentViewModel.ActiveStudent.GetGpaScale(); //generate gpa scale based on input GPA
                await _studentDbContext.Students.AddAsync(studentViewModel.ActiveStudent); //add newly created student to the students database collection
                _studentDbContext.SaveChanges(); //push updated database collections to the database
                TempData["alert"] = "Student Added Successfully.";
                return RedirectToAction("List", "students"); //return to list page
            }
            else // if it is invalid then just return the create view again
            {
                studentViewModel.Programs = await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync(); //remake programs list
                return View(studentViewModel); //send viewmodel back to the same page
            }
        }
    }
}
