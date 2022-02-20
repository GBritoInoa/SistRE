using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Class Sexo
    /// </summary>
 public   class BeSexo
    {

        [DisplayName("Tipo Sexo")]
        public int SexoID { get; set; }
        [DisplayName("Sexo")]
        public string Nombre { get; set; }

    }
}
