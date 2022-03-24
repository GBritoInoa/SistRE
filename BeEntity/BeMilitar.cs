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
        [DisplayName("Número Carnet")]
        public Nullable<int> NumCarnet { get; set; }
        public string Miembro { get; set; }
        [DisplayName("Compañía")]
        public string Compania { get; set; }

        [DisplayName("Rango Id")]
        public int RangoID { get; set; }
        public string Rango { get; set; }
        public int InstitucionID { get; set; }
        [DisplayName("Institución")]
        public string Institucion { get; set; }
        public int BrigadaID { get; set; }
        public string Brigada { get; set; }


    }
}
