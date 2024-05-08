using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class LigneProduction
    {
        public LigneProduction()
        {
            DateCreation = DateTime.Now;

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomArticle { get; set; }   
        public DateTime DateCreation { get; set; }
        public string Poste { get; set; }
        public string Chaine { get; set; }   
        public int Quantite { get; set; }
        public decimal Poids { get; set; }
        public int Metrage { get; set; }
        

    }
}
