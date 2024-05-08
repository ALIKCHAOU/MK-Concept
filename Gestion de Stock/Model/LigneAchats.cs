using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
  public  class LigneAchats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public string NomArticle { get; set; }

        public decimal Quantity { get; set; }

        public string unite { get; set; }

        public int TVA { get; set; } = 19;

        [Required]
        public decimal PrixUnitaire { get; set; }

        [Required]
        public decimal TotalLigneHT { get { return Math.Round(Decimal.Multiply(PrixUnitaire, Quantity), 3); } }


        [Required]
        public decimal TotalLigneTTC { get { return Math.Round(Decimal.Multiply(PrixUnitaire, Quantity) + Decimal.Divide(Decimal.Multiply(Decimal.Multiply(PrixUnitaire, Quantity), TVA), 100) , 3); } }



        public Achat Achat { get; set; }




    }
}
