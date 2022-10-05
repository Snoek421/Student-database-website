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
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Lisa",
                    LastName = "Simpson",
                    DateOfBirth = new DateTime(1973, 08, 05),
                    GPA = 4.0,
                });

        }
    }
}
