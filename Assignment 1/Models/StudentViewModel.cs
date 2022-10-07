using Assignment_1.Entities;

namespace Assignment_1.Models
{
    public class StudentViewModel
    {
        public List<SchoolProgram>? Programs { get; set; } //list to hold all programs from schoolPrograms table

        public Student ActiveStudent { get; set; } //student object to hold active student or new empty student
    }
}
