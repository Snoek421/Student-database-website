using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Entities
{
    public class SchoolProgram
    {
        public string SchoolProgramID { get; set; } //primary key for programs table, holds acronym for the program's name

        public string SchoolProgramName { get; set; } //name of each program
    }
}
