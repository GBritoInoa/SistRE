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
    
    public partial class NovedadDecomiso
    {
        public int NovedadDecomisoID { get; set; }
        public int TipoDecomisoID { get; set; }
        public decimal Cantidad { get; set; }
        public System.TimeSpan HoraNovedad { get; set; }
        public System.DateTime FechaNovedad { get; set; }
        public int TipoNovedadID { get; set; }
        public int TipoMedidaID { get; set; }
        public int TipoID { get; set; }
        public int ProvinciaID { get; set; }
        public int BrigadaID { get; set; }
        public string Causa { get; set; }
        public int EstatusID { get; set; }
        public int AuditoriaID { get; set; }
    }
}
