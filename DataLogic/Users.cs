//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int EstatusID { get; set; }
        public Nullable<int> InstitucionID { get; set; }
        public bool CambioClave { get; set; }
        public int AuditoriaID { get; set; }
        public int BrigadaID { get; set; }
        public int PerfilID { get; set; }
    }
}
