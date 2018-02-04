namespace DeanerySystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cellules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Mark = c.String(),
                        Journal_Id = c.Int(nullable: false),
                        Student_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journals", t => t.Journal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Journal_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalType = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ClassType = c.Int(nullable: false),
                        Professor_Id = c.Guid(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Professor_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Professor_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        LatinFirstName = c.String(),
                        LatinLastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dean_Id = c.Guid(),
                        University_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Dean_Id)
                .ForeignKey("dbo.Universities", t => t.University_Id, cascadeDelete: true)
                .Index(t => t.Dean_Id)
                .Index(t => t.University_Id);
            
            CreateTable(
                "dbo.Streams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreamAbbreviation = c.String(),
                        Faculty_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id, cascadeDelete: true)
                .Index(t => t.Faculty_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        Head_Id = c.Guid(),
                        Stream_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Head_Id)
                .ForeignKey("dbo.Streams", t => t.Stream_Id, cascadeDelete: true)
                .Index(t => t.Head_Id)
                .Index(t => t.Stream_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Tuition = c.Int(nullable: false),
                        Mentor_Id = c.Guid(nullable: false),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Mentor_Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Mentor_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.EducationalPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Group_Id = c.Int(nullable: false),
                        Semester_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.Semester_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.Semester_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        CreditSessionStart = c.DateTime(nullable: false),
                        SessionStart = c.DateTime(nullable: false),
                        SecondWritingStart = c.DateTime(nullable: false),
                        ThirdWritingStart = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FailureTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassingDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        IsPassed = c.Boolean(nullable: false),
                        Student_Id = c.Guid(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        NumberOfLectures = c.Int(nullable: false),
                        NumberOfPracticalClasses = c.Int(nullable: false),
                        NumberOflLaboratoryClasses = c.Int(nullable: false),
                        NumberOfConsultations = c.Int(nullable: false),
                        SemesterControl = c.Int(nullable: false),
                        PassingDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgressRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TermMark = c.Double(nullable: false),
                        ExamMark = c.Double(nullable: false),
                        Student_Id = c.Guid(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rector_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Rector_Id)
                .Index(t => t.Rector_Id);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        Fraction = c.Int(nullable: false),
                        Class_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.ClassNumberTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Start = c.Time(nullable: false, precision: 7),
                        End = c.Time(nullable: false, precision: 7),
                        TimeTable_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeTables", t => t.TimeTable_Id, cascadeDelete: true)
                .Index(t => t.TimeTable_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StudentsSemesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false),
                        StudentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SemesterId, t.StudentId })
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.SemesterId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Department_Id = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Group_Id = c.Int(nullable: false),
                        StudentCode = c.String(),
                        TuitionFee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Students", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Professors", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Professors", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cellules", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Cellules", "Journal_Id", "dbo.Journals");
            DropForeignKey("dbo.TimeTables", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.ClassNumberTimes", "TimeTable_Id", "dbo.TimeTables");
            DropForeignKey("dbo.Classes", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Classes", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.Universities", "Rector_Id", "dbo.Professors");
            DropForeignKey("dbo.Faculties", "University_Id", "dbo.Universities");
            DropForeignKey("dbo.Streams", "Faculty_Id", "dbo.Faculties");
            DropForeignKey("dbo.Departments", "Stream_Id", "dbo.Streams");
            DropForeignKey("dbo.Departments", "Head_Id", "dbo.Professors");
            DropForeignKey("dbo.Groups", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Groups", "Mentor_Id", "dbo.Professors");
            DropForeignKey("dbo.EducationalPlans", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.EducationalPlans", "Semester_Id", "dbo.Semesters");
            DropForeignKey("dbo.StudentsSemesters", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentsSemesters", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.FailureTickets", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.ProgressRecords", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.ProgressRecords", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.FailureTickets", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.EducationalPlans", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Faculties", "Dean_Id", "dbo.Professors");
            DropForeignKey("dbo.Journals", "Class_Id", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "Group_Id" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Professors", new[] { "Department_Id" });
            DropIndex("dbo.Professors", new[] { "Id" });
            DropIndex("dbo.StudentsSemesters", new[] { "StudentId" });
            DropIndex("dbo.StudentsSemesters", new[] { "SemesterId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ClassNumberTimes", new[] { "TimeTable_Id" });
            DropIndex("dbo.TimeTables", new[] { "Class_Id" });
            DropIndex("dbo.Universities", new[] { "Rector_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.ProgressRecords", new[] { "Subject_Id" });
            DropIndex("dbo.ProgressRecords", new[] { "Student_Id" });
            DropIndex("dbo.FailureTickets", new[] { "Subject_Id" });
            DropIndex("dbo.FailureTickets", new[] { "Student_Id" });
            DropIndex("dbo.EducationalPlans", new[] { "Subject_Id" });
            DropIndex("dbo.EducationalPlans", new[] { "Semester_Id" });
            DropIndex("dbo.EducationalPlans", new[] { "Group_Id" });
            DropIndex("dbo.Groups", new[] { "Department_Id" });
            DropIndex("dbo.Groups", new[] { "Mentor_Id" });
            DropIndex("dbo.Departments", new[] { "Stream_Id" });
            DropIndex("dbo.Departments", new[] { "Head_Id" });
            DropIndex("dbo.Streams", new[] { "Faculty_Id" });
            DropIndex("dbo.Faculties", new[] { "University_Id" });
            DropIndex("dbo.Faculties", new[] { "Dean_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Classes", new[] { "Subject_Id" });
            DropIndex("dbo.Classes", new[] { "Professor_Id" });
            DropIndex("dbo.Journals", new[] { "Class_Id" });
            DropIndex("dbo.Cellules", new[] { "Student_Id" });
            DropIndex("dbo.Cellules", new[] { "Journal_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Professors");
            DropTable("dbo.StudentsSemesters");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ClassNumberTimes");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Universities");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.ProgressRecords");
            DropTable("dbo.Subjects");
            DropTable("dbo.FailureTickets");
            DropTable("dbo.Semesters");
            DropTable("dbo.EducationalPlans");
            DropTable("dbo.Groups");
            DropTable("dbo.Departments");
            DropTable("dbo.Streams");
            DropTable("dbo.Faculties");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Classes");
            DropTable("dbo.Journals");
            DropTable("dbo.Cellules");
        }
    }
}
