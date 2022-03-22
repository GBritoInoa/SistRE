using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
    /// <summary>
    /// Class BeTipoProducto
    /// </summary>
    public class BeTipoProducto : BeUserLogueado
    {

        [DisplayName("Tipo Producto")]
        public int TipoProductoID { get; set; }
        [DisplayName("Producto")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        public string Vista { get; set; }
        [Required]
        [DisplayName("Estatus")]
        public Nullable<int> EstatusID { get; set; }
        public int AuditoriaID { get; set; }
    }
}
