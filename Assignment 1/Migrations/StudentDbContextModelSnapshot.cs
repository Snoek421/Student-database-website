﻿// <auto-generated />
using System;
using Assignment_1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_1.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment_1.Entities.SchoolProgram", b =>
                {
                    b.Property<string>("ProgramId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramId");

                    b.ToTable("Programs");

                    b.HasData(
                        new
                        {
                            ProgramId = "CP",
                            ProgramName = "Computer Programmer"
                        },
                        new
                        {
                            ProgramId = "CPA",
                            ProgramName = "Computer Programmer Analyst"
                        },
                        new
                        {
                            ProgramId = "BACS",
                            ProgramName = "Bachelor of Applied Computer Science"
                        },
                        new
                        {
                            ProgramId = "ITID",
                            ProgramName = "IT Innovation and Design"
                        });
                });

            modelBuilder.Entity("Assignment_1.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<string>("ProgramId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolProgramProgramId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SchoolProgramProgramId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1971, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bart",
                            GPA = 2.7000000000000002,
                            GpaScale = "",
                            LastName = "Simpson",
                            ProgramId = "CPA"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1973, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Lisa",
                            GPA = 4.0,
                            GpaScale = "",
                            LastName = "Simpson",
                            ProgramId = "BACS"
                        });
                });

            modelBuilder.Entity("Assignment_1.Entities.Student", b =>
                {
                    b.HasOne("Assignment_1.Entities.SchoolProgram", "SchoolProgram")
                        .WithMany()
                        .HasForeignKey("SchoolProgramProgramId");

                    b.Navigation("SchoolProgram");
                });
#pragma warning restore 612, 618
        }
    }
}
