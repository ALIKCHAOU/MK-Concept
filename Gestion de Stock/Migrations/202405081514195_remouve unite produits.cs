namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remouveuniteproduits : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LigneAchats", "unite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LigneAchats", "unite", c => c.String());
        }
    }
}
