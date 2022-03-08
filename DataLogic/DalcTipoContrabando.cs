
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
    public class DalcTipoContrabando
    {
        public static string MachineName { get; }
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeTipoContrabando> GetAll()
        {
            var data = new List<BeTipoContrabando>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tc in db.TipoContrabando
                                  join tp in db.TipoProducto
                                  on tc.TipoProductoID equals tp.TipoProductoID
                                  join a in db.Auditoria on
                                  tc.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tc.EstatusID equals e.EstatusID
                                  where tc.EstatusID != 3
                                  select new BeTipoContrabando()

                                  {
                                      TipoProductoID = tc.TipoProductoID,
                                      ID = tc.TipoContrabandoID,
                                      Nombre = tp.Nombre,
                                      TipoNovedadID = tc.TipoNovedadID,
                                      //ProductoID = tc.ProductoID,                                       
                                      EstatusID = tc.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,

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
        public BeTipoContrabando Find(int? id)
        {
            var data = new List<BeTipoContrabando>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tc in db.TipoContrabando
                                  join a in db.Auditoria
                                  on tc.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tc.EstatusID equals e.EstatusID
                                  join tp in db.TipoProducto on tc.TipoProductoID equals tp.TipoProductoID
                                  where tc.TipoContrabandoID == id
                                  select new BeTipoContrabando()

                                  {

                                      ID = tc.TipoContrabandoID,
                                      AuditoriaID = a.AuditoriaID,
                                      Nombre = tp.Nombre,
                                      TipoProductoID = tc.TipoProductoID,
                                      EstatusID = tc.EstatusID,
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
        public bool Create(BeTipoContrabando item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    ///Create Auditoria
                    var a = new Auditoria();
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    a.UsuarioCreo = userName.Substring(0, 6);
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create Tipo Contrabando
                    var tc = new TipoContrabando();
                    tc.EstatusID = (int)item.EstatusID;
                    tc.TipoProductoID = item.TipoProductoID;
                    tc.TipoNovedadID = item.TipoNovedadID;
                    tc.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoContrabando.Add(tc);
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
        /// Edit Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoContrabando item)
        {

                using (var db = new Context_SistRE())
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {

                    try
                    {
                         var a = new Auditoria();
                         string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(0,6).ToLower();
                         a.AuditoriaID = item.AuditoriaID;
                         a.UsuarioActualizo = userName;
                         a.FechaActualizo = DateTime.Now;
                         db.Auditoria.Attach(a);
                         db.Entry(a).Property(x => x.UsuarioActualizo).IsModified = true;
                         db.Entry(a).Property(x => x.FechaActualizo).IsModified = true;
                         db.SaveChanges();

                        var tc = new TipoContrabando();

                        tc.TipoContrabandoID = item.ID;
                        tc.EstatusID = (int)item.EstatusID;
                        tc.TipoProductoID = item.TipoProductoID;
                        db.TipoContrabando.Attach(tc);
                        db.Entry(tc).Property(x => x.TipoProductoID).IsModified = true;
                        db.Entry(tc).Property(x => x.EstatusID).IsModified = true;
      
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
        /// Elimina Tipo Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
            public bool Delete(int? id)
        {
            try
            {
                using (var db = new Context_SistRE())
                {


                    var tn = db.TipoContrabando.Find(id);
                    if (tn != null)

                        db.TipoContrabando.Remove(tn);
                    db.SaveChanges();
                    return true;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}
