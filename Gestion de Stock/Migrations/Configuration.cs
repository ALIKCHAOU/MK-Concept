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
                    Activite = "Activité 1",
                    Adresse = "Adresse 1",
                    Capitale = "1000000",
                    CodePostale = "3000",
                    Complement = "Complément 1",
                    Mail = "mail@societe.com",
                    MatriculFiscal = "matfisc",
                    Name = "Sociéte 1",
                    RaisonSociale = "Entreprise",
                    Site = "societe.com",
                   
                    Telephone = "123123",
                    Ville = "Sfax",
                    Timber=1m,
                    TVA = 19
                };
                context.Societes.AddOrUpdate(societe);
            }
            if (context.Packs.Count()==0)
            {
                context.Packs.Add(new Article { Code= "P00000001", DateCreation=DateTime.Now,Designation= "Bargataire 90 PN6", PrixdeVenteGros1= 400m, PrixdeVenteGros2= 400m, PrixdeVentepublic=400m,PrixdeVenteRevendeur=400m});
                context.SaveChanges();
                context.Packs.Add(new Article { Code = "P00000002", DateCreation = DateTime.Now, Designation = "Bargataire 90 PN10", PrixdeVenteGros1 = 500m, PrixdeVenteGros2 = 500m, PrixdeVentepublic = 500m, PrixdeVenteRevendeur = 500m });
                context.SaveChanges();
                //context.Packs.Add(new Article { Code = "P00000003", DateCreation = DateTime.Now, Designation = "Bargataire 53 PN6", PrixdeVenteGros1 = 1m, PrixdeVenteGros2 = 2m, PrixdeVentepublic = 3m, PrixdeVenteRevendeur = 4m });
                //context.SaveChanges();
                //context.Packs.Add(new Article { Code = "P00000004", DateCreation = DateTime.Now, Designation = "Bargataire 53 PN10", PrixdeVenteGros1 = 1m, PrixdeVenteGros2 = 2m, PrixdeVentepublic = 3m, PrixdeVenteRevendeur = 4m });
                //context.SaveChanges();
                //context.Packs.Add(new Article { Code = "P00000005", DateCreation = DateTime.Now, Designation = "Bargataire 43 PN6", PrixdeVenteGros1 = 1m, PrixdeVenteGros2 = 2m, PrixdeVentepublic = 3m, PrixdeVenteRevendeur = 4m });
                //context.SaveChanges();
                //context.Packs.Add(new Article { Code = "P00000006", DateCreation = DateTime.Now, Designation = "Bargataire 43 PN10", PrixdeVenteGros1 = 1m, PrixdeVenteGros2 = 2m, PrixdeVentepublic = 3m, PrixdeVenteRevendeur = 4m });
                //context.SaveChanges();
                //context.Packs.Add(new Article { Code = "P00000007", DateCreation = DateTime.Now, Designation = "Bargataire 33 PN6", PrixdeVenteGros1 = 1m, PrixdeVenteGros2 = 2m, PrixdeVentepublic = 3m, PrixdeVenteRevendeur = 4m });
                //context.SaveChanges();
                //context.Packs.Add(new Article { Code = "P00000008", DateCreation = DateTime.Now, Designation = "Bargataire 33 PN10", PrixdeVenteGros1 = 1m, PrixdeVenteGros2 = 2m, PrixdeVentepublic = 3m, PrixdeVenteRevendeur = 4m });
            }
            if (context.MatierePremieres.Count() == 0)
            {
                context.MatierePremieres.Add(new MatierePremiere {Id=1, Code = "M00000001", Description = "Déchet", Unite = "kg", Quantity = 0 ,DernierPirxAchat=0,Nom= "Déchet" });
                context.SaveChanges();
            }

                context.SaveChanges();
        }
    }
}
