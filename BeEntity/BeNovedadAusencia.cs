using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
  public class BeNovedadAusencia : BeUserLogueado
    {


        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0,int.MaxValue,ErrorMessage ="Debe seleccionar el tipo de Ausencia")]
        [DisplayName("Tipo Ausencia")]
        public int AusenciaID { get; set; }

        [DisplayName("Tipo Novedad ID")]
        public int TipoNovedadID { get; set; }
        
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }

        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        public int AuditoriaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar el Rango")]
        [DisplayName("Rango")]
        public int RangoID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar la Compañía")]
        [DisplayName("Compañía")]
        public int CompaniaID { get; set; }        

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        //[Range(0, 50, ErrorMessage = "Debe tener mínimo 10 caracteres")]
        [DisplayName("Razón/Causa")]
        public string Causa { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Novedad")]
        public System.DateTime FechaNovedad { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        //[Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar hora Novedad")]
        [DisplayName("Hora Novedad")]
        public TimeSpan  HoraNovedad { get; set; }

 
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
          
        [DisplayName("Fecha Creó")]
        public System.DateTime FechaCreo { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Sexo")]
        public int SexoID { get; set; }


    }
}
