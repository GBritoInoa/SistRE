using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
    public class DalcNovedadMuerte
    {


        /// <summary>
        /// Reistro Novedad Muerte
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadMuertes item)
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
                    a.UsuarioCreo = item.UserLogueado.ToString();
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();


                    ////Create Novedad Muerte
                    var na = new NovedadMuertes();
                    na.NovedadMuerteID = item.NovedadMuerteID;
                    na.TipoMiembroID = item.TipoMiembroID;
                    na.TipoNovedadID = item.TipoNovedadID;
                    na.TipoMuerteID = item.TipoMuerteID;
                    na.EstatusID = (int)EnumEstatus.Estado.Activo;
                    na.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    na.FechaNovedad = item.FechaNovedad;
                    na.HoraNovedad = item.HoraNovedad;
                    na.ProvinciaID = item.ProvinciaID;
                    na.BrigadaID = item.BrigadaID;
                    na.RangoID = Convert.ToInt32(item.RangoID).Equals(0) ? 0 : item.RangoID;
                    na.CompaniaID = Convert.ToInt32(item.CompaniaID).Equals(0) ? 0 : item.CompaniaID;
                    na.SexoID = item.SexoID;
                    na.Causa = item.Causa;
                    db.NovedadMuertes.Add(na);
                    db.SaveChanges();

                    //////////Create HistoricoNovedades////////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = item.TipoNovedadID;
                    hn.ProvinciaID = item.ProvinciaID;
                    hn.AuditoriaID = Convert.ToInt32(na.AuditoriaID);
                    hn.FechaNovedad = item.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.TipoID = item.TipoMuerteID;
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
