using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
     public class venteHistoriqueP
     {[Key]
        public int ID { get; set; }
        public Vente vente { get; set; }
        public virtual List<HistoriquePaiementVente> HistoriquePaiementVentes { get; set; }
    }
}
