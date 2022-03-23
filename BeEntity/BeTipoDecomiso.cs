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
    /// Class Tipo Decomiso
    /// </summary>
   public class BeTipoDecomiso : BeUserLogueado
    {
        public int ID { get; set; }

        [Required]
        public int TipoNovedadID { get; set; }

        [Required]
        [DisplayName("Tipo Producto")]
        public int TipoProductoID { get; set; }

        [DisplayName("Producto")]
        public int ProductoID { get; set; }

        [DisplayName("Tipo Decomiso")]
        public string Nombre { get; set; }

        [Required]
        [DisplayName("Estatus ")]
        public int EstatusID { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }    
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        [DisplayName("Usuario Actualizó")]
        public string UsuarioActualizo { get; set; }
        [DisplayName("Fecha Actualizó")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        [DisplayName("Auditoría")]
        public int AuditoriaID { get; set; }
   

     

    }
}
