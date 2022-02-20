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
    /// Class Tipo Incautación
    /// </summary>
 public   class BeTipoIncautacion
    {

        public int ID { get; set; }
        [Required(ErrorMessage ="{0} este campo no puede estar vacío")]
        [DisplayName("Tipo Incautación")]
        public string Nombre { get; set; }
        public int AuditoriaID { get; set; }
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
        [DisplayName("Tipo Novedad")]
        public Nullable<int> TipoNovedadID { get; set; }
        [DisplayName("Tipo Novedad")]
        public string NombreNovedad { get; set; }
        [DisplayName("Tipo Producto")]
        public int TipoProductoID { get; set; }
    }
}
