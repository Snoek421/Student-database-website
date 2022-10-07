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


        public DbSet<Student> Students { get; set; } //create public entity to manipulate and query Students table in database
        public DbSet<SchoolProgram> Programs { get; set; } //create public entity to manipulate and query Programs table in database


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Student>().HasData( 
                new Student() //seed data for bart
                {
                    StudentID = 1,
                    FirstName = "Bart",
                    LastName = "Simpson",
                    DateOfBirth = "05/31/1971",
                    GPA = 2.7,
                    SchoolProgramID = "CPA",
                },
                new Student() //seed data for lisa
                {
                    StudentID = 2,
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    DateOfBirth = "08/05/1973",
                    GPA = 4.0,
                    SchoolProgramID = "BACS"
                });

            modelbuilder.Entity<SchoolProgram>().HasData( //seed data for 4 program codes and their full names
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
