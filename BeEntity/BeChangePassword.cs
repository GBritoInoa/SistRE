using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{

    /// <summary>
    /// Classe Change Password
    /// </summary>
   public class BeChangePassword
    {

        [Required(ErrorMessage = "Usuario requerido.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Clave actual(número carnet)")]
        [StringLength(10, ErrorMessage = "Debe tener mínimio 6 caracteres", MinimumLength = 6)]
        public string Password  { get; set; }
        [Required(ErrorMessage = " Nueva Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Debe tener mínimio 6 caracteres", MinimumLength = 6)]

        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirmar Contraseña")]     
        [DataType(DataType.Password)]
        //[Compare(NewPassword)]
        [StringLength(10, ErrorMessage = "The password must be atleast 6 characters long", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }


    }
}
