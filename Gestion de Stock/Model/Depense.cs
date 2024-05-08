using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Depense
    {
        public Depense()
        {
            DateCreation = DateTime.Now;
            DateDepense = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public string Numero { get; set; }
        public NatureMouvement Nature { get; set; }
        public virtual Salarier Salarie { get; set; }
        public  string CodeFournisseur { get; set; }
        public Decimal Montant { get; set; }
        public string Commentaire { get; set; }
        public string ModePaiement { get; set; }
        public string Tiers { get; set; }
        public string Banque { get; set; }
        public Nullable<DateTime> DateEcheance { get; set; }
        public string NumCheque { get; set; }
        public string CodeTiers { get; set; }
       public string NumVente { get; set; }
        public string NumAchat { get; set; }
        public string NomSalarier { get; set; }
        public string Frounisseur { get; set; }
        public DateTime DateDepense { get; set; }

    }
}
