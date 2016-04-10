namespace DeanerySystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EducationPlanrefactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JournalsForMarking", "Journal_Id", "dbo.Journals");
            DropForeignKey("dbo.SemesterEducationalPlans", "Id", "dbo.Semesters");
            DropForeignKey("dbo.Subjects", "SemesterEducationalPlan_Id", "dbo.SemesterEducationalPlans");
            DropForeignKey("dbo.SemesterEducationalPlans", "Id", "dbo.Groups");
            DropForeignKey("dbo.Journals", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.Journals", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TimeTables", "Journal_Id", "dbo.Journals");
            DropForeignKey("dbo.Cellules", "JournalForMarking_Id", "dbo.JournalsForMarking");
            DropIndex("dbo.Cellules", new[] { "JournalForMarking_Id" });
            DropIndex("dbo.JournalsForMarking", new[] { "Journal_Id" });
            DropIndex("dbo.Journals", new[] { "Professor_Id" });
            DropIndex("dbo.Journals", new[] { "Subject_Id" });
            DropIndex("dbo.SemesterEducationalPlans", new[] { "Id" });
            DropIndex("dbo.Subjects", new[] { "SemesterEducationalPlan_Id" });
            DropIndex("dbo.TimeTables", new[] { "Journal_Id" });
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
            
            AddColumn("dbo.Cellules", "Journal_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Journals", "JournalType", c => c.Int(nullable: false));
            AddColumn("dbo.Journals", "Class_Id", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "ClassRoom", c => c.String());
            AddColumn("dbo.TimeTables", "Class_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cellules", "Journal_Id");
            CreateIndex("dbo.Journals", "Class_Id");
            CreateIndex("dbo.TimeTables", "Class_Id");
            AddForeignKey("dbo.Journals", "Class_Id", "dbo.Classes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TimeTables", "Class_Id", "dbo.Classes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cellules", "Journal_Id", "dbo.Journals", "Id", cascadeDelete: true);
            DropColumn("dbo.Cellules", "JournalForMarking_Id");
            DropColumn("dbo.Journals", "Description");
            DropColumn("dbo.Journals", "ClassType");
            DropColumn("dbo.Journals", "Professor_Id");
            DropColumn("dbo.Journals", "Subject_Id");
            DropColumn("dbo.Subjects", "SemesterEducationalPlan_Id");
            DropColumn("dbo.TimeTables", "Journal_Id");
            DropTable("dbo.JournalsForMarking");
            DropTable("dbo.SemesterEducationalPlans");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SemesterEducationalPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JournalsForMarking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalType = c.Int(nullable: false),
                        Journal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TimeTables", "Journal_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "SemesterEducationalPlan_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Journals", "Subject_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Journals", "Professor_Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Journals", "ClassType", c => c.Int(nullable: false));
            AddColumn("dbo.Journals", "Description", c => c.String());
            AddColumn("dbo.Cellules", "JournalForMarking_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cellules", "Journal_Id", "dbo.Journals");
            DropForeignKey("dbo.TimeTables", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Classes", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Classes", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.EducationalPlans", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.EducationalPlans", "Semester_Id", "dbo.Semesters");
            DropForeignKey("dbo.EducationalPlans", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Journals", "Class_Id", "dbo.Classes");
            DropIndex("dbo.TimeTables", new[] { "Class_Id" });
            DropIndex("dbo.EducationalPlans", new[] { "Subject_Id" });
            DropIndex("dbo.EducationalPlans", new[] { "Semester_Id" });
            DropIndex("dbo.EducationalPlans", new[] { "Group_Id" });
            DropIndex("dbo.Classes", new[] { "Subject_Id" });
            DropIndex("dbo.Classes", new[] { "Professor_Id" });
            DropIndex("dbo.Journals", new[] { "Class_Id" });
            DropIndex("dbo.Cellules", new[] { "Journal_Id" });
            DropColumn("dbo.TimeTables", "Class_Id");
            DropColumn("dbo.TimeTables", "ClassRoom");
            DropColumn("dbo.Journals", "Class_Id");
            DropColumn("dbo.Journals", "JournalType");
            DropColumn("dbo.Cellules", "Journal_Id");
            DropTable("dbo.EducationalPlans");
            DropTable("dbo.Classes");
            CreateIndex("dbo.TimeTables", "Journal_Id");
            CreateIndex("dbo.Subjects", "SemesterEducationalPlan_Id");
            CreateIndex("dbo.SemesterEducationalPlans", "Id");
            CreateIndex("dbo.Journals", "Subject_Id");
            CreateIndex("dbo.Journals", "Professor_Id");
            CreateIndex("dbo.JournalsForMarking", "Journal_Id");
            CreateIndex("dbo.Cellules", "JournalForMarking_Id");
            AddForeignKey("dbo.Cellules", "JournalForMarking_Id", "dbo.JournalsForMarking", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TimeTables", "Journal_Id", "dbo.Journals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Journals", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Journals", "Professor_Id", "dbo.Professors", "Id");
            AddForeignKey("dbo.SemesterEducationalPlans", "Id", "dbo.Groups", "Id");
            AddForeignKey("dbo.Subjects", "SemesterEducationalPlan_Id", "dbo.SemesterEducationalPlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SemesterEducationalPlans", "Id", "dbo.Semesters", "Id");
            AddForeignKey("dbo.JournalsForMarking", "Journal_Id", "dbo.Journals", "Id", cascadeDelete: true);
        }
    }
}
