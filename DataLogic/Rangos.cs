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
    
    public partial class Rangos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rangos()
        {
            this.Miembros = new HashSet<Miembros>();
        }
    
        public int RangoID { get; set; }
        public string nombre { get; set; }
        public int nivelRangoID { get; set; }
        public string Imagen { get; set; }
        public string codAnterior { get; set; }
        public double Sueldo { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public string nombreARD { get; set; }
        public string Abreviatura { get; set; }
        public decimal Riesgo { get; set; }
        public decimal Cargo { get; set; }
        public string Abreviatura2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembros> Miembros { get; set; }
    }
}
