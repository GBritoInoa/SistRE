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
    /// Class para el Registro de  Novedades Contrabando
    /// </summary>
    public class BeNovedadContrabando : BeUserLogueado
    {

        public int NovedadContrabandoID { get; set; }
    
        [Required]
        [DisplayName("Tipo Contrabando")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe elegir tipo Contrabando")]
        public int TipoContrabandoID { get; set; }

        [DisplayName("Tipo Novedad")]
        public int TipoNovedadID { get; set; } 

        public int AuditoriaID { get; set; } 

        [Required]
        [DisplayName("Cantidad Contrabando")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe introducir la Cantidad")]
        public decimal Cantidad { get; set; }

        [DisplayName("Tipo Medida")]
        public int TipoMedidaID { get; set; } 

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        public string Causa { get; set; }


        [Required(ErrorMessage = "{0} no puede estar vacio")]
        public DateTime FechaNovedad { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Hora Novedad")]
        public TimeSpan HoraNovedad { get; set; }

        [DisplayName("Estatus")]
        public int EstatusID { get; set; }

        public DateTime FechaActualizo { get; set; }

        [Required]
        [DisplayName("Brigada Responsable")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Brigada")]
        public int BrigadaID { get; set; }

        [Required]
        [DisplayName("Provincia")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar Provincia")]
        public int ProvinciaID { get; set; }

  
        [DisplayName("Tipo Producto ID")]
        public int TipoProductoID { get; set; }

        [Required]
        [DisplayName("Tipo Producto")]
        [Range(0, int.MaxValue, ErrorMessage = "Debe seleccionar tipo Producto")]
        public int ProductoID { get; set; }

       

    }
}
