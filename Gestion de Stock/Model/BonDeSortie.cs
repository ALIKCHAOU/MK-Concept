using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class BonDeSortie
    {
        private readonly ApplicationContext context;
        public BonDeSortie()
        {
            DateCreation = DateTime.Now;
            DateBonDeCommande = DateTime.Now;
          

            context = new ApplicationContext();
            int lastCode = context.BonDeSorties.Count();
            if (lastCode == 0)
            {
                Code = "BS00000001";
                Reference = "BS/BSM/"+ DateCreation.Year.ToString().Substring(2,2)+ "000001";
            }
            else
            {
                Code = "BS" + (lastCode + 1).ToString("D8");
                Reference = "BS/BSM/"+ DateCreation.Year.ToString().Substring(2, 2)+ (lastCode + 1).ToString("D8");
            }

        }


        [Key]
        public string Code { get; set; }
        public string Reference { get; set; }
      

       [Required(ErrorMessage = "Date Creation Commande is required")]
        public DateTime DateCreation { get; set; }

        public DateTime DateBonDeCommande { get; set; }

     



        public decimal FODEC { get { return decimal.Divide(Total_BonDeCommandeHT, 100); } }

        public decimal Timbre { get; set; } = 0.1000m;

        public string Currency { get; set; } = "TND";

        public int TVA { get; set; }

        public decimal Total_BonDeCommandeHT { get; set; }

        public decimal Total_BonDeCommandeTTC { get; set; }
        public decimal TOTALTVA
        {
            get
            {
                return Decimal.Subtract(Total_BonDeCommandeTTC, Total_BonDeCommandeHT);
            }
        }


        public ICollection<ligneBonSortie> ligneBonDeSortie { get; set; }

        public string RaisonSocialeAffichage { get {
                if(!string.IsNullOrEmpty(NomClientPassager) && !string.IsNullOrEmpty(PrenomClientPassager))
                return RaisonSociale +"( "+NomClientPassager +" "+ PrenomClientPassager +" )";
                else            
                return RaisonSociale;
            }
        }

        public Client Client { get; set; }

        public string NomClientPassager { get; set; }

        public string PrenomClientPassager { get; set; }

        public string RaisonSociale { get; set; }

        public string  NomChauffeur { get; set; }

        public string CinChauffeur { get; set; }

        public string MatriculeCamion { get; set; }

        public string MatriculeClient { get; set; }

        public string Depart { get; set; }

        public string Destination { get; set; }

        public TypeBonDeSortie  TypeBonDeSortie { get; set; }
    }
}
