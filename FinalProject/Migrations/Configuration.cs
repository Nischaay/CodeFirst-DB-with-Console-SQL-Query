using FinalProject.Models;

namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject.EFDataContext.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FinalProject.EFDataContext.DataContext context)
        {
            #region courses
            context.Students.AddOrUpdate(new Student()
            {
                FirstName = "Nischaay",
                LastName = "Bist",
                DegreeProgram = "Bachelor of Science ",
                DOB = DateTime.Now,
                Major = "Computer Science",
                IsGraduate = false,
                WNumber = "1234567"
            });
            context.Students.AddOrUpdate(new Student()
            {
                FirstName = "Test",
                LastName = "User",
                DegreeProgram = "Bachelor of Science ",
                DOB = DateTime.Now,
                Major = "Computer Science",
                IsGraduate = false,
                WNumber = "1234568"
            });
            context.Students.AddOrUpdate(new Student()
            {
                FirstName = "User",
                LastName = "III",
                DegreeProgram = "Bachelor of Science ",
                DOB = DateTime.Now,
                Major = "Computer Science",
                IsGraduate = false,
                WNumber = "9876787"
            });

            #endregion
            #region courses

            context.Courses.AddOrUpdate(new Course() { Abbreviation = "CMPS339", Name = "Computer Database", CreditHours = 3, Description = "Test", Number = 339 });
            context.Courses.AddOrUpdate(new Course() { Abbreviation = "CMPS390", Name = "Computer Data Structure", CreditHours = 3, Description = "Test", Number = 390 });
            context.Courses.AddOrUpdate(new Course() { Abbreviation = "CMPS161", Name = "Computer Algorithms and Design I", CreditHours = 3, Description = "Test", Number = 161 });
            context.Courses.AddOrUpdate(new Course() { Abbreviation = "CMPS285", Name = "Sofware Engineering", CreditHours = 3, Description = "Test", Number = 285 });
            context.Courses.AddOrUpdate(new Course() { Abbreviation = "CMPS411", Name = "Computer Capston I", CreditHours = 3, Description = "Test", Number = 411 });
            context.Courses.AddOrUpdate(new Course() { Abbreviation = "MUS172", Name = "Guitar", CreditHours = 1, Description = "Test", Number = 172 });

            #endregion

            #region courses
            for (var i = 7; i <= 9; i++)
            {
                context.Semesters.AddOrUpdate(new Semester() { Abbreviation = "FA201" + i, Name = "Fall201" + i });
                context.Semesters.AddOrUpdate(new Semester() { Abbreviation = "SU201" + i, Name = "Spring201" + i });
                context.Semesters.AddOrUpdate(new Semester() { Abbreviation = "SU201" + i, Name = "Summer201" + i });
            }
            #endregion
            #region Grades
            context.Grades.AddOrUpdate(new Grades() {Id =1 ,Grade = "A" });
            context.Grades.AddOrUpdate(new Grades() { Id =2 ,Grade = "B" });
            context.Grades.AddOrUpdate(new Grades() {Id = 3,Grade = "C" });
            context.Grades.AddOrUpdate(new Grades() {Id =4, Grade = "D" });
            context.Grades.AddOrUpdate(new Grades() {Id=5, Grade = "F" });
            #endregion

         #region coursesTaken   
         var student1 = context.Students.First(x => x.WNumber == "1234567");
         var student2 = context.Students.First(x => x.WNumber == "1234568");
         var student3 = context.Students.First(x => x.WNumber == "9876787");
         var t1 = context.Courses.First(x => x.Abbreviation == "CMPS339");
         var t2 = context.Courses.First(x => x.Abbreviation == "CMPS390");
         var t3 = context.Courses.First(x => x.Abbreviation == "CMPS161");

         context.CoursesTaken.Add(new CourseTaken() { StudentId = student1.Id, CourseId = t1.Id, GradeId = 1, SemesterId = 1 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student1.Id, CourseId = t2.Id, GradeId = 2, SemesterId = 2 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student1.Id, CourseId = t3.Id, GradeId = 3, SemesterId = 3 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student2.Id, CourseId = t1.Id, GradeId = 1, SemesterId = 1 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student2.Id, CourseId = t2.Id, GradeId = 2, SemesterId = 2 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student2.Id, CourseId = t3.Id, GradeId = 3, SemesterId = 3 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student3.Id, CourseId = t1.Id, GradeId = 1, SemesterId = 1 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student3.Id, CourseId = t2.Id, GradeId = 2, SemesterId = 2 });
         context.CoursesTaken.Add(new CourseTaken() { StudentId = student3.Id, CourseId = t3.Id, GradeId = 3, SemesterId = 3 });
         #endregion

        }
    }
}
