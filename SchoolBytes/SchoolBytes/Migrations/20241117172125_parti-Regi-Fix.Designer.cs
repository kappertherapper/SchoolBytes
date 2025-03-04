﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolBytes.Models;

namespace SchoolBytes.Migrations
{
    [DbContext(typeof(DBConnection))]
    [Migration("20241117172125_parti-Regi-Fix")]
    partial class partiRegiFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CourseId");

                    b.Property<int?>("CourseModuleId");

                    b.Property<int?>("FoodModuleId");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseModuleId");

                    b.HasIndex("FoodModuleId");

                    b.ToTable("participants");
                });

            modelBuilder.Entity("Registration", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int?>("participantId");

                    b.HasKey("Id");

                    b.HasIndex("participantId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("SchoolBytes.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MaxCapacity");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("SchoolBytes.Models.CourseModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<int?>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EndTime");

                    b.Property<int?>("FoodModuleId");

                    b.Property<string>("Location");

                    b.Property<int>("MaxCapacity");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("FoodModuleId");

                    b.HasIndex("TeacherId");

                    b.ToTable("courseModules");
                });

            modelBuilder.Entity("SchoolBytes.Models.FoodModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Capacity");

                    b.Property<int?>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("foodModules");
                });

            modelBuilder.Entity("Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("teachers");
                });

            modelBuilder.Entity("Participant", b =>
                {
                    b.HasOne("SchoolBytes.Models.Course")
                        .WithMany("Participants")
                        .HasForeignKey("CourseId");

                    b.HasOne("SchoolBytes.Models.CourseModule")
                        .WithMany("Waitlist")
                        .HasForeignKey("CourseModuleId");

                    b.HasOne("SchoolBytes.Models.FoodModule")
                        .WithMany("Participants")
                        .HasForeignKey("FoodModuleId");
                });

            modelBuilder.Entity("Registration", b =>
                {
                    b.HasOne("SchoolBytes.Models.CourseModule", "CourseModule")
                        .WithMany("Registrations")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Participant", "participant")
                        .WithMany()
                        .HasForeignKey("participantId");
                });

            modelBuilder.Entity("SchoolBytes.Models.Course", b =>
                {
                    b.HasOne("Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("SchoolBytes.Models.CourseModule", b =>
                {
                    b.HasOne("SchoolBytes.Models.Course", "Course")
                        .WithMany("CoursesModules")
                        .HasForeignKey("CourseId");

                    b.HasOne("SchoolBytes.Models.FoodModule", "FoodModule")
                        .WithMany()
                        .HasForeignKey("FoodModuleId");

                    b.HasOne("Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("SchoolBytes.Models.FoodModule", b =>
                {
                    b.HasOne("SchoolBytes.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });
#pragma warning restore 612, 618
        }
    }
}
