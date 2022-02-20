using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistRE.Models
{
    public class Credencials
    {
        [Required]
        [DisplayName("Nombre de usuario")]
        public string userName { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        public string passWord { get; set; }
    }
}