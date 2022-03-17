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
    /// Class DalcTipoDocumento
    /// </summary>
   public class DalcTipoDocumento
    {
        /// <summary>
        /// Get All Tipo Documento
        /// </summary>
        /// <returns></returns>
        public List<BeTipoDocumento> GetTipoDocumento()
        {
            var data = new List<BeTipoDocumento>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoDocumento
                                  join a in db.Auditoria on
                                  tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tn.EstatusID equals e.EstatusID
                                  where tn.EstatusID != 3
                                  select new BeTipoDocumento()

                                  {
                                      ID = tn.TipoDocumentoID,
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
        /// Get Tipo Documento Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoDocumento Find(int? id)
        {
            var data = new List<BeTipoDocumento>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoDocumento
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.TipoDocumentoID == id
                                  select new BeTipoDocumento()

                                  {

                                      ID = tn.TipoDocumentoID,
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
        /// Create Tipo Documento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoDocumento item)
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

                    ////Create Tipo Documento
                    var tn = new TipoDocumento();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoDocumento.Add(tn);
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
        /// Edit Tipo Documento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoDocumento item)
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

                    var tc = new TipoDocumento();

                    tc.TipoDocumentoID = item.ID;
                    tc.AuditoriaID = item.AuditoriaID;
                    tc.EstatusID = (int)item.EstatusID;
                    tc.Nombre = item.Nombre;
                    db.TipoDocumento.Attach(tc);
                    db.Entry(tc).Property(x => x.Nombre).IsModified = true;
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
