using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Usuario")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DisplayName("Nombre")]
        public string Nombres { get; set; }
        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }
        [DisplayName("Apellidos, Nombre")]
        public string ApellidosNombre{ get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        public string Salt { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }
        [DisplayName("Institución")]
        public Nullable<int> InstitucionID { get; set; }
        public string Institucion { get; set; }
        [DisplayName("Cambio Clave")]
        public bool CambioClave { get; set; }
        public int AuditoriaID { get; set; }
        public int BrigadaID { get; set; }
        public string Brigada { get; set; }
        public int RangoID { get; set; }
        //public string Rango { get; set; }
        [DisplayName("Perfil")]
        public int PerfilID { get; set; }
        [DisplayName("Perfil")]
        public string Perfil { get; set; }
        [DisplayName("Carnet")]
        public int NumCarnet { get; set; }
    }
}
