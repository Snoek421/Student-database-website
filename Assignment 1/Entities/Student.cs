using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Entities
{
    public class Student
    {

        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please choose a date of birth")]
        public string? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please input a valid GPA")]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public double? GPA { get; set; }

        private string? gpaScale;
        public string? GpaScale
        {
            get
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
                return gpaScale;
            }
            private set { }
        }

        private int? age;

        public int? Age
        {
            get { return age; }
            private set { }
        }


        [Required(ErrorMessage = "Please add a program of study")]
        public string? SchoolProgramID { get; set; }

        public SchoolProgram? SchoolProgram { get; set; }

        public void GetGpaScale()
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

        public void GetAge()
        {
            DateTime today = DateTime.Today;
            DateTime birthDate = DateTime.Parse(this.DateOfBirth);
            int calculatedAge = today.Year - birthDate.Year;
            if (today.Month < birthDate.Month)
            {
                calculatedAge--;
            }
            age = calculatedAge;
        }
    }

}