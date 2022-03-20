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
    /// Class BeTipoApresamiento
    /// </summary>
   public class BeTipoApresamiento: BeUserLogueado
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        public string Nombre { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
        public int AuditoriaID { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Tipo Novedad")]
        public int TipoNovedadID { get; set; }
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
    }
}
