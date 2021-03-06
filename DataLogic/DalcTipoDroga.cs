
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
    /// Dalc Tipo Droga
    /// </summary>
    public class DalcTipoDroga
    {
        public static string MachineName { get; }
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeTipoDroga> GetAll()
        {
            var data = new List<BeTipoDroga>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoDroga
                                  join a in db.Auditoria on
                                  tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tn.EstatusID equals e.EstatusID
                                  where tn.EstatusID != 3
                                  select new BeTipoDroga()

                                  {
                                      TipoDrogaID = tn.TipoDrogaID,
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
        /// Tipo Droga Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoDroga Find(int? id)
        {
            var data = new List<BeTipoDroga>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoDroga
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.TipoDrogaID == id
                                  select new BeTipoDroga()

                                  {

                                      TipoDrogaID = tn.TipoDrogaID,
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
        /// Create Tipo Droga
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoDroga item)
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

                    ////Create Tipo Droga
                    var tn = new TipoDroga();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoDroga.Add(tn);
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
        /// Edit Tipo Droga
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoDroga item)
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

                    var ti = new TipoDroga();
               
                    ti.TipoDrogaID = item.TipoDrogaID;
                    ti.AuditoriaID = item.AuditoriaID;
                    ti.Nombre = item.Nombre;
                    ti.EstatusID = (int)item.EstatusID;
                    db.TipoDroga.Attach(ti);
                    db.Entry(ti).Property(x => x.Nombre).IsModified = true;
                    db.Entry(ti).Property(x => x.EstatusID).IsModified = true;

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
