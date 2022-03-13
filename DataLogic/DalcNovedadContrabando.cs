using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BeEntity;

namespace DataLogic
{
    public class DalcNovedadContrabando
    {

        /// <summary>
        /// Listado de Novedades Contrabando Registradas
        /// </summary>
        /// <returns></returns>
        public List<BeNovedadContrabando> GetAll()
        {
            var data = new List<BeNovedadContrabando>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from ni in db.NovedadContrabando
                                  where ni.EstatusID != 3
                                  select new BeNovedadContrabando()

                                  {

                                      NovedadContrabandoID = ni.NovedadContrabandoID,
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
        public BeNovedadContrabando Find(int? id)
        {
            var data = new List<BeNovedadContrabando>();

            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from ni in db.NovedadContrabando.Where(t => t.NovedadContrabandoID == id)
                                  select new BeNovedadContrabando()

                                  {

                                      NovedadContrabandoID = ni.NovedadContrabandoID,
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
        /// Create  Novedad Contrabando
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(BeNovedadContrabando  item)
        {


            using (var db = new Context_SistRE())
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    #region Begin Transacction
                    /////////Crea Registro Auditoria////////
                    var a = new Auditoria();
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(0, 6).ToLower();
                    a.UsuarioCreo = userName;
                    a.FechaCreo = DateTime.Now;
                    a.NombrePC = Environment.MachineName;
                    a.IpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.AddressFamily.ToString().ToUpper().Equals("INTERNETWORK")).FirstOrDefault().ToString();
                    db.Auditoria.Add(a);
                    db.SaveChanges();

                    ///////Create Novedad Contrabando//////////
                    var ni = new NovedadContrabando();
                    ni.NovedadContrabandoID = item.NovedadContrabandoID;
                    ni.Cantidad = item.Cantidad;                   
                    ni.TipoContrabandoID = item.TipoContrabandoID;
                    ni.ProductoID = item.ProductoID;
                    ni.TipoMedidaID = Convert.ToInt32(item.TipoMedidaID).Equals(0) ? 0 : item.TipoMedidaID;
                    ni.ProvinciaID = item.ProvinciaID;
                    ni.FechaNovedad = item.FechaNovedad;
                    ni.HoraNovedad = item.HoraNovedad;
                    ni.BrigadaID = item.BrigadaID;
                    ni.Causa = item.Causa;
                    ni.EstatusID = item.EstatusID;
                    ni.TipoNovedadID = item.TipoNovedadID;
                    ni.AuditoriaID = Convert.ToInt32(db.usp_maxCodAuditoria().FirstOrDefault());
                    db.NovedadContrabando.Add(ni);
                    db.SaveChanges();

                    //////////Create HistoricoNovedades////////
                    var hn = new HistoricoNovedades();
                    hn.TipoNovedadID = hn.TipoNovedadID;
                    hn.AuditoriaID = ni.AuditoriaID;
                    hn.FechaNovedad = ni.FechaNovedad;
                    hn.HoraNovedad = item.HoraNovedad;
                    hn.ProvinciaID = Convert.ToInt32(item.ProvinciaID).Equals(0) ? 0 : item.ProvinciaID;
                    hn.TipoID = item.TipoMedidaID;
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

        /// <summary>
        /// Edit Registro Novedad Incautación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Edit(BeNovedadContrabando item)
        {

            try
            {
                using (var db = new Context_SistRE())
                {
                    var tn = new NovedadContrabando();


                    //tn.UsuarioActualizo = "gbrito";
                    //tn.FechaActualizo = DateTime.Now;
                    tn.TipoNovedadID = item.TipoNovedadID;
                    tn.TipoMedidaID = item.TipoMedidaID;
                    tn.EstatusID = (int)item.EstatusID;
                    db.NovedadContrabando.Attach(tn);
                    db.Entry(tn).Property(x => x.TipoNovedadID).IsModified = true;
                    db.Entry(tn).Property(x => x.NovedadContrabandoID).IsModified = true;
                    db.Entry(tn).Property(x => x.Causa).IsModified = true;
                    db.Entry(tn).Property(x => x.FechaNovedad).IsModified = true;
                    db.Entry(tn).Property(x => x.HoraNovedad).IsModified = true;
                    db.Entry(tn).Property(x => x.Cantidad).IsModified = true;
                    db.Entry(tn).Property(x => x.EstatusID).IsModified = true;
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


                    var tn = db.TipoNovedad.Find(id);
                    if (tn != null)

                        db.TipoNovedad.Remove(tn);
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
