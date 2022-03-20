using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeEntity
{

    /// <summary>
    /// Class BeNovedadPerdidaDocumento
    /// </summary>
   public  class BeNovedadPerdidaDocumento: BeUserLogueado
    {
        public int ID { get; set; }


        [DisplayName("Tipo Novedad ")]
        public int TipoNovedadID { get; set; }
        [DisplayName("Estatus ")]
        public int EstatusID { get; set; }
        [DisplayName("Rango ")]
        public int RangoID { get; set; }
        [DisplayName("Compañía")]
        public int CompaniaID { get; set; }
        public string Causa { get; set; }
        [DisplayName("Fecha Novedad ")]
        public System.DateTime FechaNovedad { get; set; }
        [DisplayName("Hora Novedad ")]
        public System.TimeSpan HoraNovedad { get; set; }
        public Nullable<int> AuditoriaID { get; set; }
        [DisplayName("Tipo Documento ")]
        public int TipoDocumentoID { get; set; }
        [DisplayName("Provincia ")]
        public int ProvinciaID { get; set; }
        
    }
}
