using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class BondeLivraison
    {
        private readonly ApplicationContext context;
        public BondeLivraison()
        {
            DateCreation = DateTime.Now;
            DateBonDeCommande = DateTime.Now;
          

            context = new ApplicationContext();
            int lastCode = context.BondeLivraisons.Count();
            if (lastCode == 0)
            {
                Code = "BL00000001";
                Reference = "BL/BSM/"+ DateCreation.Year.ToString().Substring(2,2)+ "000001";
            }
            else
            {
                Code = "BL" + (lastCode + 1).ToString("D8");
                Reference = "BL/BSM/"+ DateCreation.Year.ToString().Substring(2, 2)+ (lastCode + 1).ToString("D8");
            }

        }


        [Key]
        public string Code { get; set; }
        public string Reference { get; set; }
      

       [Required(ErrorMessage = "Date Creation Commande is required")]
        public DateTime DateCreation { get; set; }

        public DateTime DateBonDeCommande { get; set; }

       public  TypeBonDeLivraison TypeBonDeLivraison { get; set; }



        public decimal FODEC { get { return decimal.Divide(Total_BonDeCommandeHT, 100); } }

        public decimal Timbre { get; set; } = 1m;

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


        public ICollection<ligneBonLivraison> ligneBonDeCommande { get; set; }

    

        public Client Client { get; set; }

        public ModePaiment ModePaiment { get; set; }

        public string  NomChauffeur { get; set; }

        public string CinChauffeur { get; set; }

        public string MatriculeCamion { get; set; }

        public string MatriculeClient { get; set; }

        public string RaisonSocialeClient { get; set; }
        


        public string Depart { get; set; }

        public string Destination { get; set; }
    }
}
