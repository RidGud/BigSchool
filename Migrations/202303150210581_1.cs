﻿namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecturer_Id" });
            RenameColumn(table: "dbo.Courses", name: "Lecturer_Id", newName: "LecturerID");
            AlterColumn("dbo.Courses", "LecturerID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LecturerID");
            AddForeignKey("dbo.Courses", "LecturerID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerID", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LecturerID" });
            AlterColumn("dbo.Courses", "LecturerID", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Courses", name: "LecturerID", newName: "Lecturer_Id");
            CreateIndex("dbo.Courses", "Lecturer_Id");
            AddForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
