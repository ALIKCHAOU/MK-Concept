namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterusine2t : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LigneProductionUsine2", "code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LigneProductionUsine2", "code");
        }
    }
}
