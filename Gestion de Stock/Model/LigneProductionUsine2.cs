using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
   public class LigneProductionUsine2
    {
        public LigneProductionUsine2()
        {
            DateCreation = DateTime.Now;
            code = DateTime.Now.ToString();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NomArticle { get; set; }
        public string NomArticleFini { get; set; }
        public string code { get; set; }   
        public DateTime DateCreation { get; set; }
        public string Poste { get; set; }       
        public int QteUtiliser { get; set; }
        public int QteProduite { get; set; }

    }
}
