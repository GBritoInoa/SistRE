using BeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace DataLogic
{
/// <summary>
/// Class Dalc TipoMedidas
/// </summary>
  public  class DalcTipoMedidas
    {

        public static string MachineName { get; }
        /// <summary>
        /// List Productos
        /// </summary>
        /// <returns></returns>
        public List<BeTipoMedidas> GetAll()
        {
            var data = new List<BeTipoMedidas>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.TipoMedidas
                                  join tp in db.TipoProducto
                                  on p.TipoProductoID equals tp.TipoProductoID
                                  join a in db.Auditoria on
                                  p.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on p.EstatusID equals e.EstatusID
                                  where p.EstatusID != 3
                                  select new BeTipoMedidas()

                                  {

                                      ID = p.TipoMedidaID,
                                      TipoMedidaID = p.TipoMedidaID,
                                      TipoProductoID = tp.TipoProductoID,
                                      Nombre = p.Nombre,
                                      NombreProducto = tp.Nombre,
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
        /// Medida Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoMedidas Find(int? id)
        {
            var data = new List<BeTipoMedidas>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.TipoMedidas
                                  join tp in db.TipoProducto
                                  on p.TipoProductoID equals tp.TipoProductoID
                                  join a in db.Auditoria
                                  on p.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on p.EstatusID equals e.EstatusID
                                  where p.TipoMedidaID == id
                                  select new BeTipoMedidas()

                                  {

                                      ID = p.TipoMedidaID,
                                      TipoProductoID = p.TipoProductoID,
                                      Nombre = p.Nombre,
                                      NombreProducto = tp.Nombre,
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
        /// Create Tipo Medida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoMedidas item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    ///Create Auditoria
                    var a = new Auditoria();
                    a.UsuarioCreo = "gbrito";
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create Tipo Medida
                    var tn = new TipoMedidas();
                    tn.Nombre = item.Nombre;
                    tn.TipoProductoID = item.TipoProductoID;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoMedidas.Add(tn);
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
        /// Edit Tipo Medida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoMedidas item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var p = new TipoMedidas();


                    //tn.UsuarioActualizo = "gbrito";
                    //tn.FechaActualizo = DateTime.Now;
                    p.TipoMedidaID = item.ID;
                    p.Nombre = item.Nombre;
                    p.TipoProductoID = item.TipoProductoID;
                    p.EstatusID = (int)item.EstatusID;
                    db.TipoMedidas.Attach(p);
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
