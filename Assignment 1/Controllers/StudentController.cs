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
        private readonly StudentDbContext _studentDbContext; //declare a database context to interact with the database on the server

        public StudentController(StudentDbContext context) //assign context instance to private context
        {
            _studentDbContext = context;
        }

        //some things are done asynchronously to improve responsiveness of web app

        [HttpGet("/students/edit/{student?}")]
        public async Task<IActionResult> Edit(int id) //accept id of student whose edit link was clicked on list page
        {
            StudentViewModel studentViewModel = new StudentViewModel() //create new studentViewModel to send to the edit page
            {
                Programs = await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync(), //make a list of the different programs of study
                ActiveStudent = await _studentDbContext.Students.FindAsync(id) //find the student to edit based on the ID, and set that student instance to the active student
            };

            return View(studentViewModel);
        }


        [HttpPost("/students/edit/{student?}")]
        public async Task<IActionResult> Edit(StudentViewModel studentViewModel) //accept the studentViewModel that was generated and pushed to the view when user clicks edit on student in list
        {
            if (ModelState.IsValid) //if all validations succeed
            {
                studentViewModel.ActiveStudent.GetAge(); //generate the age of the student based on the given date of birth
                studentViewModel.ActiveStudent.GetGpaScale(); //generate the gpa scale based on the given GPA
                _studentDbContext.Students.Update(studentViewModel.ActiveStudent); //update the active student in the list of students in the context instance
                await _studentDbContext.SaveChangesAsync(); //push the updated context instance to the database
                return RedirectToAction("List", "Students"); //return to the list page
            }
            else
            {
                studentViewModel.Programs = await _studentDbContext.Programs.OrderBy(p => p.SchoolProgramName).ToListAsync(); //if validations fail, remake the programs list
                return View(studentViewModel); //send viewmodel back to the same page
            }
        }

        [HttpGet("/students/delete/{student?}")]
        public IActionResult Delete(int id) //accept id of student whose delete link was clicked on list page
        {
            var student = _studentDbContext.Students.Find(id); //find student that corresponds to accepted ID
            return View(student); //send correct student instance to the delete page
        }


        [HttpPost("/students/delete/{student?}")]
        public async Task<IActionResult> DeleteConfirmed(Student student) //accept student that was pushed to the view from previous action
        {
            _studentDbContext.Students.Remove(student); //remove correct student instance from list of students in context instance
            await _studentDbContext.SaveChangesAsync(); // push the updated context instance to the database
            return RedirectToAction("List", "Students"); //return to the list page
        }
    }
}
