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
                    a.UsuarioCreo = "gbrito";
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
        /// Edit Tipo Arma
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoArma item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var ta = new TipoArma();


                    //tn.UsuarioActualizo = "gbrito";
                    //tn.FechaActualizo = DateTime.Now;
                    ta.Nombre = item.Nombre;
                    ta.TipoArmaID = item.ID;
                    ta.EstatusID = (int)item.EstatusID;
                    db.TipoArma.Attach(ta);
                    db.Entry(ta).Property(x => x.Nombre).IsModified = true;
                    db.Entry(ta).Property(x => x.EstatusID).IsModified = true;
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
        /// Delete Tipo Arma
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new Context_SistRE())
                {


                    var ta = db.TipoArma.Find(id);
                    if (ta != null)

                        db.TipoArma.Remove(ta);
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


