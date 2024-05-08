﻿namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GereStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "GereStock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "GereStock");
        }
    }
}
