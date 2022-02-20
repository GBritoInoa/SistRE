using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
    /// <summary>
    /// Class BeTipoMedida
    /// </summary>
    public class BeTipoMedida
    {

        [DisplayName("Tipo Medida")]
        public int TipoMedidaID { get; set; }
        public string Medida { get; set; }
    }
}
