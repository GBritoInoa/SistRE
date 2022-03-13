using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
    /// <summary>
    /// Class BeTipoDocumento
    /// </summary>
    public class BeTipoDocumento
    {

        public int ID { get; set; }
        [DisplayName("Tipo Documento")]
        public string Nombre { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
        [DisplayName("Auditoria")]
        public int  AuditoriaID { get; set; }
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }
        public Nullable<System.DateTime> FechaActualizo { get; set; }
    }
}
