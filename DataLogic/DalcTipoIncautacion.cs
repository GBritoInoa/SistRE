using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcTipoIncautacion
    {

        /// <summary>
        /// List Tipo Incautación
        /// </summary>
        /// <returns></returns>
        public List<BeTipoIncautacion> GetAll()
        {
            var data = new List<BeTipoIncautacion>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from ti in db.TipoIncautacion
                                  join tp in db.TipoProducto
                                  on ti.TipoProductoID equals tp.TipoProductoID
                                  join a in db.Auditoria on
                                  ti.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on ti.EstatusID equals e.EstatusID
                                  where ti.EstatusID != 3
                                  select new BeTipoIncautacion()

                                  {
                                      ID = ti.TipoIncautacionID,
                                      Nombre= tp.Nombre,
                                      TipoNovedadID = ti.TipoNovedadID,
                                      EstatusID = ti.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                      TipoProductoID = tp.TipoProductoID
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
        public BeTipoIncautacion Find(int? id)
        {
            var data = new List<BeTipoIncautacion>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoIncautacion
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.TipoIncautacionID == id
                                  select new BeTipoIncautacion()

                                  {

                                      ID = tn.TipoIncautacionID,
                                      TipoNovedadID = tn.TipoNovedadID,
                                      EstatusID = tn.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                      TipoProductoID = tn.TipoProductoID
                                     

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
        public bool Create(BeTipoIncautacion item)
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

                    ////Create Tipo Incautación
                    var ti = new TipoIncautacion();
                    ti.TipoNovedadID = item.TipoNovedadID;
                    ti.TipoProductoID = item.TipoProductoID;
                    ti.EstatusID = (int)item.EstatusID;
                    ti.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoIncautacion.Add(ti);
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return false;
                    throw new Exception(ex.Message);

                }

            }
        }

        /// <summary>
        /// Edit Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoIncautacion item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var ti = new TipoIncautacion();



                    ti.TipoProductoID = item.TipoProductoID;
                    ti.TipoIncautacionID = item.ID;
                    ti.EstatusID = (int)item.EstatusID;
                    db.TipoIncautacion.Attach(ti);
                    db.Entry(ti).Property(x => x.TipoProductoID).IsModified = true;
                    db.Entry(ti).Property(x => x.EstatusID).IsModified = true;

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

        ///// <summary>
        ///// Elimina Tipo Novedad
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public bool Delete(int? id)
        //{
        //    try
        //    {
        //        using (var db = new ContextDB_SistRE())
        //        {


        //            var tn = db.TipoIncautacion.Find(id);
        //            if (tn != null)

        //                db.TipoIncautacion.Remove(tn);
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
