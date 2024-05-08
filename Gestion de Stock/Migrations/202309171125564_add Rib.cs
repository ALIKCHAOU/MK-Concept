namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRib : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Societes", "Rib", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Societes", "Rib");
        }
    }
}
