using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class RapportHistoriqueAchat
    {
        [Key]
        public int ID { get; set; }
        public Achat Achat { get; set; }
        public virtual List<HistoriquePaiementAchats> HistoriquePaiementAchat { get; set; }
    }
}
