
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
    public class DalcPais
    {
        public static string MachineName { get; }
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BePais> GetAll()
        {
            var data = new List<BePais>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.Pais
                                  join a in db.Auditoria
                                  on p.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on p.EstatusID equals e.EstatusID
                                  where p.EstatusID != 3
                                  select new BePais()

                                  {
                                      PaisID = p.PaisID,
                                      Nombre = p.Nombre,
                                      EstatusID = p.EstatusID,
                                      AuditoriaID = a.AuditoriaID,
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
        public BePais Find(int? id)
        {
            var data = new List<BePais>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.Pais
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.PaisID == id
                                  select new BePais()

                                  {

                                      PaisID = tn.PaisID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                      AuditoriaID= a.AuditoriaID

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
        public bool Create(BePais item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {

                    ///Create Auditoria
                    var a = new Auditoria();
                    a.UsuarioCreo = item.UserLogueado;
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create Tipo Novedad
                    var p = new Pais();
                    p.Nombre = item.Nombre;
                    p.EstatusID = (int)item.EstatusID;
                    p.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.Pais.Add(p);
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
        ///Edit Institución Protesta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BePais item)
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

                    var p = new Pais();
                    p.PaisID = item.PaisID;
                    p.AuditoriaID = item.AuditoriaID;
                    p.EstatusID = (int)item.EstatusID;
                    p.Nombre = item.Nombre;
                    db.Pais.Attach(p);
                    db.Entry(p).Property(x => x.Nombre).IsModified = true;
                    db.Entry(p).Property(x => x.EstatusID).IsModified = true;
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

    }
}
