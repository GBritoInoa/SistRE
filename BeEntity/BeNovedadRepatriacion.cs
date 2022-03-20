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
    /// Class BeNovedadRepatriación
    /// </summary>
   public class BeNovedadRepatriacion : BeUserLogueado
    {

        [DisplayName("RapatriacionID")]
        public int RepatriacionID { get; set; }

        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Tipo Novedad")]
        public int TipoNovedadID { get; set; }

       
        [DisplayName("Provincia")]
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Brigada")]
        public int ProvinciaID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe introducir la cantidad de apresados")]
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Cantidad Repatriados")]
        public int Cantidad { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Sexo")]
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Sexo")]
        public int SexoID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Brigada")]
        [DisplayName("Brigada Responsable")]
        public int BrigadaID { get; set; }


        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar la Causa")]
        [DisplayName("Causa Repatriación")]
        public int CausaID { get; set; }


        [DisplayName("Estatus")]
        public int EstatusID { get; set; }

        public Nullable<int> AuditoriaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar País")]
        [DisplayName("País")]
        public int PaisID { get; set; }

        //[DisplayName("Razón/Causa Novedad")]
        [DisplayName("Comentario u observación")]
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        //[MinLength(10, ErrorMessage = "Debe tener mínimio 10 caracteres")]
        //[MaxLength(150, ErrorMessage = "No debe sobrepasar los 150 caracteres")]
        [MinLength(length: 5)]
        public string Causa { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Novedad")]
        public System.DateTime FechaNovedad { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Hora Novedad")]
        public System.TimeSpan HoraNovedad { get; set; }
        
    }
}
