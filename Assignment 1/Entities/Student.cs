using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Entities
{
    public class Student
    {

        public int StudentID { get; set; } //primary key for students table

        [Required(ErrorMessage = "Please enter a first name")] //first and last names are required, if not given then error messages show on page
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please choose a date of birth")] //date of birth is required, if not given then error messages show on page
        public string? DateOfBirth { get; set; } //stored as string to simplify interactions with the html page, textbox, and jquery ui datepicker

        [Required(ErrorMessage = "Please input a valid GPA")] //gpa is required
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")] //if input gpa is not between 0 and 4.0, this error message is shown
        public double? GPA { get; set; }

        private string? gpaScale; 
        public string? GpaScale
        {
            get { return gpaScale; } // exposes the gpa scale field to be retrieved
            private set { } //prevents access to setting the gpa scale value from outside the class
        }

        private int? age;

        public int? Age
        {
            get { return age; } //exposes the private age field to be retrieved
            private set { } //prevents access to setting the age value from outside the class
        }


        [Required(ErrorMessage = "Please add a program of study")] //program is required, error shows if not provided
        public string? SchoolProgramID { get; set; } //acts as foreign key in students table, from programs table

        public SchoolProgram? SchoolProgram { get; set; } // holds the details for the program the student is in

        public void GetGpaScale() //calculates and sets the correct private gpa scale, keeping it as a read-only outside the class aside from this method
        {
            if (this.GPA >= 4.0)
            {
                gpaScale = "Excellent";
            }
            else if (this.GPA >= 3.5 && this.GPA < 4.0)
            {
                gpaScale = "Very Good";
            }
            else if (this.GPA >= 3.0 && this.GPA < 3.5)
            {
                gpaScale = "Good";
            }
            else if (this.GPA >= 2.5 && this.GPA < 3.0)
            {
                gpaScale = "Satisfactory";
            }
            else if (this.GPA >= 0.0 && this.GPA < 2.5)
            {
                gpaScale = "Unsatisfactory";
            }
        }

        public void GetAge() //calculates and sets the private age, keeping it as a read-only outside the class aside from this method
        {
            DateTime today = DateTime.Today; //store current date to use for calculation
            DateTime birthDate = DateTime.Parse(this.DateOfBirth); //parse date string from database into datetime variable
            int calculatedAge = today.Year - birthDate.Year; //calculate difference in years between the two
            if (today.Month < birthDate.Month && today.Day < birthDate.Day) //if birthday hasn't happened yet this year then subtract 1 year from calculated age
            {
                calculatedAge--;
            }
            age = calculatedAge; //set private age field to calculated number
        }
    }

}