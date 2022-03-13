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
                                  join  tp in db.TipoProducto
                                  on p.TipoProductoID equals tp.TipoProductoID
                                  join a in db.Auditoria on
                                  p.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on p.EstatusID equals e.EstatusID
                                  where p.EstatusID != 3                                
                                  select new BeProductos()

                                  {

                                      ID= p.ProductoID,
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
        /// Edit Producto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeProductos item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var p = new Productos();


                    //tn.UsuarioActualizo = "gbrito";
                    //tn.FechaActualizo = DateTime.Now;
                    p.ProductoID = item.ID;
                    p.Nombre = item.Nombre;
                    p.TipoProductoID = item.TipoProductoID;
                    p.EstatusID = (int)item.EstatusID;
                    db.Productos.Attach(p);
                    db.Entry(p).Property(x => x.Nombre).IsModified = true;
                    db.Entry(p).Property(x => x.EstatusID).IsModified = true;
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

        /// <summary>
        /// Elimina Producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new Context_SistRE())
                {


                    var p = db.Productos.Find(id);
                    if (p != null)

                        db.Productos.Remove(p);
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
