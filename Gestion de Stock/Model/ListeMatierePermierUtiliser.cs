using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
  public  class ListeMatierePermierUtiliser
    {
        public ListeMatierePermierUtiliser()
        {
            Date = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }

        [Required(ErrorMessage = "Le nom est manquant")]
        public string Nom { get; set; }

        public decimal Quantite { get; set; }


    }
}
