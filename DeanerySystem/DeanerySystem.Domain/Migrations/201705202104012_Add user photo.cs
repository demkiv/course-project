namespace DeanerySystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adduserphoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeaneryUsers", "PhotoPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeaneryUsers", "PhotoPath");
        }
    }
}
