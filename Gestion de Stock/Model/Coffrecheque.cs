using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Coffrecheque
    {
        public Coffrecheque()
        {
            DateCreation = DateTime.Now;

        }
        public int Id { get; set; }

        public DateTime DateCreation { get; set; }

        public string NumVente { get; set; }

        public string NumAchat { get; set; }

        public string NomSalarier { get; set; }

        public string Frounisseur { get; set; }

        public string Client  { get; set; }

        public decimal Montant { get; set; }

        public string NumCheque { get; set; }

        public string Banque { get; set; }

        public Nullable<DateTime> DateEcheance { get; set; }

        public string Commentaire { get; set; }

        public ModePaiment ModePaiment { get; set; }

        public ChequeType ChequeType { get; set; }

        public NatureMouvement Nature { get; set; }

        public StatutVirement StatutVirement { get; set; }



    }
}
