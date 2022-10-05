using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Entities
{
    public class Student
    {

        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please choose a date of birth.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please input a valid GPA.")]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0.")]
        public double? GPA { get; set; }

        private string? gpaScale;
        public string? GpaScale
        {
            get
            {
                if (this.GPA >= 4.0)
                {
                    GpaScale = "Excellent";
                }
                else if (this.GPA >= 3.5 && this.GPA < 4.0)
                {
                    GpaScale = "Very Good";
                }
                else if (this.GPA >= 3.0 && this.GPA < 3.5)
                {
                    GpaScale = "Good";
                }
                else if (this.GPA >= 2.5 && this.GPA < 3.0)
                {
                    GpaScale = "Satisfactory";
                }
                else if (this.GPA >= 0.0 && this.GPA < 2.5)
                {
                    GpaScale = "Unsatisfactory";
                }
                return GpaScale;
            }
            private set { }
        }

        private int? age;

        public int? Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int calculatedAge = today.Year - this.DateOfBirth.Year;
                if (today.Month < this.DateOfBirth.Month)
                {
                    calculatedAge--;
                }
                age = calculatedAge;
                return age;
            }
            private set { }
        }


        [Required(ErrorMessage = "Please select a Program.")]
        public string? ProgramID { get; set; }

        public SchoolProgram? SchoolProgram { get; set; }


    }

}