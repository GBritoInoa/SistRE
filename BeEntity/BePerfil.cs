﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEntity
{
    /// <summary>
    /// Clase Perfil
    /// </summary>
    public class BePerfil
    {
        public int PerfilID { get; set; }


        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Perfil")]
        public string Nombre { get; set; }


        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Descripción Perfil")]
        public string Descripcion { get; set; }

        [DisplayName("Estatus")]
        public int EstatusID { get; set; }

        public int AuditoriaID { get; set; }

        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }
        public Nullable<System.DateTime> FechaActualizo { get; set; }
    }
}

