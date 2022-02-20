using BeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DalcTipoApresamiento
    {

        
            public static string MachineName { get; }
            /// <summary>
            /// Dalc Tipo Apresamientos
            /// </summary>
            /// <returns></returns>
            public List<BeTipoApresamiento> GetAll()
            {
                var data = new List<BeTipoApresamiento>();

                try
                {
                    using (var db = new Context_SistRE())
                    {
                        data.AddRange(from tn in db.TipoApresamiento
                                      join a in db.Auditoria on
                                      tn.AuditoriaID equals a.AuditoriaID
                                      join e in db.Estatus
                                      on tn.EstatusID equals e.EstatusID
                                      where tn.EstatusID != 3
                                      select new BeTipoApresamiento()

                                      {
                                          ID = tn.TipoApresamientoID,
                                          TipoNovedadID = tn.TipoNovedadID,
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
            /// Tipo Apresamiento Id
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public BeTipoApresamiento Find(int? id)
            {
                var data = new List<BeTipoApresamiento>();

                try
                {
                    using (var db = new Context_SistRE())
                    {
                        data.AddRange(from tn in db.TipoApresamiento
                                      join a in db.Auditoria
                                      on tn.AuditoriaID equals a.AuditoriaID
                                      join e in db.Estatus on tn.EstatusID equals e.EstatusID
                                      where tn.TipoApresamientoID == id
                                      select new BeTipoApresamiento()

                                      {

                                          ID = tn.TipoApresamientoID,
                                          TipoNovedadID = tn.TipoNovedadID,
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
            /// Create Tipo Apresamiento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public bool Create(BeTipoApresamiento item)
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
                        var ta= new TipoApresamiento();
                        ta.Nombre = item.Nombre;
                        ta.TipoNovedadID = item.TipoNovedadID;
                        ta.EstatusID = (int)item.EstatusID;
                        ta.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                        db.TipoApresamiento.Add(ta);
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
            /// Edit Tipo Apresamiento
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public bool Edit(BeTipoApresamiento item)
            {

                try
                {
                    using (var db = new Context_SistRE())
                    {
                        var ta = new TipoApresamiento();


                        //tn.UsuarioActualizo = "gbrito";
                        //tn.FechaActualizo = DateTime.Now;
                        ta.Nombre = item.Nombre;
                        ta.TipoApresamientoID = item.ID;
                        ta.EstatusID = (int)item.EstatusID;
                        db.TipoApresamiento.Attach(ta);
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


                        var ta = db.TipoApresamiento.Find(id);
                        if (ta != null)

                        db.TipoApresamiento.Remove(ta);
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

