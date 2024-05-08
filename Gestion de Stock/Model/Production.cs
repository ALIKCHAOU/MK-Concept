using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
  public  class Production
    {
        public Production()
        {
            DateCreation = DateTime.Now;
          
        }
        public int Id { get; set; }
        public string code { get; set; }  
        public DateTime DateCreation { get; set; }        
        public List<LigneProduction> LigneProductions { get; set; }
        public List<ListeMatierePermierUtiliser>   ListeMatierePermierUtiliser { get; set; }
        public decimal QuantiteNonconforme { get; set; }
        public int TotalArticle { get; set; }
        public decimal TotalPoids { get; set; }



    }
}
