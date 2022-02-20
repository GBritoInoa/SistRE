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
    /// Class Companía
    /// </summary>
   public class BeCompania
    {
        [DisplayName("CompaniaID")]
        public int CompaniaID { get; set; }
        [DisplayName("Companía")]
        public string Nombre { get; set; }
        [DisplayName("BatallonID")]
        public int BatallonID { get; set; }
    }
}
