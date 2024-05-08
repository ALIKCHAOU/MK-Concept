namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajouterMatriculesalarier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salariers", "Matricule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salariers", "Matricule");
        }
    }
}
