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
    /// Class BeTipoContrabando
    /// </summary>
    public class BeTipoContrabando : BeUserLogueado
    {
        
        public int ID { get; set; }

        public int AuditoriaID { get; set; }

        [DisplayName("Tipo Contrabando")]
        public int TipoProductoID { get; set; }

        [Required]
        [DisplayName("Tipo Novedad")]
        public int TipoNovedadID { get; set; }

        [DisplayName("Producto")]
        public int ProductoID { get; set; }

        [DisplayName("Tipo Contrabando")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]


        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
       /// [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        [DisplayName("Usuario Actualizó")]
        public string UsuarioActualizo { get; set; }

        [DisplayName("Fecha Actualizó")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        //public string Vista { get; set; }
        [Required]
        [DisplayName("Estatus")]
        public Nullable<int> EstatusID { get; set; }
    }
}
