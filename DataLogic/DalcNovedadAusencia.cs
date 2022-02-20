using System;
using System.Linq;
using System.Net;
using BeEntity;


namespace DataLogic
{
    public  class DalcNovedadAusencia
    {
        /// <summary>
        /// Create Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadAusencia item)
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

                 /////////Create Novedad Ausencia//////////
                    var na = new NovedadAusencia();
                    na.AusenciaID = item.AusenciaID;
                    na.RangoID = item.RangoID;
                    na.CompaniaID = item.CompaniaID;
                    na.FechaNovedad = item.FechaNovedad;
                    na.HoraNovedad = item.HoraNovedad;
                    na.Causa = item.Causa;
                    na.TipoNovedadID = 1036;
                    na.EstatusID = (int)EnumEstatus.Estado.Activo;
                    na.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.NovedadAusencia.Add(na);
                    db.SaveChanges();

                 //////////Create HistoricoNovedades////////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = na.TipoNovedadID;
                    hn.AuditoriaID = na.AuditoriaID;
                    hn.FechaNovedad = item.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.TipoID = item.AusenciaID;
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
