using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Class User Logueado
    /// </summary>
   public class BeUserLogueado
    {
        [DisplayName("Usuario Logueado")]
        public string UserLogueado { get; set; }
        [DisplayName("Miembro ERD")]
        public string NombreCompleto { get; set; }
        public string Rango { get; set; }
    }
}
