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
    /// Dalc TipoPresentaciónMedicamento
    /// </summary>
   public class DalcTipoPresentacionMedicamento
    {
        public static string MachineName { get; }
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeTipoPresetacionMedicamento> GetAll()
        {
            var data = new List<BeTipoPresetacionMedicamento>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tpm in db.TipoPresentacionMedicamento
                                  join a in db.Auditoria on
                                  tpm.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tpm.EstatusID equals e.EstatusID
                                  where tpm.EstatusID != 3
                                  select new BeTipoPresetacionMedicamento()

                                  {
                                      ID = tpm.TipoPresentacionMedicamentoID,
                                      Nombre = tpm.Nombre,
                                      EstatusID = tpm.EstatusID,
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
        /// Tipo  Presentación Medicamento ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoPresetacionMedicamento Find(int? id)
        {
            var data = new List<BeTipoPresetacionMedicamento>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.TipoPresentacionMedicamento
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.TipoPresentacionMedicamentoID == id
                                  select new BeTipoPresetacionMedicamento()

                                  {

                                      ID = tn.TipoPresentacionMedicamentoID,
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
        /// Create Tipo Presentación Medicamento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoPresetacionMedicamento item)
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

                    ////Create Tipo Presentación Medicamento
                    var tn = new TipoPresentacionMedicamento();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.TipoPresentacionMedicamento.Add(tn);
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
        /// Edit Tipo Presentación Medicamento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoPresetacionMedicamento item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var tpn= new TipoPresentacionMedicamento();


                    //tn.UsuarioActualizo = "gbrito";
                    //tn.FechaActualizo = DateTime.Now;
                    tpn.Nombre = item.Nombre;
                    tpn.TipoPresentacionMedicamentoID = item.ID;
                    tpn.EstatusID = (int)item.EstatusID;
                    db.TipoPresentacionMedicamento.Attach(tpn);
                    db.Entry(tpn).Property(x => x.Nombre).IsModified = true;
                    db.Entry(tpn).Property(x => x.EstatusID).IsModified = true;
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
        /// Elimina Tipo Presentación Medicamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new Context_SistRE())
                {


                    var tpm = db.TipoPresentacionMedicamento.Find(id);
                    if (tpm != null)

                        db.TipoPresentacionMedicamento.Remove(tpm);
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

