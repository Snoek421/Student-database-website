using Assignment_1.Entities;

namespace Assignment_1.Models
{
    public class StudentViewModel
    {
        public List<SchoolProgram>? Programs { get; set; }

        public Student ActiveStudent { get; set; }
    }
}
