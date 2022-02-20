using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
  public  class BeTipoCombustible
    {

        [DisplayName("Tipo Combustible")]
        public int TipoCombustibleID { get; set; }
        [DisplayName("Combustible")]
        public string Nombre { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
    }
}
