﻿
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using BeEntity;

//namespace DataLogic
//{

//    /// <summary>
//    /// Dalc Tipo Novedad
//    /// </summary>
//    public class DalcTipoEntrega
//    {
//        public static string MachineName { get; }
//        /// <summary>
//        /// Listado de Novedades
//        /// </summary>
//        /// <returns></returns>
//        public List<BeTipoEntrega> GetAll()
//        {
//            var data = new List<BeTipoEntrega>();

//            try
//            {
//                using (var db = new Context_SistRE())
//                {
//                    data.AddRange(from tn in db.TipoEntrega
//                                  join a in db.Auditoria on
//                                  tn.AuditoriaID equals a.AuditoriaID
//                                  join e in db.Estatus
//                                  on tn.EstatusID equals e.EstatusID
//                                  where tn.EstatusID != 3
//                                  select new BeTipoEntrega()

//                                  {
//                                      TipoEntregaID = tn.TipoEntregaID,
//                                      Nombre = tn.Nombre,
//                                      EstatusID = tn.EstatusID,
//                                      UsuarioCreo = a.UsuarioCreo,
//                                      FechaCreo = a.FechaCreo,
//                                      UsuarioActualizo = a.UsuarioActualizo,
//                                      FechaActualizo = a.FechaActualizo
//                                  });

//                };
//                return data.ToList();
//            }
//            catch (Exception ex)
//            {

//                throw new Exception(ex.Message);
//            }

//        }

//        /// <summary>
//        /// Tipo Novedad Id
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public BeTipoEntrega Find(int? id)
//        {
//            var data = new List<BeTipoEntrega>();

//            try
//            {
//                using (var db = new Context_SistRE())
//                {
//                    data.AddRange(from tn in db.TipoEntrega
//                                  join a in db.Auditoria
//                                  on tn.AuditoriaID equals a.AuditoriaID
//                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
//                                  where tn.TipoEntregaID == id
//                                  select new BeTipoEntrega()

//                                  {

//                                      TipoEntregaID = tn.TipoEntregaID,
//                                      Nombre = tn.Nombre,
//                                      EstatusID = tn.EstatusID,
//                                      UsuarioCreo = a.UsuarioCreo,
//                                      FechaCreo = a.FechaCreo,
//                                      UsuarioActualizo = a.UsuarioActualizo,
//                                      FechaActualizo = a.FechaActualizo

//                                  });

//                };
//                return data.FirstOrDefault();
//            }

//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);

//            }

//        }

//        /// <summary>
//        /// Create Tipo Novedad
//        /// </summary>
//        /// <param name="item"></param>
//        /// <returns></returns>
//        public bool Create(BeTipoEntrega item)
//        {

//            using (var db = new Context_SistRE())
//            using (var dbContextTransaction = db.Database.BeginTransaction())
//            {
//                try
//                {
//                    ///Create Auditoria
//                    var a = new Auditoria();
//                    a.UsuarioCreo = "MJimenez";
//                    a.FechaCreo = DateTime.Now;
//                    a.NombrePC = Environment.MachineName;
//                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
//                    db.Auditoria.Add(a);
//                    db.SaveChanges();

//                    ////Create Tipo Novedad
//                    var tn = new TipoEntrega();
//                    tn.Nombre = item.Nombre;
//                    tn.EstatusID = (int)item.EstatusID;
//                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
//                    db.TipoEntrega.Add(tn);
//                    db.SaveChanges();
//                    dbContextTransaction.Commit();
//                    return true;
//                }
//                catch (Exception ex)
//                {
//                    dbContextTransaction.Rollback();
//                    throw new Exception(ex.Message);
//                }
//            }

//        }

//        /// <summary>
//        /// Edit Tipo Novedad
//        /// </summary>
//        /// <param name="item"></param>
//        /// <returns></returns>
//        public bool Edit(BeTipoEntrega item)
//        {

//            try
//            {
//                using (var db = new Context_SistRE())
//                {
//                    var tn = new TipoEntrega();


//                    //tn.UsuarioActualizo = "gbrito";
//                    //tn.FechaActualizo = DateTime.Now;
//                    tn.Nombre = item.Nombre;
//                    tn.TipoEntregaID = item.TipoEntregaID;
//                    tn.EstatusID = (int)item.EstatusID;
//                    db.TipoEntrega.Attach(tn);
//                    db.Entry(tn).Property(x => x.Nombre).IsModified = true;
//                    db.Entry(tn).Property(x => x.EstatusID).IsModified = true;
//                    //db.Entry(tn).Property(x => x.UsuarioActualizo).IsModified = true;
//                    //db.Entry(tn).Property(x => x.FechaActualizo).IsModified = true;
//                    db.SaveChanges();
//                    return true;

//                }

//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw new Exception(ex.Message);
//            }

//        }

//        /// <summary>
//        /// Elimina Tipo Novedad
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public bool Delete(int? id)
//        {
//            try
//            {
//                using (var db = new Context_SistRE())
//                {


//                    var tn = db.TipoEntrega.Find(id);
//                    if (tn != null)

//                        db.TipoEntrega.Remove(tn);
//                    db.SaveChanges();
//                    return true;

//                }

//            }
//            catch (Exception ex)
//            {

//                throw new Exception(ex.Message);

//            }
//        }
//    }
//}
