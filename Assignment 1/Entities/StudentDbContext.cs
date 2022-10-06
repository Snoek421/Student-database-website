using Assignment_1.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Entities
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolProgram> Programs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Student>().HasData(
                new Student()
                {
                    StudentID = 1,
                    FirstName = "Bart",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1971, 05, 31),
                    GPA = 2.7,
                    SchoolProgramID = "CPA",
                },
                new Student()
                {
                    StudentID = 2,
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1973, 08, 05),
                    GPA = 4.0,
                    SchoolProgramID = "BACS"
                });

            modelbuilder.Entity<SchoolProgram>().HasData(
                new SchoolProgram()
                {
                    SchoolProgramID = "CP",
                    SchoolProgramName = "Computer Programmer"
                },
                new SchoolProgram()
                {
                    SchoolProgramID = "CPA",
                    SchoolProgramName = "Computer Programmer Analyst"
                },
                new SchoolProgram()
                {
                    SchoolProgramID = "BACS",
                    SchoolProgramName = "Bachelor of Applied Computer Science"
                },
                new SchoolProgram()
                {
                    SchoolProgramID = "ITID",
                    SchoolProgramName = "IT Innovation and Design"
                });
        }
    }
}
