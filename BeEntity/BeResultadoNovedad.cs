using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
   public class BeResultadoNovedad
    {

        //public int NovedadID { get; set; }
        public string Novedad { get; set; }
        [DisplayName("Provincia donde ocurrió la Novedad")]
        public string Provincia { get; set; }

        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Porciento Novedad")]
         public string PorcientoNovedad { get; set; }
        public string Total { get; set; }

      



    }
}
