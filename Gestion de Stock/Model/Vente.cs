using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Vente
    {
        public Vente()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public string Numero { get; set; }

       
        public string IntituleClient { get; set; }
        public string NumClient { get; set; }

        public string RaisonSocialeAffichage
        {
            get
            {
                if (!string.IsNullOrEmpty(NomClientPassager) && !string.IsNullOrEmpty(PrenomClientPassager))
                    return IntituleClient + "( " + NomClientPassager + " " + PrenomClientPassager + " )";
                else
                    return IntituleClient;
            }
        }

        public string NomClientPassager { get; set; }

        public string PrenomClientPassager { get; set; }

        public DateTime Date { get; set; }
       
        public EtatVente EtatVente { get; set; }

        public string NomEtat
        {
            get
            {
                if (this.EtatVente == EtatVente.Reglee)
                { return "Réglé"; }

                else if (this.EtatVente == EtatVente.PartiellementReglee)
                { return "Partiellement Réglé"; }

                else return "Non Réglé";
            }
        }

        public decimal TotalHT { get; set; }
        public decimal TotalTTC { get; set; }

        public int QteVendue { get; set; }
        public List<LigneVente> LigneVentes { get; set; }


        public decimal MontantReglement { get; set; }
        public decimal MontantRegle { get; set; }

        //public decimal ResteApayer { get { return MontantReglement - ( MontantRegle+MontantRemise); } }
        public decimal ResteApayer { get { return TotalTTC - (MontantRegle + MontantRemise); } }
        public ModeReglement ModeReglement { get; set; }

        public decimal MontantRemise { get; set; }




    }
}
