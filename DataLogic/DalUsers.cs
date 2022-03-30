
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
        /// Get Users Creado
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
                                      join a in db.Auditoria on
                                      u.AuditoriaID equals a.AuditoriaID
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
                                      ID = u.UserId,
                                      UserId = u.UserId,
                                      Nombres = u.Nombre,                                      
                                      UserName = u.UserName,
                                      NombreCompleto = u.Apellidos + "," + u.Nombre,
                                      Institucion = i.nombre,
                                      InstitucionID = u.InstitucionID,
                                      BrigadaID =  b.UnidadID,
                                      CompaniaID = b.UnidadID,
                                      Rango = r.nombre,
                                      RangoID = r.RangoID,                                 
                                      Brigada = b.nombre,
                                      Apellidos = u.Apellidos,
                                      PerfilID = u.PerfilID,
                                      Perfil = p.Nombre,
                                      Salt = u.Salt,
                                      Password = u.Password,
                                      CambioClave = (bool)u.CambioClave,
                                      Email = u.Email,
                                      EstatusID = u.EstatusID,
                                      AuditoriaID = a.AuditoriaID,
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
        /// Listado de Novedades
        /// </summary>
        /// <returns></returns>
        public List<BeUser> GetAll()
        {
            return this.GetIncluding(u => true);
        }


        /// <summary>
        /// Get UserName
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public BeUser Get(string UserName)
        {
            return this.GetIncluding(u => u.UserName == UserName).FirstOrDefault();
        }


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeUser item)
        {

            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    ///Create Auditoria
                    var a = new Auditoria();
                    a.UsuarioCreo = item.UserLogueado.ToString();
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ////Create User
                    var u = new Users();
                    u.UserName = item.NumCarnet;
                    u.Nombre = item.Nombres;
                    u.Apellidos = item.Apellidos;
                    u.RangoID = item.RangoID;
                    u.InstitucionID = (int)item.InstitucionID;
                    u.PerfilID = item.PerfilID;
                    u.CambioClave = item.CambioClave;
                    u.BrigadaID = item.BrigadaID;
                    u.Password = item.Password;
                    u.Salt = item.Salt;
                    u.EstatusID = (int)item.EstatusID;
                    u.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.Users.Add(u);
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
        /// Find User
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public BeUser Find (int? id)
        {
            var data = new List<BeUser>();

            try
            {
                using (var db = new Context_SistRE())
                using (var dbERD = new ContextDbERD())

                {
                    data.AddRange(from u in db.Users
                                      join a in db.Auditoria on
                                      u.AuditoriaID equals a.AuditoriaID
                                      //join e in db.Estatus
                                      //on tn.EstatusID equals e.EstatusID
                                  join p in db.Perfil on u.PerfilID equals p.PerfilID
                                  join e in db.Estatus on u.EstatusID equals e.EstatusID
                                  join i in dbERD.Instituciones on u.InstitucionID equals i.InstitucionID
                                  join b in dbERD.Unidades on u.BrigadaID equals b.UnidadID
                                  join r in dbERD.Rangos on u.RangoID equals r.RangoID
                                  where u.UserId == id
                                  select new BeUser()

                                  {
                                      ID = u.UserId,
                                      UserId = u.UserId,
                                      Nombres = u.Nombre,
                                      Apellidos = u.Apellidos,
                                      UserName = u.UserName,
                                      NombreCompleto = u.Apellidos + "," + u.Nombre,
                                      Institucion = i.nombre,
                                      InstitucionID = u.InstitucionID,
                                      BrigadaID = b.UnidadID,
                                      CompaniaID = b.UnidadID,
                                      Rango = r.nombre,
                                      RangoID = r.RangoID,
                                      Brigada = b.nombre,
                                  
                                      PerfilID = u.PerfilID,
                                      Perfil = p.Nombre,
                                      Salt = u.Salt,
                                      Password = u.Password,
                                      CambioClave = (bool)u.CambioClave,
                                      Email = u.Email,
                                      EstatusID = u.EstatusID,
                                      AuditoriaID = (int)u.AuditoriaID,
                                    


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
        /// Edit Tipo Documento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeUser item)
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

                 

                    ////Create User
                    var u = new Users();
                    u.UserId = (int)item.ID;
                    u.UserName = item.UserLogueado;
                    //u.Nombre = item.Nombres;
                    //u.Apellidos = item.Apellidos;
                    u.RangoID = (int)item.RangoID;
                    //u.InstitucionID = (int)item.InstitucionID;
                    u.PerfilID = (int)item.PerfilID;
                    //u.CambioClave = item.CambioClave;
                    //u.BrigadaID = (int)item.BrigadaID;
                    //u.Password = item.Password;
                    //u.Email = item.Email;
                    //u.Salt = item.Salt;
                    u.EstatusID = (int)item.EstatusID;
                    u.AuditoriaID = (int)item.AuditoriaID;
                    db.Users.Attach(u);               
                    db.Entry(u).Property(x => x.EstatusID).IsModified = true;
                    db.Entry(u).Property(x => x.PerfilID).IsModified = true;

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
