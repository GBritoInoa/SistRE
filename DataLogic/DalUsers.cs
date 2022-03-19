
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
    /// Dalc Users
    /// </summary>
    public class DalcUser
    {
        public static string MachineName { get; }



        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<BeUser> GetIncluding(Func<Users, bool> filter)
        {
            var data = new List<BeUser>();

            try
            {
                using (var db = new Context_SistRE())
                using (var dbERD = new ContextDbERD())
              
                {
                    data.AddRange(from u in db.Users.Where(filter)
                                      //join a in db.Auditoria on
                                      //tn.AuditoriaID equals a.AuditoriaID
                                      //join e in db.Estatus
                                      //on tn.EstatusID equals e.EstatusID
                                  join p in db.Perfil on u.PerfilID equals p.PerfilID
                                  join e in db.Estatus on u.EstatusID equals e.EstatusID
                                  join i in dbERD.Instituciones on u.InstitucionID equals i.InstitucionID
                                  join b in dbERD.Unidades on u.BrigadaID equals b.UnidadID
                                  join r in dbERD.Rangos on u.RangoID  equals r.RangoID
                                  
                                  where u.EstatusID != 3
                                  select new BeUser()

                                  {
                                      UserId = u.UserId,
                                      ID = u.UserId,
                                      Nombre = u.Nombre,
                                      UserName = u.UserName,
                                      NombreCompleto = u.Apellidos + "," + u.Nombre,
                                      Institucion = i.nombre,
                                      InstitucionID = u.InstitucionID,
                                      BrigadaID = u.BrigadaID,
                                      Rango = r.nombre,
                                      RangoID = r.RangoID,                                 
                                      Brigada = b.nombre,
                                      Apellidos = u.Apellidos,
                                      PerfilID = u.PerfilID,
                                      Perfil = p.Nombre,
                                      Salt = u.Salt,
                                      Password = u.Password,
                                      CambioClave = u.CambioClave,
                                      Email = u.Email,
                                      EstatusID = u.EstatusID
                                      
                                   
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
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeUser> GetAll()
        {
            return this.GetIncluding(u => true);
        }
        public BeUser Get(string UserName)
        {
            return this.GetIncluding(u => u.UserName == UserName).FirstOrDefault();
        }

        ///// <summary>
        ///// Tipo Novedad Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public BeTipoContrabando Find(int? id)
        //{
        //    var data = new List<BeTipoContrabando>();

        //    try
        //    {
        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from tc in db.TipoContrabando
        //                          join a in db.Auditoria
        //                          on tc.AuditoriaID equals a.AuditoriaID
        //                          join e in db.Estatus on tc.EstatusID equals e.EstatusID
        //                          join tp in db.TipoProducto on tc.TipoProductoID equals tp.TipoProductoID
        //                          where tc.TipoContrabandoID == id
        //                          select new BeTipoContrabando()

        //                          {

        //                              ID = tc.TipoContrabandoID,
        //                              AuditoriaID = a.AuditoriaID,
        //                              Nombre = tp.Nombre,
        //                              TipoProductoID = tc.TipoProductoID,
        //                              EstatusID = tc.EstatusID,
        //                              UsuarioCreo = a.UsuarioCreo,
        //                              FechaCreo = a.FechaCreo,
        //                              UsuarioActualizo = a.UsuarioActualizo,
        //                              FechaActualizo = a.FechaActualizo

        //                          });


        //        };
        //        return data.FirstOrDefault();
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);

        //    }

        //}

        ///// <summary>
        ///// Create Tipo Novedad
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public bool Create(BeTipoContrabando item)
        //{

        //    using (var db = new Context_SistRE())
        //    using (var dbContextTransaction = db.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            ///Create Auditoria
        //            var a = new Auditoria();
        //            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        //            a.UsuarioCreo = userName.Substring(0, 6);
        //            a.FechaCreo = DateTime.Now;
        //            a.NombrePC = Environment.MachineName;
        //            a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
        //            db.Auditoria.Add(a);
        //            db.SaveChanges();

        //            ////Create Tipo Contrabando
        //            var tc = new TipoContrabando();
        //            tc.EstatusID = (int)item.EstatusID;
        //            tc.TipoProductoID = item.TipoProductoID;
        //            tc.TipoNovedadID = item.TipoNovedadID;
        //            tc.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
        //            db.TipoContrabando.Add(tc);
        //            db.SaveChanges();
        //            dbContextTransaction.Commit();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            dbContextTransaction.Rollback();
        //            throw new Exception(ex.Message);
        //        }
        //    }

        //}

        ///// <summary>
        ///// Edit Tipo Novedad
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public bool Edit(BeTipoContrabando item)
        //{

        //        using (var db = new Context_SistRE())
        //        using (var dbContextTransaction = db.Database.BeginTransaction())
        //        {

        //            try
        //            {
        //                 var a = new Auditoria();
        //                 string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(0,6).ToLower();
        //                 a.AuditoriaID = item.AuditoriaID;
        //                 a.UsuarioActualizo = userName;
        //                 a.FechaActualizo = DateTime.Now;
        //                 db.Auditoria.Attach(a);
        //                 db.Entry(a).Property(x => x.UsuarioActualizo).IsModified = true;
        //                 db.Entry(a).Property(x => x.FechaActualizo).IsModified = true;
        //                 db.SaveChanges();

        //                var tc = new TipoContrabando();

        //                tc.TipoContrabandoID = item.ID;
        //                tc.AuditoriaID = item.AuditoriaID;
        //                tc.EstatusID = (int)item.EstatusID;
        //                tc.TipoProductoID = item.TipoProductoID;
        //                db.TipoContrabando.Attach(tc);
        //                db.Entry(tc).Property(x => x.TipoProductoID).IsModified = true;
        //                db.Entry(tc).Property(x => x.EstatusID).IsModified = true;

        //                db.SaveChanges();
        //                dbContextTransaction.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                dbContextTransaction.Rollback();
        //                throw new Exception(ex.Message);
        //            }
        //        }

        //    }

        ///// <summary>
        ///// Elimina Tipo Novedad
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //    public bool Delete(int? id)
        //{
        //    try
        //    {
        //        using (var db = new Context_SistRE())
        //        {


        //            var tn = db.TipoContrabando.Find(id);
        //            if (tn != null)

        //                db.TipoContrabando.Remove(tn);
        //            db.SaveChanges();
        //            return true;

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);

        //    }
        //}
    }
}
