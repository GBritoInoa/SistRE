﻿
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
    /// Dalc Tipo Novedad
    /// </summary>
    public class DalcCategoriaProtesta
    {
        public static string MachineName { get; }
        /// <summary>
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeCategoriaProtesta> GetAll()
        {
            var data = new List<BeCategoriaProtesta>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.CategoriaProtesta
                                  join a in db.Auditoria on
                                  tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tn.EstatusID equals e.EstatusID
                                  where tn.EstatusID != 3
                                  select new BeCategoriaProtesta()

                                  {
                                      CategoriaProtestaID = tn.CategoriaProtestaID,
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
        /// Tipo Novedad Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeCategoriaProtesta Find(int? id)
        {
            var data = new List<BeCategoriaProtesta>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.CategoriaProtesta
                                  join a in db.Auditoria
                                  on tn.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                  where tn.CategoriaProtestaID == id
                                  select new BeCategoriaProtesta()

                                  {

                                      CategoriaProtestaID = tn.CategoriaProtestaID,
                                      AuditoriaID = tn.AuditoriaID,
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
        /// Create Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeCategoriaProtesta item)
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

                    ////Create Tipo Novedad
                    var tn = new CategoriaProtesta();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    tn.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.CategoriaProtesta.Add(tn);
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
        ///Edit Categoria Protesta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeCategoriaProtesta item)
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

                    var ti = new CategoriaProtesta();              
                    ti.CategoriaProtestaID = item.CategoriaProtestaID;
                    ti.AuditoriaID = item.AuditoriaID;
                    ti.EstatusID = (int)item.EstatusID;
                    ti.Nombre = item.Nombre;
                    db.CategoriaProtesta.Attach(ti);
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

        /// <summary>
        /// Elimina Tipo Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new Context_SistRE())
                {


                    var tn = db.CategoriaProtesta.Find(id);
                    if (tn != null)

                        db.CategoriaProtesta.Remove(tn);
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
