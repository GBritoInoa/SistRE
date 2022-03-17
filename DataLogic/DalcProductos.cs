using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
    /// <summary>
    /// Dalc Productos
    /// </summary>
    public class DalcProductos
    {

        public static string MachineName { get; }
        /// <summary>
        /// List Productos
        /// </summary>
        /// <returns></returns>
        public List<BeProductos> GetAll()
        {
            var data = new List<BeProductos>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.Productos
                                  join tp in db.TipoProducto
                                  on p.TipoProductoID equals tp.TipoProductoID
                                  join a in db.Auditoria on
                                  p.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on p.EstatusID equals e.EstatusID
                                  where p.EstatusID != 3
                                  select new BeProductos()

                                  {

                                      ID = p.ProductoID,
                                      TipoProductoID = tp.TipoProductoID,
                                      Producto = tp.Nombre,
                                      Nombre = p.Nombre,
                                      EstatusID = p.EstatusID,
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
        /// Producto Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeProductos Find(int? id)
        {
            var data = new List<BeProductos>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.Productos
                                  join tp in db.TipoProducto
                                  on p.TipoProductoID equals tp.TipoProductoID
                                  join a in db.Auditoria
                                  on p.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on p.EstatusID equals e.EstatusID
                                  where p.ProductoID == id
                                  select new BeProductos()

                                  {

                                      ID = p.ProductoID,
                                      TipoProductoID = p.TipoProductoID,
                                      Producto = tp.Nombre,
                                      Nombre = p.Nombre,
                                      EstatusID = p.EstatusID,
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
        /// Create Producto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeProductos item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    ///Create Auditoria
                    var a = new Auditoria();
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(0, 6).ToLower();
                    a.UsuarioCreo = userName;
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create Producto
                    var tn = new Productos();
                    tn.Nombre = item.Nombre;
                    tn.TipoProductoID = item.TipoProductoID;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.Productos.Add(tn);
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
        /// Edit  Producto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeProductos item)
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

                    var tp = new Productos();

                    tp.AuditoriaID = item.AuditoriaID;
                    tp.ProductoID = item.ID;
                    tp.Nombre = item.Nombre;
                    tp.EstatusID = (int)item.EstatusID;
                    tp.TipoProductoID = item.TipoProductoID;
                    db.Productos.Attach(tp);
                    db.Entry(tp).Property(x => x.TipoProductoID).IsModified = true;
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


    }
}
