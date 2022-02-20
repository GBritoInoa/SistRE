using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BeEntity
{
    public  class BeTipoHerido
    {
                    
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Causa Herida")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario Creó")]
         public string UsuarioCreo { get; set; }
        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        [DisplayName("Usuario Actualizó")]
        public string UsuarioActualizo { get; set; }
        [DisplayName("Fecha Actualizó")]
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        public int TipoNovedadID { get; set; }
        [DisplayName("Estatus")]
        public int EstatusID { get; set; }


    }
}
