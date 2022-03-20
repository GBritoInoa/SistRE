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
  public  class DalcNacionalidad
    {


        /// <summary>
        /// List Nacionalidad
        /// </summary>
        /// <returns></returns>
        public List<BeNacionalidad> GetAll()
        {
            var data = new List<BeNacionalidad>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from n in db.Nacionalidad
                                  join a in db.Auditoria on
                                  n.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on n.EstatusID equals e.EstatusID
                                  where n.EstatusID != 3
                                  select new BeNacionalidad()

                                  {
                                      ID = n.NacionalidadID,
                                      Nombre = n.Nombre,
                                      EstatusID = n.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,
                                      AuditoriaID = a.AuditoriaID
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
        /// Nacionalidad Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeNacionalidad Find(int? id)
        {
            var data = new List<BeNacionalidad>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from n in db.Nacionalidad
                                  join a in db.Auditoria
                                  on n.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on n.EstatusID equals e.EstatusID
                                  where n.NacionalidadID == id
                                  select new BeNacionalidad()

                                  {

                                      ID = n.NacionalidadID,
                                      Nombre = n.Nombre,
                                      EstatusID = n.EstatusID,
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
        /// Create Nacionalidad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNacionalidad item)
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

                    ////Create Nacionalidad
                    var n = new Nacionalidad();
                    n.Nombre = item.Nombre;
                    n.EstatusID = (int)item.EstatusID;
                    n.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.Nacionalidad.Add(n);
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
        /// Edit Nacionalidad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeNacionalidad item)
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

                    var n = new Nacionalidad();


                    n.Nombre = item.Nombre;
                    n.AuditoriaID = item.AuditoriaID;
                    n.NacionalidadID = item.ID;
                    n.EstatusID = (int)item.EstatusID;
                    db.Nacionalidad.Attach(n);
                    db.Entry(n).Property(x => x.Nombre).IsModified = true;
                    db.Entry(n).Property(x => x.EstatusID).IsModified = true;

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
