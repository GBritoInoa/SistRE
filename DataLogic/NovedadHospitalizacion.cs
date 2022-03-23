using BeEntity;
namespace DataLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class NovedadHospitalizacion : BeUserLogueado
    {
        public int NovedadHospitalizacionID { get; set; }
        public int BrigadaID { get; set; }
        public int NacionalidadID { get; set; }
        public int TipoNovedadID { get; set; }
        public int ProvinciaID { get; set; }
        public DateTime FechaInicio { get; set; }
        public System.DateTime FechaTermino { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public System.TimeSpan HoraTermino { get; set; }
        public int AuditoriaID { get; set; }
        public int SexoID { get; set; }
        public int EstatusID { get; set; }
        public string Causa { get; set; }
        public int RangoID { get; set; }
        public int CompaniaID { get; set; }
        public int CausaHospitalizacionID { get; set; }
        public int AccidentesID { get; set; }
        public int EnfermedadesID { get; set; }
        public int DisgnosticoID { get; set; }
        public int HospitalID { get; set; }
        public System.DateTime FechaNovedad { get; set; }
        public System.TimeSpan HoraNovedad { get; set; }

        //public int RangoID { get; set; }

        //public int CompaniaID { get; set; }
    }
}
