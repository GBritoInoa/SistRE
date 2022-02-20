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
    /// Class Ausencias
    /// </summary>
    public class BeAusencias
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Tipo Ausencia")]
        public string Nombre { get; set; }

        [DisplayName("Tipo Novedad")]
        public int TipoNovedadID { get; set; }
        [Required]
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
        [Required]
        [DisplayName("Auditoria ID")]
        public int AuditoriaID { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }
        public Nullable<System.DateTime> FechaActualizo { get; set; }
    }
}
