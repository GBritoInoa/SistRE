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
    /// Class BeCategoriaProtesta
    /// </summary>
    public class BeCategoriaProtesta : BeUserLogueado
    {

        [DisplayName("Categoria Protesta")]
         public int AuditoriaID { get; set; }
        public int CategoriaProtestaID { get; set; }
        [DisplayName("Categoria Protesta")]
        public string Nombre { get; set; }
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
        public string Vista { get; set; }
        [Required]
        [DisplayName("Estatus")]
        public Nullable<int> EstatusID { get; set; }
    }
}
