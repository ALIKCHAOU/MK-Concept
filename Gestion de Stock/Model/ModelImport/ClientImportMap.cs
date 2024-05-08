using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Gestion_de_Stock.Model.ModelImport
{
  public  class ClientImportMap : ClassMap<Client>
    {
        public ClientImportMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            //    public int ID { get; set; }
            // Map(x => x.ID).Name("ID");
            Map(m => m.Code).Name("id", "ID").Ignore();




            // Nom { get; set; }           
            Map(x => x.Nom).Name("Nom", "nom").Default("");



            //  public string Prenom { get; set; }
            Map(x => x.Prenom).Name("Prenom", "prenom").Default("");

            // Numero { get; set; }    
            Map(x => x.Telephone).Name("Contact", "Telephone", "telephone", "tèlèphone").Default("");


            // EmailAddress { get; set; }
            Map(x => x.Email).Name("Email", "EmailAddress", "Email Address").Default("");

            // Adresse { get; set; }
            Map(x => x.Adresse).Name("Adresse").Default("");
            // Note { get; set; }
            Map(x => x.Ville).Name("Ville", "Ville").Default("");




            // public bool send { get; set; }
        }
    }
}
