namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmettrage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Metrage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Metrage");
        }
    }
}
