using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Entities
{
    public class SchoolProgram
    {
        [Key]
        public string ProgramID { get; set; }

        public string Name { get; set; }
    }
}
