
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
                                      Nombres = u.Nombre,                                      
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

      
    }
}
