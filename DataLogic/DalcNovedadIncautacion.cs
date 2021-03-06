using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BeEntity;

namespace DataLogic
{
    public class DalcNovedadIncautacion
    {

        /// <summary>
        /// Listado de Novedades Incautación Registradas
        /// </summary>
        /// <returns></returns>
        public List<BeNovedadIncautacion> GetAll()
        {
            var data = new List<BeNovedadIncautacion>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from ni in db.NovedadIncautacion
                                  where ni.EstatusID != 3
                                  select new BeNovedadIncautacion()

                                  {

                                      NovedadIncautacionID = ni.NovedadIncautacionID,
                                      TipoNovedadID = ni.TipoNovedadID,
                                      TipoMedidaID = ni.TipoMedidaID,
                                      Causa = ni.Causa,
                                      FechaNovedad = ni.FechaNovedad,
                                      //HoraNovedad = ni.HoraNovedad,
                                      Cantidad = ni.Cantidad,
                                      EstatusID = ni.EstatusID,
                                      //UsuarioCreo = ni.UsuarioCreo,
                                      //FechaCreo = ni.FechaCreo,
                                      //UsuarioActualizo = ni.UsuarioActualizo,
                                      //FechaActualizo = ni.FechaActualizo
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
        ///  Novedad Incautación Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeNovedadIncautacion Find(int? id)
        {
            var data = new List<BeNovedadIncautacion>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from ni in db.NovedadIncautacion.Where(t => t.NovedadIncautacionID == id)
                                  select new BeNovedadIncautacion()

                                  {

                                      NovedadIncautacionID = ni.TipoNovedadID,
                                      TipoNovedadID = ni.TipoNovedadID,
                                      TipoMedidaID = ni.TipoMedidaID,
                                      Causa = ni.Causa,
                                      FechaNovedad = ni.FechaNovedad,
                                      HoraNovedad = ni.HoraNovedad,
                                      Cantidad = ni.Cantidad,
                                      EstatusID = ni.EstatusID,

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
        /// Create  Novedad Incautación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadIncautacion item)
        {


            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    #region Begin Transacction
                    /////////Crea Registro Auditoria////////
                    var a = new Auditoria();
                    a.UsuarioCreo = item.UserLogueado;
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ///////Create Novedad Incautación//////////
                    var ni = new NovedadIncautacion();
                    ni.NovedadIncautacionID = item.NovedadIncautacionID;
                    ni.Cantidad = item.Cantidad;                   
                    ni.TipoIncautacionID = item.TipoIncautacionID;
                    ni.ProductoID = item.ProductoID;
                    ni.TipoMedidaID = Convert.ToInt32(item.TipoMedidaID).Equals(0) ? 0: item.TipoMedidaID;
                    ni.ProvinciaID = Convert.ToInt32(item.ProvinciaID).Equals(0) ? 0 : item.ProvinciaID;
                    ni.FechaNovedad = item.FechaNovedad;
                    ni.HoraNovedad = item.HoraNovedad;
                    ni.BrigadaID = item.BrigadaID;
                    ni.Causa = item.Causa;
                    ni.EstatusID = item.EstatusID;
                    ni.TipoNovedadID = item.TipoNovedadID;
                    ni.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.NovedadIncautacion.Add(ni);
                    db.SaveChanges();

                    //////////Create HistoricoNovedades////////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = item.TipoNovedadID;
                    hn.AuditoriaID = ni.AuditoriaID;
                    hn.FechaNovedad = item.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.ProvinciaID = Convert.ToInt32(item.ProvinciaID).Equals(0) ? 0 : item.ProvinciaID;
                    hn.TipoID = item.TipoIncautacionID;
                    db.HistoricoNovedades.Add(hn);
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    #endregion
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception(ex.Message);
                }

            }

        }

        ///// <summary>
        ///// Edit Registro Novedad Incautación
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public bool Edit(BeNovedadIncautacion item)
        //{

        //    try
        //    {
        //        using (var db = new Context_SistRE())
        //        {
        //            var tn = new NovedadIncautacion();


        //            //tn.UsuarioActualizo = "gbrito";
        //            //tn.FechaActualizo = DateTime.Now;
        //            tn.TipoNovedadID = item.TipoNovedadID;
        //            tn.TipoMedidaID = item.TipoMedidaID;
        //            tn.EstatusID = (int)item.EstatusID;
        //            db.NovedadIncautacion.Attach(tn);
        //            db.Entry(tn).Property(x => x.TipoNovedadID).IsModified = true;
        //            db.Entry(tn).Property(x => x.TipoIncautacionID).IsModified = true;
        //            db.Entry(tn).Property(x => x.Causa).IsModified = true;
        //            db.Entry(tn).Property(x => x.FechaNovedad).IsModified = true;
        //            db.Entry(tn).Property(x => x.HoraNovedad).IsModified = true;
        //            db.Entry(tn).Property(x => x.Cantidad).IsModified = true;
        //            db.Entry(tn).Property(x => x.EstatusID).IsModified = true;
        //            //db.Entry(tn).Property(x => x.UsuarioActualizo).IsModified = true;
        //            //db.Entry(tn).Property(x => x.FechaActualizo).IsModified = true;
        //            db.SaveChanges();
        //            return true;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw new Exception(ex.Message);
        //    }

        //}

        ///// <summary>
        ///// Elimina Tipo Novedad
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public bool Delete(int? id)
        //{
        //    try
        //    {
        //        using (var db = new Context_SistRE())
        //        {


        //            var tn = db.TipoNovedad.Find(id);
        //            if (tn != null)

        //                db.TipoNovedad.Remove(tn);
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
