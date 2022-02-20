using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Class BeTipoMoneda
    /// </summary>
   public  class BeTipoMoneda
    {

        [DisplayName("Tipo Moneda")]
        public int TipoMonedaID { get; set; }              
        [DisplayName("Moneda")]
        public string Nombre { get; set; }
        public int EstatusID { get; set; }
        public string Simbolo { get; set; }
    }
}
