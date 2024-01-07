﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using timeasy_api.src.Contexts;

#nullable disable

namespace timeasyapi.src.Contexts.Migrations
{
    [DbContext(typeof(TimeasyDbContext))]
    [Migration("20231217021958_AddInstituteFKInAllTables")]
    partial class AddInstituteFKInAllTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RoomTimetable", b =>
                {
                    b.Property<Guid>("RoomsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetablesId")
                        .HasColumnType("char(36)");

                    b.HasKey("RoomsId", "TimetablesId");

                    b.HasIndex("TimetablesId");

                    b.ToTable("RoomTimetable");
                });

            modelBuilder.Entity("TeacherTimetable", b =>
                {
                    b.Property<Guid>("TeachersId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetablesId")
                        .HasColumnType("char(36)");

                    b.HasKey("TeachersId", "TimetablesId");

                    b.HasIndex("TimetablesId");

                    b.ToTable("TeacherTimetable");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PeriodAmount")
                        .HasColumnType("int");

                    b.Property<string>("Turn")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.CourseSubject", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("WeeklyClassCount")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseSubject");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<TimeSpan>("CloseHour")
                        .HasColumnType("time(6)");

                    b.Property<bool>("Friday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Monday")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<TimeSpan>("OpenHour")
                        .HasColumnType("time(6)");

                    b.Property<bool>("Saturday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Thursday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Institute");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Interval", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time(6)");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Interval");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Block")
                        .HasColumnType("longtext");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsComputerLab")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OperationalSystem")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("Complexity")
                        .HasColumnType("int unsigned");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("RoomTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Timetable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateOnly>("CreateAt")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("EndedAt")
                        .HasColumnType("date");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint>("Status")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Timetable");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.TimetableCourses", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetableId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Friday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Monday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Saturday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Thursday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Tuesday")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Wednesday")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CourseId", "TimetableId");

                    b.HasIndex("TimetableId");

                    b.ToTable("TimetableCourses");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.TimetableSubjects", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TimetableId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("char(36)");

                    b.Property<int>("DividedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDivided")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("StudentsCount")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "TimetableId", "CourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TimetableId");

                    b.ToTable("TimetableSubjects");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<uint>("AcessLevel")
                        .HasColumnType("int unsigned");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.WorkSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time(6)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("WorkSchedule");
                });

            modelBuilder.Entity("RoomTimetable", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.Timetable", null)
                        .WithMany()
                        .HasForeignKey("TimetablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeacherTimetable", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.Timetable", null)
                        .WithMany()
                        .HasForeignKey("TimetablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Course", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany("Courses")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.CourseSubject", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Course", "Course")
                        .WithMany("CourseSubject")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.Subject", "Subject")
                        .WithMany("CourseSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Interval", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany("Intervals")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Room", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.RoomType", "Type")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.RoomType", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Subject", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.RoomType", "RoomType")
                        .WithMany("Subjects")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Teacher", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany("Teachers")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Timetable", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany("Timetables")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.TimetableCourses", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Course", "Course")
                        .WithMany("TimetableCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.Timetable", "Timetable")
                        .WithMany("TimetableCourses")
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.TimetableSubjects", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Course", "Course")
                        .WithMany("TimetableSubjects")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.Subject", "Subject")
                        .WithMany("TimetableSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("timeasy_api.src.core.entities.Timetable", "Timetable")
                        .WithMany("TimetableSubjects")
                        .HasForeignKey("TimetableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Subject");

                    b.Navigation("Timetable");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.User", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Institute", "Institute")
                        .WithMany("Users")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.WorkSchedule", b =>
                {
                    b.HasOne("timeasy_api.src.core.entities.Teacher", "Teacher")
                        .WithMany("WorkSchedule")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Course", b =>
                {
                    b.Navigation("CourseSubject");

                    b.Navigation("TimetableCourses");

                    b.Navigation("TimetableSubjects");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Institute", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Intervals");

                    b.Navigation("Teachers");

                    b.Navigation("Timetables");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.RoomType", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Subject", b =>
                {
                    b.Navigation("CourseSubject");

                    b.Navigation("TimetableSubjects");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Teacher", b =>
                {
                    b.Navigation("WorkSchedule");
                });

            modelBuilder.Entity("timeasy_api.src.core.entities.Timetable", b =>
                {
                    b.Navigation("TimetableCourses");

                    b.Navigation("TimetableSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}