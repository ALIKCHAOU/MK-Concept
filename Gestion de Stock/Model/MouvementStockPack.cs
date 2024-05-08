using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{

    public class MouvementStockPack
    {



        public MouvementStockPack()
        {
            Date = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
       
        public string Code { get; set; }

        public string Intitulé { get; set; }

        public string Article { get; set; }


        public int QuantiteProduite { get; set; }
        public int QuantiteVendue { get; set; }


        public SensStock Sens { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }

        public int QuantiteStockInitial { get; set; }
        public int QuantiteStockFinal { get; set; }

        public string Numero { get; set; }  // Production ou BonDeLivraison

       







    }
}
