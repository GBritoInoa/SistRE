using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
    public class DalcNovedadProtesta
    {


        /// <summary>
        /// Reistro Novedad Protesta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadProtesta item)
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
                    string _User = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
                    a.UsuarioCreo = _User.Substring(0, 6);
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create Novedad Protesta
                    var na = new NovedadProtesta();
                    na.TipoProtestaID = item.TipoProtestaID;
                    na.TipoNovedadID = item.TipoNovedadID;
                    na.ProvinciaID = item.ProvinciaID;
                    na.FechaNovedad = item.FechaNovedad;
                    na.EstatusID = (int)EnumEstatus.Estado.Activo;
                    na.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    na.HoraNovedad = item.HoraNovedad;
                    na.LugarProtesta = item.LugarProtesta;
                    na.InstitucionProtestanteID = item.InstitucionProtestanteID;
                    na.CategoriaProtestaID = item.CategoriaProtestaID;
                    na.Causa = item.Causa;
                    na.EstatusID = (int)EnumEstatus.Estado.Activo;
                    na.Causa = item.Causa;
                    db.NovedadProtesta.Add(na);
                    db.SaveChanges();

                    //////////Create HistoricoNovedades////////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = Convert.ToInt32(na.TipoNovedadID);
                    hn.AuditoriaID = Convert.ToInt32(na.AuditoriaID);
                    hn.FechaNovedad = item.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.TipoID = item.TipoProtestaID;
                    hn.ProvinciaID = item.ProvinciaID;
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
