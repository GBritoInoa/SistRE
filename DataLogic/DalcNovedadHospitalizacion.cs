using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
    public class DalcNovedadHospitalizacion
    {


        /// <summary>
        /// Reistro Novedad Hospitalizacion
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadHospitalizacion item)
        {
            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    #region Begin Transacction
                    DateTime hora = DateTime.Now;
                    /////////Crea Registro Auditoria//////////
                    var a = new Auditoria();

                    a.UsuarioCreo = item.UserLogueado;
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();


                    ////Create Novedad Hospitalizacion
                    var na = new NovedadHospitalizacion();
                    na.NovedadHospitalizacionID = item.NovedadHospitalizacionID;
                    na.TipoNovedadID = item.TipoNovedadID;
                    na.HospitalID = item.HospitalID;
                    na.EnfermedadesID = item.EnfermedadID;
                    na.EstatusID = (int)EnumEstatus.Estado.Activo;
                    na.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    na.FechaNovedad = item.FechaNovedad;
                    na.HoraNovedad = item.HoraNovedad;
                    na.ProvinciaID = item.ProvinciaID;
                    na.BrigadaID = item.BrigadaID;
                    na.RangoID = Convert.ToInt32(item.RangoID).Equals(0) ? 0 : item.RangoID;
                    na.CompaniaID = Convert.ToInt32(item.CompaniaID).Equals(0) ? 0 : item.CompaniaID;
                    na.SexoID = item.SexoID;
                    na.EstatusID = (int)EnumEstatus.Estado.Activo;
                    db.NovedadHospitalizacion.Add(na);
                    na.Causa = item.Causa;
                    db.SaveChanges();

                    //////////Create HistoricoNovedades////////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = Convert.ToInt32(na.TipoNovedadID);
                    hn.AuditoriaID = Convert.ToInt32(na.AuditoriaID);
                    hn.FechaNovedad = item.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.TipoID = item.NovedadHospitalizacionID;
                    db.HistoricoNovedades.Add(hn);
                    db.SaveChanges();
                    dbContextTransaction.Commit();

                    return true;
                    #endregion
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception(ex.Message);
                }


            }

        }
    }
}
