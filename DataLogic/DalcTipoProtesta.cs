
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{

    /// <summary>
    /// Dalc Tipo Novedad
    /// </summary>
    public class DalcTipoProtesta
    {
        public static string MachineName { get; }
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeTipoProtesta> GetAll()
        {
            var data = new List<BeTipoProtesta>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoProtesta
                                  join a in db.Auditoria on
                                  tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tn.EstatusID equals e.EstatusID
                                  where tn.EstatusID != 3
                                  select new BeTipoProtesta()

                                  {
                                      TipoProtestaID = tn.TipoProtestaID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo
                                  });

                };
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Tipo Novedad Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoProtesta Find(int? id)
        {
            var data = new List<BeTipoProtesta>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoProtesta
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.TipoProtestaID == id
                                  select new BeTipoProtesta()

                                  {

                                      TipoProtestaID = tn.TipoProtestaID,
                                      TipoNovedadID = tn.TipoNovedadID,
                                      AuditoriaID = tn.AuditoriaID,                                       
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo

                                  });

                };
                return data.FirstOrDefault();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        /// <summary>
        /// Create Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoProtesta item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    ///Create Auditoria
                    var a = new Auditoria();
                    string _User = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
                    a.UsuarioCreo = _User.Substring(0, 6);
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create Tipo Novedad
                    var tn = new TipoProtesta();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.TipoNovedadID = item.TipoNovedadID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoProtesta.Add(tn);
                    db.SaveChanges();
                    dbContextTransaction.Commit();
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
        /// Edit Tipo Novedad Protesta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoProtesta item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {
                    var a = new Auditoria();
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(0, 6).ToLower();
                    a.AuditoriaID = item.AuditoriaID;
                    a.UsuarioActualizo = userName;
                    a.FechaActualizo = DateTime.Now;
                    db.Auditoria.Attach(a);
                    db.Entry(a).Property(x => x.UsuarioActualizo).IsModified = true;
                    db.Entry(a).Property(x => x.FechaActualizo).IsModified = true;
                    db.SaveChanges();

                    var tp = new TipoProtesta();                  
                  
                    tp.AuditoriaID = item.AuditoriaID;
                    tp.TipoProtestaID = item.TipoProtestaID;
                    tp.Nombre = item.Nombre;
                    tp.EstatusID = (int)item.EstatusID;
                    db.TipoProtesta.Attach(tp);
                    db.Entry(tp).Property(x => x.Nombre).IsModified = true;
                       db.Entry(tp).Property(x => x.EstatusID).IsModified = true;

                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }

        }


        ///// <summary>
        ///// Elimina Tipo Novedad
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public bool Delete(int? id)
        //{
        //    try
        //    {
        //        using (var db = new Context_SistRE())
        //        {


        //            var tn = db.TipoProtesta.Find(id);
        //            if (tn != null)

        //                db.TipoProtesta.Remove(tn);
        //            db.SaveChanges();
        //            return true;

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);

        //    }
        //}
    }
}
