using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public  class DalcAusencias
    {
            public static string MachineName { get; }
        /// <summary>
        /// Listado de Ausencia
        /// </summary>
        /// <returns></returns>
        public List<BeAusencias> GetAll()
            {
                var data = new List<BeAusencias>();

                try
                {
                    using (var db = new Context_SistRE())
                    {
                        data.AddRange(from au in db.Ausencias
                                      join a in db.Auditoria on
                                      au.AuditoriaID equals a.AuditoriaID
                                      join e in db.Estatus
                                      on au.EstatusID equals e.EstatusID
                                      where au.EstatusID != 3
                                      select new BeAusencias()

                                      {
                                          ID = au.AusenciaID,
                                          
                                          Nombre = au.Nombre,
                                          TipoNovedadID =  au.TipoNovedadID,
                                          EstatusID = au.EstatusID,
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
        /// Tipo Ausencia Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeAusencias Find(int? id)
            {
                var data = new List<BeAusencias>();

                try
                {
                    using (var db = new Context_SistRE())
                    {
                        data.AddRange(from au in db.Ausencias
                                      join a in db.Auditoria
                                      on au.AuditoriaID equals a.AuditoriaID
                                      join e in db.Estatus on au.EstatusID equals e.EstatusID
                                      where au.AusenciaID == id
                                      select new BeAusencias()

                                      {

                                          ID = au.AusenciaID,
                                          Nombre = au.Nombre,
                                          EstatusID = au.EstatusID,
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
            /// Create Ausencia
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public bool Create(BeAusencias item)
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

                        ////Create Ausencia
                        var au = new Ausencias();
                        au.Nombre = item.Nombre;
                        au.TipoNovedadID = item.TipoNovedadID;
                        au.EstatusID = (int)item.EstatusID;
                        au.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                        db.Ausencias.Add(au);
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
        /// Edit Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeAusencias item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {

                    ///Create Auditoria
                    var a = new Auditoria();
                    a.UsuarioActualizo = "gbrito";
                    a.FechaActualizo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ///Create Ausencia
                    var au = new Ausencias();
                    au.Nombre = item.Nombre;
                    au.AusenciaID = item.ID;
                    au.EstatusID = (int)item.EstatusID;
                    db.Ausencias.Attach(au);
                    db.Entry(au).Property(x => x.Nombre).IsModified = true;
                    db.Entry(au).Property(x => x.EstatusID).IsModified = true;
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception(ex.Message);
                }

            }
        }

            /// <summary>
            /// Elimina Tipo Ausencia
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public bool Delete(int? id)
            {
                try
                {
                    using (var db = new Context_SistRE())
                    {


                        var au = db.Ausencias.Find(id);
                        if (au != null)

                            db.Ausencias.Remove(au);
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

