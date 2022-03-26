using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Class Reporte Novedades
    /// </summary>
  public  class BeReporteNovedades
    {
        public int NovedadID { get; set; }
        public string Novedad { get; set; }
        [DisplayName("Tipo Novedad")]
        public int TipoNovedadID { get; set; }
        public int CantidadNovedad { get; set; }
        public int ProvinciaID { get; set; }
        public string Provincia { get; set; }
        [DisplayName("Fecha Desde")]
        public DateTime FechaDesde { get; set; }
        [DisplayName("Fecha Desde")]
        public DateTime FechaHasta { get; set; }

    }
}
