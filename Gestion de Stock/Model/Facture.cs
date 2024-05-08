using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
  public  class Facture
    {
        private readonly ApplicationContext context;
        public Facture()
        {
            DateCreation = DateTime.Now;
            DateFacture = DateTime.Now;
          
            context = new ApplicationContext();
            int lastCode = context.Factures.Count();
            if (lastCode == 0)
            {
                Code = "F00000001";
                Reference = "Facture/MK CONCEPT/00000001";
            }
            else
            {
                Code = "F" + (lastCode+1).ToString("D8");
                Reference = "Facture/MK CONCEPT/" + (lastCode+1).ToString("D8");
            }
        }
        [Key]
        public string Code { get; set; }
        public string Reference { get; set; }
        public string NumeoDocument { get; set; }
     

        [Required(ErrorMessage = "Date Creation Commande is required")]
        public DateTime DateCreation { get; set; }

        public DateTime DateFacture { get; set; }



        public int TVA { get; set; } = 19;

        public decimal Total_FactureHT { get; set; }
      

        public decimal Total_FactureTTC { get; set; }

        public decimal TOTALTVA { get {
                return decimal.Round(decimal.Divide(decimal.Multiply(Total_FactureHT, TVA),100) ,3) ;
            } }

        public ICollection<ligneFacture> ligneFactures { get; set; }
        
        public Client Client { get; set; }

        public Retenue Retenue { get; set; }
        public decimal Timbre { get; set; } = 1m;

  


    }
}
