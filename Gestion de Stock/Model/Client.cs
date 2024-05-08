using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model
{
  public  class Client
    {
        private readonly ApplicationContext context;
        public Client()
        {
            DateCreation = DateTime.Now;
            context = new ApplicationContext();
            int lastClient = context.Clients.Count() + 1;
            if (lastClient == 0)
            {
                Code = "CL00000001";
            }
            else
            {
                Code = "CL" + (lastClient).ToString("D8");
            }
        }
        [Key]
        public string Code { get; set; }
        
        public string RaisonSociale { get; set; }

     
        public string Nom { get; set; }
   
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Date Creation is required")]
        public DateTime DateCreation { get; set; }
        [NotMapped]
        public String FullName
        {
            get { return Prenom + " " + Nom; }
            set { _fullName = value; }
        }

        private String _fullName;

        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public string MatriculeFiscale { get; set; }
        public string Email { get; set; }
        public string FAX { get; set; }
        
        public Status Status { get; set; }
        public string Activie { get; set; }
       





    }
}
