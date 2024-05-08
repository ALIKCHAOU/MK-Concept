namespace Gestion_de_Stock.Migrations
{
    using Gestion_de_Stock.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gestion_de_Stock.Model.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gestion_de_Stock.Model.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //  to avoid creating duplicate seed data.
            var user1 = new Utilisateur
            {
                Id = 1,
                Login = "Admin",
                Password = "Admin",
                Nom = "Admin",
                Prenom = "Admin",
                Admin = true
            };

            var user2 = new Utilisateur
            {
                Id = 2,
                Login = "User",
                Password = "User",
                Nom = "User",
                Prenom = "User",
                Admin = false
            };

            if (context.Utilisateurs.Count() == 0)
            {
                context.Utilisateurs.AddOrUpdate(user1);
                context.Utilisateurs.AddOrUpdate(user2);
            }
            if (context.Caisse.Count() == 0)
            {
                var Caisse = new Caisse { MontantTotal = 0m };
                context.Caisse.AddOrUpdate(Caisse);
            }
            if (context.Societes.Count() == 0)
            {
                var societe = new Societe
                {
                    Id = 1,
                    Activite = " 1",
                    Adresse = "Sfax, Tunisia, 3002",
                    Capitale = "1000000",
                    CodePostale = "3000",
                    Complement = "Complément 1",
                    Mail = "mail@societe.com",
                    MatriculFiscal = "matfisc",
                    Name = "MK Concept",
                    RaisonSociale = "MK Concept",
                    Site = "MKConcept.com",                   
                    Telephone = "216 93 356 891",
                    Ville = "Sfax",
                    Timber=1m,
                    TVA = 19
                };
                context.Societes.AddOrUpdate(societe);
            }
           
           

                context.SaveChanges();
        }
    }
}
