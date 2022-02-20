using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalcAuditoria
    {
        /// <summary>
        /// Get Last Auditoría
        /// </summary>
        /// <returns></returns>
        public BeAuditoria GetLast()
        {
            var data = new List<BeAuditoria>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from a in db.Auditoria
                                  orderby a.AuditoriaID descending
                                 
                                  select new BeAuditoria()

                                  {
                                      ID = a.AuditoriaID,
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
        /// Find Auditoría
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeAuditoria Find(int? id)
        {
            var data = new List<BeAuditoria>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from a in db.Auditoria.Where(t => t.AuditoriaID == id)
                                  select new BeAuditoria()

                                  {

                                      ID = a.AuditoriaID,
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
        /// Create Auditoría
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeAuditoria item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {

                    var a = new Auditoria();
                    a.UsuarioCreo = "gbrito";
                    a.FechaCreo = DateTime.Now;
                    db.Auditoria.Add(a);
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
        /// Edit Auditoría
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeAuditoria item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var a = new Auditoria();


                    a.UsuarioActualizo = "gbrito";
                    a.FechaActualizo = DateTime.Now;

                    db.Auditoria.Attach(a);
                    db.Entry(a).Property(x => x.UsuarioActualizo).IsModified = true;
                    db.Entry(a).Property(x => x.FechaActualizo).IsModified = true;
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
    }
}
