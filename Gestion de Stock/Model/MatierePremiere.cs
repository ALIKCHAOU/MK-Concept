using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class MatierePremiere
    {
        private readonly ApplicationContext context;
        public MatierePremiere()
        {
            context = new ApplicationContext();
            int lastPacks = this.Id;
            if (lastPacks == 0)
            {
                Code = "M00000001";
            }
            else
            {
                Code = "M" + (lastPacks).ToString("D8");
            }
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage = "Le nom est manquant")]
        public string Nom { get; set; }

        public string Description { get; set; }
        
        public string Unite { get; set; }

        public decimal Quantity { get; set; }

        public decimal DernierPirxAchat { get; set; }

        public decimal PrixMoyen { get; set; }

    }
}
