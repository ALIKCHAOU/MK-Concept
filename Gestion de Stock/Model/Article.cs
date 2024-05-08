using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Article
    {
        private readonly ApplicationContext context;
        public Article()
        {
            context = new ApplicationContext();
            DateCreation = DateTime.Now;
            GereStock = false;


        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }

        public decimal PrixdeVenteRevendeur { get; set; }
        public decimal PrixdeVenteGros1 { get; set; }
        public decimal PrixdeVenteGros2 { get; set; }
        public decimal PrixdeVentepublic { get; set; }      

        [Required]
        public DateTime DateCreation { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPoids { get; set; }
        public bool GereStock { get; set; }        
        public int Metrage { get; set; }
        public int IdArticlechute { get; set; }



    }
}
