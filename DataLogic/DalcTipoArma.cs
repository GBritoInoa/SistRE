using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
    public class DalcTipoArma
    {

        /// <summary>
        /// Get All Tipo Arma
        /// </summary>
        /// <returns></returns>
        public List<BeTipoArma> GetAll()
        {
            var data = new List<BeTipoArma>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from ta in db.TipoArma
                                  join a in db.Auditoria
                                  on ta.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on ta.EstatusID equals e.EstatusID
                                  where ta.EstatusID != 3
                                  select new BeTipoArma()

                                  {

                                      ID = ta.TipoArmaID,
                                      Nombre = ta.Nombre,
                                      EstatusID = ta.EstatusID,
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
        ///  Find Tipo Arma Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoArma Find(int? id)
        {
            var data = new List<BeTipoArma>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from ta in db.TipoArma
                                  join a in db.Auditoria on
                                  ta.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on ta.EstatusID equals e.EstatusID
                                  select new BeTipoArma()

                                  {

                                      ID = ta.TipoArmaID,
                                      Nombre = ta.Nombre,
                                      EstatusID = ta.EstatusID,
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
        /// Create Tipo Arma
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoArma item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {

                    #region Begin Transacction
                    DateTime hora = DateTime.Now;
                    /////////Crea Registro Auditoria//////////
                    var a = new Auditoria();
                    a.UsuarioCreo = item.UserLogueado;
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();


                    var ta = new TipoArma();
                    ta.Nombre = item.Nombre;
                    ta.EstatusID = (int)item.EstatusID;
                    ta.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoArma.Add(ta);
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                    #endregion
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception(ex.Message);

                }

            }
        }

        /// <summary>
        ///Edit Institución Protesta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoArma item)
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

                    var p = new TipoArma();
                    p.TipoArmaID = item.ID;
                    p.AuditoriaID = item.AuditoriaID;
                    p.EstatusID = (int)item.EstatusID;
                    p.Nombre = item.Nombre;
                    db.TipoArma.Attach(p);
                    db.Entry(p).Property(x => x.Nombre).IsModified = true;
                    db.Entry(p).Property(x => x.EstatusID).IsModified = true;
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


