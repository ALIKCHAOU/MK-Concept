using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class ArticleChute
    {
     
        public ArticleChute()
        {      
            DateCreation = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public int Id { get; set; }
        public string Code { get; set; }
        public string NomArticle { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
        public string Origine { get; set; }
        public int Quantite { get; set; }
        public decimal Poids { get; set; }
        public int Metrage { get; set; }
        public int idArticle { get; set; }




    }
}
