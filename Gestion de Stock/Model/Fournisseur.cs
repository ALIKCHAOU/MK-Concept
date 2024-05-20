using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class Fournisseur
    {
        private readonly ApplicationContext context;
        public Fournisseur()
        {
            DateCreation = DateTime.Now;
            context = new ApplicationContext();
            int lastClient = context.Fournisseurs.Count() + 1;
            if (lastClient == 0)
            {
                Code = "FR00000001";
            }
            else
            {
                Code = "FR" + (lastClient).ToString("D8");
            }
        }


        [Key]
        // Coordonné STE 
        public string Code { get; set; }
        public string RaisonSociale { get; set; }
        public string Activite { get; set; }
        public string MatriculeFiscale { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Fax { get; set; }
        
        // Coordonné Responsable
        public string NomResponsable { get; set; }

        public string PrenomResponsable { get; set; }
        public string TelResponsable { get; set; }
        public string EmailResponsable  { get; set; }

         [NotMapped]
        public String FullName
        {
            get { return NomResponsable + " " + PrenomResponsable; }
            set { _fullName = value; }
        }

        private String _fullName;
      


        [Required(ErrorMessage = "Date Creation is required")]
        public DateTime DateCreation { get; set; }
     
        public Status Status { get; set; }

    
        //	Coordonné Bancaire 
	    public string  Banque { get; set; }

        public string  RIB { get; set; }



        
        //Modalité de payement
        public string Devise { get; set; }

        public int TVA { get; set; }

        public int Nbrdesfactures { get; set; }

        public decimal TotalPaye { get; set; }

        public decimal TotalCredit  { get; set; }

        public decimal SommedesFacture { get; set; }

        public List<Article> ListeArticles { get; set; }






    }
}
