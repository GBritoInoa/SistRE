using BeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
   public class DalcNovedadDecomiso
    {

        /// <summary>
        /// Dalc NovedadDecomiso
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadDecomiso item)
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

                    /////////Create Novedad Decomiso//////////
                    var nd = new NovedadDecomiso();
                    nd.NovedadDecomisoID = item.NovedadDecomisoID;
                    nd.TipoDecomisoID = item.TipoDecomisoID;
                    nd.Cantidad = item.Cantidad;
                    nd.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    nd.FechaNovedad = item.FechaNovedad;
                    nd.BrigadaID = item.BrigadaID;
                    nd.HoraNovedad = item.HoraNovedad;
                    nd.TipoNovedadID = item.TipoNovedadID;
                    nd.TipoMedidaID = item.TipoMedidaID;
                    nd.ProvinciaID = Convert.ToInt32(item.ProvinciaID).Equals(0) ? 0 : item.ProvinciaID;
                    nd.Causa = item.Causa;
                    nd.EstatusID = (int)EnumEstatus.Estado.Activo;
                    nd.TipoID = item.TipoDecomisoID;
                    db.NovedadDecomiso.Add(nd);
                    db.SaveChanges();

                    //////////Create HistoricoNovedades///////////////
                    var hn = new HistoricoNovedades(); 
                    hn.TipoNovedadID = nd.TipoNovedadID;
                    hn.AuditoriaID = nd.AuditoriaID;
                    hn.FechaNovedad = item.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.ProvinciaID = Convert.ToInt32(item.ProvinciaID).Equals(0) ? 0 : item.ProvinciaID;
                    hn.TipoID = item.TipoDecomisoID;
                    db.HistoricoNovedades.Add(hn);
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    #endregion 
                    return true;
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
