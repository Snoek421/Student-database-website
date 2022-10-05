using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please choose a date of birth.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please input a valid GPA.")]
        [Range(0.0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0.")]
        public double? GPA { get; set; }

        public string? GpaScale { get; private set; } = "";

        public int? Age { get; private set; }

        [Required(ErrorMessage = "Please select a Program.")]
        public string? ProgramId { get; set; }
        public SchoolProgram? SchoolProgram { get; set; }


        public Student()
        {

        }


        public void GetGPAScale()
        {
            if (this.GPA >= 4.0)
            {
                this.GpaScale = "Excellent";
            }
            else if (this.GPA >= 3.5 && this.GPA < 4.0)
            {
                this.GpaScale = "Very Good";
            }
            else if (this.GPA >= 3.0 && this.GPA < 3.5)
            {
                this.GpaScale = "Good";
            }
            else if (this.GPA >= 2.5 && this.GPA < 3.0)
            {
                this.GpaScale = "Satisfactory";
            }
            else if (this.GPA >= 0.0 && this.GPA < 2.5)
            {
                this.GpaScale = "Unsatisfactory";
            }
        }

        public void GetAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.DateOfBirth.Year;
            if (today.Month < this.DateOfBirth.Month)
            {
                age--;
            }
            this.Age = age;
        }


    }

}