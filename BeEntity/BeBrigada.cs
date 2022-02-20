using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BeEntity
{

    /// <summary>
    /// Class BeBrigada
    /// </summary>
    public class BeBrigada
    {
        [DisplayName("BrigadaID")]
        public int UnidadID { get; set; }
        [DisplayName("Brigada")]
        public string Nombre { get; set; }
    }
}
