﻿using Gestion_de_Stock.Model.Enumuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
  public  class Devis
    {
       
        public Devis()
        {
            DateCreation = DateTime.Now;
            DateDevis = DateTime.Now;
            Datelivraison = DateTime.Now.AddDays(7);
        }


        [Key]
        public string Code { get; set; }
        public string Reference { get; set; }

        
        [Required(ErrorMessage = "Date Creation Commande is required")]
        public DateTime DateCreation { get; set; }

        public DateTime DateDevis { get; set; }

        public DateTime Datelivraison { get; set; }

        public string Emitteur { get; set; }
       

        public decimal Timbre { get; set; } = 1.000m;

        public string Currency { get; set; } = "TND";
    

        public int TVA { get; set; } = 19;

        public decimal Total_DevisHT { get; set; }
       

        public decimal Total_DevisTTC { get; set; }

        public decimal TOTALTVA
        {
            get
            {
                return decimal.Round(decimal.Divide(decimal.Multiply(Total_DevisHT, TVA), 100), 3);
            }
        }

        public ICollection<ligneDevis> ligneDevis { get; set; }

        // Document
        public string FileName { get; set; }

        public int FileSize { get; set; }

        public byte[] Attachment { get; set; }

        public   Client Client { get; set; }

        public ModePaiment ModePaiment { get; set; }

        public string ModaliterPaiment{ get; set; }

    }
}
