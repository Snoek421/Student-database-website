using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Entities
{
    public class SchoolProgram
    {
        [Key]
        public string ProgramId { get; set; }

        public string ProgramName { get; set; }
    }
}
