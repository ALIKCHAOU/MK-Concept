using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class Salarier
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        public string numero { get; set; }
        public string Tel { get; set; }

        public string Matricule { get; set; }
        public decimal Solde { get; set; }

        public decimal MontantReglé { get; set; }
        public decimal MontantRestReglé { get 

            {
                return decimal.Subtract(Solde, MontantReglé);
            }
        }

        public decimal MontantJournalie { get; set; }
        public EtatSalarie EtatSalarie { get; set; }

    }
}
