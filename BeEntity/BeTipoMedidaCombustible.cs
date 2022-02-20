using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
   public class BeTipoMedidaCombustible
    {

        [DisplayName("Tipo Medida Combustible")]
        public int TipoMedidaCombustibleID { get; set; }
        [DisplayName("Medida Combustible")]
        public string Medida { get; set; }
        public int EstatusID { get; set; }
    }
}
