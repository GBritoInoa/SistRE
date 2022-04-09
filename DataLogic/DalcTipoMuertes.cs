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
    public class DalcTipoMuertes
    {
        public static string MachineName { get; }
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeTipoMuertes> GetAll()
        {
            var data = new List<BeTipoMuertes>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoMuertes
                                  join a in db.Auditoria on
                                  tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tn.EstatusID equals e.EstatusID
                                  where tn.EstatusID != 3
                                  select new BeTipoMuertes()

                                  {
                                      TipoMuerteID = tn.TipoMuerteID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                      AuditoriaID = a.AuditoriaID
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
        public BeTipoMuertes Find(int? id)
        {
            var data = new List<BeTipoMuertes>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoMuertes
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.TipoMuerteID == id
                                  select new BeTipoMuertes()

                                  {

                                      TipoMuerteID = tn.TipoMuerteID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                      AuditoriaID = a.AuditoriaID
                                      

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
        public bool Create(BeTipoMuertes item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    ///Create Auditoria
                    var a = new Auditoria();
                    a.UsuarioCreo = item.UserLogueado.ToString();
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create Tipo Novedad
                    var tn = new TipoMuertes();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoMuertes.Add(tn);
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
        /// Edit Tipo Defunción
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoMuertes item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {
                    var a = new Auditoria();

                    a.AuditoriaID = item.AuditoriaID;
                    a.UsuarioActualizo = item.UserLogueado;
                    a.FechaActualizo = DateTime.Now;
                    db.Auditoria.Attach(a);
                    db.Entry(a).Property(x => x.UsuarioActualizo).IsModified = true;
                    db.Entry(a).Property(x => x.FechaActualizo).IsModified = true;
                    db.SaveChanges();

                    var tp = new TipoMuertes();

                    tp.AuditoriaID = item.AuditoriaID;
                    tp.TipoMuerteID = item.TipoMuerteID;
                    tp.Nombre = item.Nombre;
                    tp.EstatusID = (int)item.EstatusID;
                    db.TipoMuertes.Attach(tp);
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


        //            var tn = db.TipoMuertes.Find(id);
        //            if (tn != null)

        //                db.TipoMuertes.Remove(tn);
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
