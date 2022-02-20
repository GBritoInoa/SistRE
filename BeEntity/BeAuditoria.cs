using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BeEntity
{
    /// <summary>
    /// Class Auditoría
    /// </summary>
    /// Esto es una prueba
    /// Esto es una prueba 2
   public  class BeAuditoria
    {

        public int ID { get; set; }
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        [DisplayName("Usuario Actualizó")]
        public string UsuarioActualizo { get; set; }
        [DisplayName("Fecha Actualizó")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }
    }
}
