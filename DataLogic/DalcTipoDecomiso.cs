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
    /// Dalc Tipo Decomiso
    /// </summary>
    public class DalcTipoDecomiso
    {

        /// <summary>
        /// List GetAll Tipo Decomiso
        /// </summary>
        /// <returns></returns>
        public List<BeTipoDecomiso> GetTipoDecomisos()
        {
            var data = new List<BeTipoDecomiso>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from d in db.TipoDecomiso
                                  join a in db.Auditoria on
                                  d.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on d.EstatusID equals e.EstatusID
                                  join tp in db.TipoProducto 
                                  on d.TipoProductoID equals tp.TipoProductoID

                                  select new BeTipoDecomiso()
                                  {

                                      ID = d.TipoDecomisoID,
                                      
                                     TipoNovedadID = d.TipoNovedadID,
                                      Nombre = tp.Nombre,
                                     TipoProductoID = tp.TipoProductoID,
                                      EstatusID = d.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                      AuditoriaID = d.AuditoriaID



                                  });
                    return data.ToList();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Find Tipo Decomiso ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoDecomiso Find(int? id)
        {

            var data = new List<BeTipoDecomiso>();

            try
            {
                using (var db = new Context_SistRE())
                using (var dbERD = new ContextDbERD())
                {
                    data.AddRange(from d in db.TipoDecomiso
                                  join a in db.Auditoria on
                                  d.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on
                                  d.EstatusID equals e.EstatusID
                                  join tp in db.TipoProducto
                                  on d.TipoProductoID equals tp.TipoProductoID
                             
                                  where d.TipoDecomisoID == id

                                  select new BeTipoDecomiso()
                                  {
                                      AuditoriaID = d.AuditoriaID,
                                      ID = d.TipoDecomisoID,
                                      TipoProductoID = d.TipoProductoID,
                                      Nombre = tp.Nombre,
                                      TipoNovedadID = d.TipoNovedadID,
                                      EstatusID = d.EstatusID, 
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                 

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
        /// Create Tipo Decomiso
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoDecomiso item)
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

                        ////Create Tipo Decomiso
                        var tn = new TipoDecomiso();
                        tn.TipoNovedadID = item.TipoNovedadID;
                        tn.TipoProductoID = item.TipoProductoID;
                        tn.EstatusID = (int)item.EstatusID;
                        tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                        db.TipoDecomiso.Add(tn);
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
        /// Edit Tipo Decomiso
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoDecomiso item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {
                    var a = new Auditoria();
                  
                    a.AuditoriaID = item.AuditoriaID;
                    a.UsuarioActualizo =item.UserLogueado;
                    a.FechaActualizo = DateTime.Now;
                    db.Auditoria.Attach(a);
                    db.Entry(a).Property(x => x.UsuarioActualizo).IsModified = true;
                    db.Entry(a).Property(x => x.FechaActualizo).IsModified = true;
                    db.SaveChanges();

                    var tc = new TipoDecomiso();

                    tc.TipoDecomisoID = item.ID;
                    tc.AuditoriaID = item.AuditoriaID;
                    tc.EstatusID = (int)item.EstatusID;
                    tc.TipoProductoID = item.TipoProductoID;
                    db.TipoDecomiso.Attach(tc);
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



    }

}
