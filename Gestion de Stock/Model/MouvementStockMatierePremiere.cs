using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{

    public class MouvementStockMatierePremiere
    {



        public MouvementStockMatierePremiere()
        {
            Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
       
        public string Code { get; set; }

        public string Intitulé { get; set; }

        public string Article { get; set; }


        public decimal QuantiteAchetee { get; set; }
        public decimal QuantiteUtilisee { get; set; }


        public SensStock Sens { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }

        public decimal QuantiteStockInitial { get; set; }
        public decimal QuantiteStockFinal { get; set; }


        public decimal PrixMouvement { get; set; }
        public decimal PMP { get; set; }

        public string Numero { get; set; } //  Achat ou Production
       





    }
}
