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
                    Id = 1,
                    FirstName = "Bart",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1971, 05, 31),
                    GPA = 2.7,
                    ProgramId = "CPA"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1973, 08, 05),
                    GPA = 4.0,
                    ProgramId = "BACS"
                });

            modelbuilder.Entity<SchoolProgram>().HasData(
                new SchoolProgram()
                {
                    ProgramId = "CP",
                    ProgramName = "Computer Programmer"
                },
                new SchoolProgram()
                {
                    ProgramId = "CPA",
                    ProgramName = "Computer Programmer Analyst"
                },
                new SchoolProgram()
                {
                    ProgramId = "BACS",
                    ProgramName = "Bachelor of Applied Computer Science"
                },
                new SchoolProgram()
                {
                    ProgramId = "ITID",
                    ProgramName = "IT Innovation and Design"
                });
        }
    }
}
