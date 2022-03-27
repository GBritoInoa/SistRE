using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
   public class BeFiltros
    {
       


            [DataType(DataType.Date)]
            [Display(Name = "Fecha Inicio")]
            public Nullable<System.DateTime> Fecha_Registro { get; set; }

            [DataType(DataType.Date)]
            [Display(Name = "Fecha Fin")]
            public Nullable<System.DateTime> Fecha_Fin { get; set; }


        }
    }
