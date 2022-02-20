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
    /// Class BeTipoMedidas
    /// </summary>
   public class BeTipoMedidas
    {

        
        public int ID { get; set; }

        //[Required(ErrorMessage = "{0} Debe elegir tipo de Producto")]
        [DisplayName("Tipo Medida ID")]
        public int TipoMedidaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Medida")]
        public string Nombre { get; set; }
        
        [DisplayName("Tipo Producto")]
        public string NombreProducto { get; set; }

        //[Required(ErrorMessage = "{0} Debe elegir tipo de Producto")]
        [DisplayName("Tipo Producto")]
        public int TipoProductoID { get; set; }

        [Required(ErrorMessage = "{0} Debe elegir Estatus")]
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }

        public int AuditoriaID { get; set; }
  
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
