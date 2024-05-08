using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
    public class Achat
    {
        
        public Achat()
        {
            DateCreation = DateTime.Now;
          
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Code { get; set; }


        public int TVA { get; set; }
        [Required]       
        public DateTime DateCreation { get; set; }        

        public string CodeFournisseur  { get; set; }
        public string RaisonSociale { get; set; }
        

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public byte[] Attachment { get; set; }


        public EtatAchat EtatAchat { get; set; }

        public string NomEtatAchat
        {

            get
            {
                if (this.EtatAchat == EtatAchat.Reglee)
                { return "Réglé"; }

                else if (this.EtatAchat == EtatAchat.PartiellementReglee)
                { return "Partiellement Réglé"; }

                else return "Non Réglé";
            }
        }
        public decimal MontantReglement { get; set; }
        public decimal MontantRegle { get; set; }

        public decimal ResteApayer { get { return MontantReglement - MontantRegle; } }
        public decimal Total_AchatHT { get; set; }

        public decimal Total_AchatTTC { get; set; }

        public string NFactureFounisseur { get; set; }

        public ICollection<LigneAchats> Lines { get; set; }

       
    }
}
