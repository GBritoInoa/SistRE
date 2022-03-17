using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
    public class BeNovedadProtesta
    {
        [DisplayName("Novedad Protesta")]
        public int NovedadProtestaID { get; set; } 
        
        [DisplayName("Tipo Novedad")]
        public int TipoNovedadID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar la Provincia")]
        [DisplayName("Provincia")]
        public int ProvinciaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Novedad")]
        public System.DateTime FechaNovedad { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Hora Novedad")]
        public TimeSpan HoraNovedad { get; set; }

        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        public int AuditoriaID { get; set; }

        [DisplayName("Estatus")]
        public int EstatusID { get; set; }


        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [MaxLength(length:300)]
        [DisplayName("Lugar de la Protesta")]
        public string LugarProtesta { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar el tipo de Protesta")]
        [DisplayName("Tipo Protesta")]
        public int TipoProtestaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Institucion Protestante")]
        [DisplayName("Institucion Protestante")]
        public int InstitucionProtestanteID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Categoria ProtestaID")]
        [DisplayName("Categoria Protesta")]
        public int CategoriaProtestaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Causa")]
        public string Causa { get; set; }


        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }

        [DisplayName("Fecha Creó")]
        public System.DateTime FechaCreo { get; set; }
        public string UserLogueado { get; set; }


    }
}
