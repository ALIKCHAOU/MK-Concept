using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
  public  class Societe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RaisonSociale { get; set; }
        public string Capitale { get; set; }
 
        public string Site { get; set; }
        public string CodePostale { get; set; }
        public string Adresse { get; set; }
        public string Complement { get; set; }
        public string MatriculFiscal { get; set; }
        public string Activite { get; set; }
        public string Telephone { get; set; }
        public string Rib { get; set; }
        public string Ville { get; set; }
        public decimal Timber { get; set; } = 1.00m;
        public string Mail { get; set; }
        public int TVA { get; set; } = 19;


    }
}
