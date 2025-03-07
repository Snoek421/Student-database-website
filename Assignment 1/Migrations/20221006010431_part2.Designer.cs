﻿// <auto-generated />
using System;
using Assignment_1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_1.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20221006010431_part2")]
    partial class part2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment_1.Entities.SchoolProgram", b =>
                {
                    b.Property<string>("SchoolProgramID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SchoolProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolProgramID");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            SchoolProgramID = "CP",
                            SchoolProgramName = "Computer Programmer"
                        },
                        new
                        {
                            SchoolProgramID = "CPA",
                            SchoolProgramName = "Computer Programmer Analyst"
                        },
                        new
                        {
                            SchoolProgramID = "BACS",
                            SchoolProgramName = "Bachelor of Applied Computer Science"
                        },
                        new
                        {
                            SchoolProgramID = "ITID",
                            SchoolProgramName = "IT Innovation and Design"
                        });
                });

            modelBuilder.Entity("Assignment_1.Entities.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("GPA")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("GpaScale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolProgramID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentID");

                    b.HasIndex("SchoolProgramID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1,
                            Age = 51,
                            DateOfBirth = new DateTime(1971, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bart",
                            GPA = 2.7000000000000002,
                            GpaScale = "Satisfactory",
                            LastName = "Simpson",
                            SchoolProgramID = "CPA"
                        },
                        new
                        {
                            StudentID = 2,
                            Age = 49,
                            DateOfBirth = new DateTime(1973, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lisa",
                            GPA = 4.0,
                            GpaScale = "Excellent",
                            LastName = "Simpson",
                            SchoolProgramID = "BACS"
                        }); ;
                });

            modelBuilder.Entity("Assignment_1.Entities.Student", b =>
                {
                    b.HasOne("Assignment_1.Entities.SchoolProgram", "SchoolProgram")
                        .WithMany()
                        .HasForeignKey("SchoolProgramID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolProgram");
                });
#pragma warning restore 612, 618
        }
    }
}
