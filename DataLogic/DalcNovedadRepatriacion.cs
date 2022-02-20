using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcNovedadRepatriacion
    {

        /// <summary>
        /// Reistro Novedad Repatriación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadRepatriacion item)
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
                    a.UsuarioCreo = "gbrito";
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();


                    ////Create Novedad Repatriación
                    var na = new NovedadRepatriaciones();
                    na.NovedadRepatriacionID = item.RepatriacionID;
                    na.TipoNovedadID = 19;
                    na.Cantidad = item.Cantidad;
                    na.PaisID = item.PaisID;
                    na.EstatusID = (int)EnumEstatus.Estado.Activo;
                    na.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    na.FechaNovedad = item.FechaNovedad;
                    na.HoraNovedad = item.HoraNovedad;
                    na.ProvinciaID = item.ProvinciaID;
                    na.BrigadaID = item.BrigadaID;
                    na.SexoID = item.SexoID;
                    na.CausaID = item.CausaID;            
                    na.Causa = item.Causa;
                    db.NovedadRepatriaciones.Add(na);
                    db.SaveChanges();

                    //////////Create Histórico Novedades////////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = na.TipoNovedadID;
                    hn.AuditoriaID = na.AuditoriaID;
                    hn.FechaNovedad = item.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.TipoID = item.CausaID;
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
