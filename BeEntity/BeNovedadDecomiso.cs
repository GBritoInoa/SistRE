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
    /// Class BeNovedadDecomiso
    /// </summary>
    public class BeNovedadDecomiso: BeUserLogueado
    {
        
        public int NovedadDecomisoID { get; set; }
        [DisplayName("Tipo Decomiso")]
        public int TipoDecomisoID { get; set; }
        [Required]
        [DisplayName("Cantidad Decomisada")]
        public decimal Cantidad { get; set; }
        public int AuditoriaID { get; set; }
        [Required]
        [DisplayName("Hora Novedad")]
        public System.TimeSpan HoraNovedad { get; set; }
        [Required]
        [DisplayName("Fecha Novedad")]
        public System.DateTime FechaNovedad { get; set; }
        public int TipoNovedadID { get; set; }
        [DisplayName("Tipo Medida")]
        public int TipoMedidaID { get; set; }
        [Required]
        [DisplayName("Provincia")]
        public int ProvinciaID { get; set; }
        [DisplayName("Droga")]
        public int TipoDrogaID { get; set; }
        [Required]
        [DisplayName("Razón o Causa")]
        public string Causa { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
        [DisplayName("Tipo ID")]
        public int TipoID { get; set; }
        [Required]
        [DisplayName("Brigada Responsable")]
        public int BrigadaID { get; set; }


        [Required]
        [DisplayName("Tipo Producto")]
        public int ProductoID { get; set; }

    }
}
