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
    
    public partial class Miembros
    {
        public string Cedula { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public System.DateTime fecha_Ingreso_Institucion { get; set; }
        public System.DateTime fecha_funcion { get; set; }
        public System.DateTime fecha_ingreso_unidad { get; set; }
        public System.DateTime fecha_nacimiento { get; set; }
        public int MunicipioID { get; set; }
        public string licencia_conducir { get; set; }
        public string telefono { get; set; }
        public System.DateTime fecha_ascenso { get; set; }
        public System.DateTime fecha_calculada { get; set; }
        public string numero_escalafon { get; set; }
        public bool estatus { get; set; }
        public int RangoID { get; set; }
        public int ProfesionID { get; set; }
        public string direccion { get; set; }
        public string urbanizacion { get; set; }
        public int FuncionID { get; set; }
        public int CompaniaID { get; set; }
        public int RangoIDing { get; set; }
        public int ProfesionIDing { get; set; }
        public string recomendadoPor { get; set; }
        public string ocupacionAnterior { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public System.DateTime fechaCarnet { get; set; }
        public Nullable<int> numero_carnet { get; set; }
        public string RutaFoto { get; set; }
        public System.DateTime modificado { get; set; }
        public string usuario { get; set; }
        public string dirIP { get; set; }
        public string Sexo { get; set; }
        public decimal Sueldo { get; set; }
        public string NoCuenta { get; set; }
        public decimal Especialismo { get; set; }
        public decimal Compensacion { get; set; }
        public decimal Prima { get; set; }
        public int InstitucionID { get; set; }
        public int PromocionID { get; set; }
        public int LugarNacimiento { get; set; }
        public bool Bautismo { get; set; }
        public bool Confirmacion { get; set; }
        public bool Comunion { get; set; }
        public bool Matrimonio { get; set; }
        public int TipoLicenciaConducirID { get; set; }
        public bool reintegro { get; set; }
        public string Celular { get; set; }
        public string telefonoTrabajo { get; set; }
        public int tSangreID { get; set; }
        public int PielID { get; set; }
        public int OjosID { get; set; }
        public int CabelloID { get; set; }
        public int EstatusID { get; set; }
        public int EstadoCivilID { get; set; }
        public string Correo { get; set; }
        public string Facebook { get; set; }
        public string tweeter { get; set; }
        public string DireccionAlterna { get; set; }
        public string Alerta { get; set; }
        public decimal CompensacionEspecial { get; set; }
        public int Adicion { get; set; }
        public System.DateTime fechaAdicion { get; set; }
        public string tarjeta { get; set; }
        public string Reintegros { get; set; }
    
        public virtual Companias Companias { get; set; }
        public virtual Rangos Rangos { get; set; }
    }
}
