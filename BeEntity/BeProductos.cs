using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Class BeProductos
    /// </summary>
     public class BeProductos
    {
  
        public int ID { get; set; }

        [DisplayName("Producto")]
        public string Nombre { get; set; }

        [DisplayName("Estatus")]
        public int EstatusID { get; set; }

        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }

        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }

        [DisplayName("Usuario Actualizó")]
        public string UsuarioActualizo { get; set; }

        [DisplayName("Fecha Actualizó")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        public int AuditoriaID { get; set; }

        [DisplayName("Tipo Producto")]
        public int TipoProductoID { get; set; }

        [DisplayName("Tipo Producto")]
        public string Producto { get; set; }

        //public virtual BeEstatus Estatus { get; set; }
        //public virtual BeTipoProducto TipoProducto { get; set; }

    }
}
