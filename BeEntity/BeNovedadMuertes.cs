using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Class BeDefuncion
    /// </summary>
    public class BeNovedadMuertes: BeUserLogueado
    {

        public int NovedadMuerteID { get; set; }

        //[Required]
        [DisplayName("Brigada Responsable")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Brigada")]
        public int BrigadaID { get; set; }

        public int TipoNovedadID { get; set; }

        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Provincia")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Provincia")]
        public int ProvinciaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Novedad")]
        public System.DateTime FechaNovedad { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Hora Novedad")]
        public System.TimeSpan HoraNovedad { get; set; }

        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [MinLength(length: 10)]
        public string Causa { get; set; }

        public Nullable<int> AuditoriaID { get; set; } = 0;

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Sexo")]
        public int SexoID { get; set; }

        [DisplayName("Estatus")]
        public Nullable<int> EstatusID { get; set; } = 1;


        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Tipo Defunción")]
        public int TipoMuerteID { get; set; }

        [DisplayName("Rango")]
        public int RangoID { get; set; } = 0;

        [DisplayName("Compañía")]
        public int CompaniaID { get; set; } = 0;

    }
}
