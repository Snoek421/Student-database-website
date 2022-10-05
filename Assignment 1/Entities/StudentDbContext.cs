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
                    ProgramID = "CPA",
                },
                new Student()
                {
                    StudentID = 2,
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1973, 08, 05),
                    GPA = 4.0,
                    ProgramID = "BACS"
                });

            modelbuilder.Entity<SchoolProgram>().HasData(
                new SchoolProgram()
                {
                    ProgramID = "CP",
                    Name = "Computer Programmer"
                },
                new SchoolProgram()
                {
                    ProgramID = "CPA",
                    Name = "Computer Programmer Analyst"
                },
                new SchoolProgram()
                {
                    ProgramID = "BACS",
                    Name = "Bachelor of Applied Computer Science"
                },
                new SchoolProgram()
                {
                    ProgramID = "ITID",
                    Name = "IT Innovation and Design"
                });
        }
    }
}
