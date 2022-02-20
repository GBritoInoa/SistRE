using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Class BeMilitar
    /// </summary>
   public  class BeMilitar
    {

        [DisplayName("CompaniaID")]
        public int CompaniaID { get; set; }
        public int Nombre { get; set; }
        [DisplayName("Companía")]
        public int RangoID { get; set; }
        public string Rango { get; set; }

    }
}
