namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        Description = c.String(),
                        CreditHours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTakens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        WNumber = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Major = c.String(),
                        DegreeProgram = c.String(),
                        IsGraduate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTakens", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseTakens", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.CourseTakens", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.CourseTakens", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseTakens", new[] { "SemesterId" });
            DropIndex("dbo.CourseTakens", new[] { "GradeId" });
            DropIndex("dbo.CourseTakens", new[] { "CourseId" });
            DropIndex("dbo.CourseTakens", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.Grades");
            DropTable("dbo.CourseTakens");
            DropTable("dbo.Courses");
        }
    }
}
