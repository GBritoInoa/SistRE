using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
  public  class BeHistoricoNovedades
    {


        public int NovedadesID { get; set; }
        [Required]
        public int TipoNovedadID { get; set; }
        [Required]
        public System.DateTime FechaNovedad { get; set; }
        [Required]
        public System.TimeSpan HoraNovedad { get; set; }
        [Required]
        public int AuditoriaID { get; set; }
    }
}
