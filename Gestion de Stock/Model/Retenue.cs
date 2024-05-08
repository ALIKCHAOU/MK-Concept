using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Retenue
    {
        public int id { get; set; }
        //Organisme Payeur 
        public string MatriculeFiscalePayeur { get; set; }
        public string RaisonSocialePayeur { get; set; }
        public string AdressePayeur { get; set; }
        // Retenue
        public string Num_Facture { get; set; }
        public decimal Montant_Brut { get; set; }
        public decimal Taux { get; set; }
        public decimal MontantRetenue { get; set; }
        public decimal Montant_Net { get; set; }

        public decimal TotalMontant_Brut { get; set; }      
        public decimal TotalMontantRetenue { get; set; }
        public decimal TotalMontant_Net { get; set; }

        // Bénéficiaire
        public string MatriculeFiscaleBeneficiaire { get; set; }
        public string RaisonSocialePayeurBeneficiaire { get; set; }
        public string AdressePayeurBeneficiaire { get; set; }
    }
}
