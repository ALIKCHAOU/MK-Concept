using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class PointageJournalier
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Poste { get; set; }
        public virtual Salarier Salarier { get; set; }
        public decimal Montant { get; set; }
    }

}
