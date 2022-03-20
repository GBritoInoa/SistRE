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
    /// Class Tipo Arma
    /// </summary>
 public   class BeTipoArma: BeUserLogueado
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Tipo Arma")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        //[DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        [DisplayName("Usuario Actualizó")]
        public string UsuarioActualizo { get; set; }
        [DisplayName("Fecha Actualizó")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        //[Required]
        //public Nullable<int> TipoNovedadID { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
        public int AuditoriaID { get; set; }
    }
}
