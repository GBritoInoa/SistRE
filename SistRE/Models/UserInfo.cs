using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistRE.Models
{

    /// <summary>
    /// Classe User Info
    /// </summary>
    public class UserInfo
    {
        public string userName { get; set; }
        public string profile { get; set; }
        public int idProfile { get; set; }
        public string NombreCompleto { get; set; }
        public string Rango { get; set; }

        /// <summary>
        /// Información Usuario Logueado
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="profile"></param>
        /// <param name="idProfile"></param>
        /// <param name="NombreCompleto"></param>
        /// <param name="Rango"></param>
        public UserInfo(string userName, string profile, int idProfile, string NombreCompleto, string Rango)
        {
            this.userName = userName;
            this.profile = profile;
            this.idProfile = idProfile;
            this.NombreCompleto = NombreCompleto;
            this.Rango = Rango;
        }
    }
}