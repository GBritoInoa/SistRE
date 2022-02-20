using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
    public class DalcNovedadPerdidaDocumento
    {
        /// <summary>
        /// Create Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadPerdidaDocumento item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    #region Begin Transacction
          
                    /////////Crea Registro Auditoría//////////
                    var a = new Auditoria();
                    a.UsuarioCreo = "gbrito";
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    /////////Create Novedad Périda Incautación//////////
                    var npd = new NovedadPerdidaDocumento();
                    npd.NovedadPerdidaDocumentoID = item.ID;
                    npd.TipoDocumentoID = item.TipoDocumentoID;
                    npd.RangoID = item.RangoID;
                    npd.CompaniaID = item.CompaniaID;
                    npd.ProvinciaID = item.ProvinciaID;
                    npd.FechaNovedad = item.FechaNovedad;
                    npd.HoraNovedad = (item.HoraNovedad);
                    npd.Causa = item.Causa;
                    npd.TipoNovedadID = 25;
                    npd.EstatusID = 1;
                    npd.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.NovedadPerdidaDocumento.Add(npd);
                    db.SaveChanges();

                    ///////Create Histórico Novedades///////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = npd.TipoNovedadID;
                    hn.AuditoriaID = npd.AuditoriaID;
                    hn.FechaNovedad = npd.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.ProvinciaID = item.ProvinciaID;
                    hn.TipoID = item.TipoDocumentoID;
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

        /// <summary>
        /// Edit Novedad Ausencia
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeNovedadAusencia item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var na = new NovedadAusencia();


                    //tn.UsuarioActualizo = "gbrito";
                    //tn.FechaActualizo = DateTime.Now;
                    //na.Nombre = item.Nombre;
                    //na.TipoNovedadID = item.ID;
                    //na.EstatusID = (int)item.EstatusID;
                    //db.TipoNovedad.Attach(na);
                    //db.Entry(na).Property(x => x.Nombre).IsModified = true;
                    //db.Entry(na).Property(x => x.EstatusID).IsModified = true;
                    //db.Entry(tn).Property(x => x.UsuarioActualizo).IsModified = true;
                    //db.Entry(tn).Property(x => x.FechaActualizo).IsModified = true;
                    db.SaveChanges();
                    return true;

                }

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }

        }
    }
}
