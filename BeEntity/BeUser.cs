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
    /// Clas Users
    /// </summary>
  public  class BeUser: BeUserLogueado
    {
        public int ID { get; set; }

        public int UserId { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Nombre")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [DisplayName("Apellidos, Nombre")]
        public string ApellidosNombre{ get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        public string Salt { get; set; }

        [DisplayName("Estatus")]
        public int EstatusID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Institución")]
        public Nullable<int> InstitucionID { get; set; }

        public string Institucion { get; set; }


        [DisplayName("Cambio Clave")]
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        public bool CambioClave { get; set; }

        public int AuditoriaID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        public int BrigadaID { get; set; }

        public string Brigada { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        public int RangoID { get; set; }
        //public string Rango { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Perfil")]
        public int PerfilID { get; set; }

        [DisplayName("Perfil")]
        public string Perfil { get; set; }

        [DisplayName("Carnet")]
        public string NumCarnet { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        public int CompaniaID { get; set; }

        public string Compania { get; set; }

        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        [DisplayName("Usuario Actualizó")]
        public string UsuarioActualizo { get; set; }
        [DisplayName("Fecha Actualizó")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }
    }
}
