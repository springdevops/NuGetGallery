﻿namespace NuGetGallery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddNameToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable:false));
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "Name");
        }
    }
}