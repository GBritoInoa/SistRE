using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace DataLogic
{
   public class DalTipoHerido
    {

        /// <summary>
        /// Find All  Causa Herida
        /// </summary>
        /// <returns></returns>
        public List<BeTipoHerido> GetAll()
        {
            var data = new List<BeTipoHerido>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.CausaHerido
                                  where tn.EstatusID != 3
                                  select new BeTipoHerido()

                                  {

                                      ID = tn.CausaHeridoID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      //UsuarioCreo = tn.UsuarioCreo,
                                      //FechaCreo = tn.FechaCreo,
                                      //UsuarioActualizo = tn.UsuarioActualizo,
                                      //FechaActualizo = tn.FechaActualizo
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
        /// Tipo Cauda Herida Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeTipoHerido Find(int? id)
        {
            var data = new List<BeTipoHerido>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tn in db.CausaHerido.Where(t => t.CausaHeridoID == id)
                                  select new BeTipoHerido()

                                  {

                                      ID = tn.CausaHeridoID,
                                      Nombre = tn.Nombre,
                                      EstatusID = tn.EstatusID,
                                      //UsuarioCreo = tn.UsuarioCreo,
                                      //FechaCreo = tn.FechaCreo,
                                      //UsuarioActualizo = tn.UsuarioActualizo,
                                      //FechaActualizo = tn.FechaActualizo
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
        /// Create Tipo Causa Herida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeTipoHerido item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var tn = new CausaHerido();
                    tn.Nombre = item.Nombre;
                    tn.EstatusID = (int)item.EstatusID;
                    //tn.UsuarioCreo = "gbrito";
                    //tn.FechaCreo = DateTime.Now;
                    db.CausaHerido.Add(tn);
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
        /// Edit Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeTipoHerido item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var ch = new CausaHerido();


                    //ch.UsuarioActualizo = "gbrito";
                    //ch.FechaActualizo = DateTime.Now;
                    ch.Nombre = item.Nombre;
                    ch.CausaHeridoID = item.ID;
                    ch.EstatusID = (int)item.EstatusID;
                    db.CausaHerido.Attach(ch);
                    db.Entry(ch).Property(x => x.Nombre).IsModified = true;
                    db.Entry(ch).Property(x => x.EstatusID).IsModified = true;
                    //db.Entry(ch).Property(x => x.UsuarioActualizo).IsModified = true;
                    //db.Entry(ch).Property(x => x.FechaActualizo).IsModified = true;
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
        /// Elimina Causa Herida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int? id)
        {
            try
            {
                using (var db = new Context_SistRE())
                {


                    var tn = db.CausaHerido.Find(id);
                    if (tn != null)

                    db.CausaHerido.Remove(tn);
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
