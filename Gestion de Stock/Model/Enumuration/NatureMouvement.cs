using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Stock.Model.Enumuration
{
    public enum NatureMouvement : int
    {
        Salarié = 1,    
        STEG=2,
        Piece=3,
        LeasingCamion1=4,
        LeasingCamion2=5,
        Autre = 6,
        ClôtureCaisse=7,
        Achat=8,
        

    }
}
