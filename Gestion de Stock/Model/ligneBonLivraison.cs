using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class ligneBonLivraison
    {
        public int Id { get; set; }


        public string Description { get; set; }

        [Required]
        public decimal PrixHT { get; set; }



        public BonDeSortie BonDeCommande { get; set; }

        public int Qty { get; set; }

        public decimal Remise { get; set; }

        public int Metrage { get; set; }

        public int TVA { get; set; } = 19;

        [Required]
        public decimal TotalLigneHT { get { return Math.Round(Decimal.Multiply(PrixHT, Qty) - Decimal.Divide(Decimal.Multiply(Decimal.Multiply(PrixHT, Qty), Remise), 100), 3); } }
        [Required]
        public decimal TotalLigneTTC { get { return Math.Round(Decimal.Multiply(PrixHT, Qty) + Decimal.Divide(Decimal.Multiply(Decimal.Multiply(PrixHT, Qty), TVA), 100) - Decimal.Divide(Decimal.Multiply(Decimal.Multiply(PrixHT, Qty), Remise), 100), 3); } }
    }
}
