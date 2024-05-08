using Gestion_de_Stock.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Context")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());
            Database.CommandTimeout = 0;
          //  this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 3));
        }
        public DbSet<PointageJournalier> PointagesJournalier { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }  

        public DbSet<Societe> Societes { get; set; }

        public DbSet<Fournisseur> Fournisseurs { get; set; }


        public DbSet<Client> Clients { get; set; }

        public DbSet<Achat> Achats { get; set; }

     

        public DbSet<Devis> Devis { get; set; }

        public DbSet<ligneDevis> ligneDevis { get; set; }
        

        public DbSet<Facture> Factures { get; set; }
  
     
        public DbSet<Article> Articles { get; set; }
      




     


        public DbSet<Coffrecheque> CoffreCheques { get; set; }
        public DbSet<Salarier> Salariers { get; set; }
        public DbSet<Prelevement> Prelevements { get; set; }
        public DbSet<Alimentation> Alimentations { get; set; }
        public DbSet<Depense> Depenses { get; set; }
        public DbSet<MouvementCaisse> MouvementsCaisse { get; set; }
        public DbSet<Caisse> Caisse { get; set; }
        public DbSet<HistoriquePaiementVente> HistoriquePaiementVente { get; set; }
        public DbSet<HistoriquePaiementAchats> HistoriquePaiementAchats { get; set; }

        public DbSet<HistoriquePaiementSalarie> HistoriquePaiementSalaries { get; set; }
       
        public DbSet<Vente> Vente { get; set; }
        public DbSet<LigneAchats> LigneAchats { get; set; }



        public DbSet<LigneVente> LigneVentes { get; set; }

 
       
        




    }
}
