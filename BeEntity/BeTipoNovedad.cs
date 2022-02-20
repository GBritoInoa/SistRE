using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeEntity
{

    /// <summary>
    /// Class Tipo Novedad
    /// </summary>
    public class BeTipoNovedad
    {


        public int ID { get; set; }


        public int TipoNovedadID { get; set; }

        [Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Tipo Novedad")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Usuario Creó")]
        public string UsuarioCreo { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar vacio")]
        [DisplayName("Fecha Creó")]
        public Nullable<System.DateTime> FechaCreo { get; set; }
        public string UsuarioActualizo { get; set; }
        public Nullable<System.DateTime> FechaActualizo { get; set; }
        public string Vista { get; set; }
        [Required]
        [DisplayName("Estatus")]
        public Nullable<int> EstatusID { get; set; }
    }
}
