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

                                  select new BeTipoDecomiso()
                                  {

                                      ID = d.TipoDecomisoID,
                                     TipoNovedadID = d.TipoNovedadID,
                                     TipoProductoID = d.TipoProductoID,
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
                {
                    data.AddRange(from d in db.TipoDecomiso
                                  join a in db.Auditoria on
                                  d.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on
                                  d.EstatusID equals e.EstatusID
                                  where d.TipoDecomisoID == id

                                  select new BeTipoDecomiso()
                                  {
                                      ID = d.TipoDecomisoID,
                                    TipoProductoID = d.TipoProductoID,
                                    TipoNovedadID = d.TipoNovedadID,
                                      EstatusID = d.EstatusID,
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
                      var _User = 
                        a.FechaCreo = DateTime.Now;
                        a.NombrePC = Environment.MachineName;
                        a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                        db.Auditoria.Add(a);
                        db.SaveChanges();

                        ////Create Tipo Novedad
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
            try
            {
                using (var db= new Context_SistRE())
                {

                    var td = new TipoDecomiso();
                    {
                        //tn.UsuarioActualizo = "gbrito";
                        //tn.FechaActualizo = DateTime.Now;
                        td.TipoProductoID = item.TipoProductoID;
                        td.TipoNovedadID = item.TipoNovedadID;
                        td.TipoDecomisoID = item.ID;
                        td.EstatusID = (int)item.EstatusID;
                        db.TipoDecomiso.Attach(td);
                        //db.Entry(td).Property(x => x.Nombre).IsModified = true;
                        db.Entry(td).Property(x => x.EstatusID).IsModified = true;
                        //db.Entry(tn).Property(x => x.UsuarioActualizo).IsModified = true;
                        //db.Entry(tn).Property(x => x.FechaActualizo).IsModified = true;
                        db.SaveChanges();
                        return true;

                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    } 
    
}
