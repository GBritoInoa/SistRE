//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public int EstatusID { get; set; }
        public int AuditoriaID { get; set; }
        public int TipoProductoID { get; set; }
    
        public virtual Auditoria Auditoria { get; set; }
        public virtual Estatus Estatus { get; set; }
        public virtual TipoProducto TipoProducto { get; set; }
    }
}
