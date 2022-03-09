using BeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{

    /// <summary>
    ///Class Dalc Tipos
    /// </summary>
  public class DalcTipos
    {



        /// <summary>
        /// GetProductos
        /// </summary>
        /// <returns></returns>
        public List<BeProductos> GetProductos()
        {
            List<BeProductos> data = new List<BeProductos>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.Productos
                                  where p.EstatusID == 1
                                  select new BeProductos()
                                  {
                                      ID = p.ProductoID,
                                      Nombre = p.Nombre,
                                      TipoProductoID = p.TipoProductoID


                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



 /// <summary>
 /// Causa Repatriación
 /// </summary>
 /// <returns></returns>
        public List<BeCausaRepatriacion> GetCausaRepatriacion()
        {
            List<BeCausaRepatriacion> data = new List<BeCausaRepatriacion>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.CausaRepatriacion
                                  where p.EstatusID == 1
                                  select new BeCausaRepatriacion()
                                  {
                                      ID = p.CausaRepratriacionID,
                                      Nombre = p.Nombre


                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



        /// <summary>
        /// GetTipoProductos
        /// </summary>
        /// <returns></returns>
        public List<BeTipoProducto> GetTipoProducto()
        {
            List<BeTipoProducto> data = new List<BeTipoProducto>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from p in db.TipoProducto
                                  where p.EstatusID == 1
                                  select new BeTipoProducto()
                                  {
                                      TipoProductoID = p.TipoProductoID,
                                      Nombre = p.Nombre


                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



        /// <summary>
        /// Dalc Tipo Drogas
        /// </summary>
        /// <returns></returns>
        public List<BeTipoDroga> GetTipoDrogras()
        {
            List<BeTipoDroga> data = new List<BeTipoDroga>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoDroga
                                  select new BeTipoDroga()
                                  {
                                      TipoDrogaID = tm.TipoDrogaID,
                                      Nombre = tm.Nombre,

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        //public List<BeTipoMedidas>GetTipoMedidas()
        //{
        //    List<BeTipoMedidas> data = new List<BeTipoMedidas>();
        //    try
        //    {
        //        using (var db = new Context_SistRE())
        //        {

        //            data.AddRange(from p in db.Productos
        //                          join tp in db.TipoProducto
        //                          on p.TipoProductoID equals tp.TipoProductoID
        //                          join tm in db.TipoMedidas
        //                          on tp.TipoProductoID equals tm.TipoProductoID
        //                          where )

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        
        /// <summary>
        /// Get Tipo Dinero
        /// </summary>
        /// <returns></returns>
        public List<BeTipoMoneda> GetTipoMoneda()
        {
            List<BeTipoMoneda> data = new List<BeTipoMoneda>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoMoneda where tm.EstatusID==1
                                  select new BeTipoMoneda()
                                  {
                                      TipoMonedaID = tm.TipoMonedaID,
                                      Nombre = tm.Nombre
                                      

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Tipo Medida Combustible
        /// </summary>
        /// <returns></returns>
        public List<BeTipoMedidaCombustible> GetTipoMedidaCombustible()
        {
            List<BeTipoMedidaCombustible> data = new List<BeTipoMedidaCombustible>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoMedidaCombustible
                                  where tm.EstatusID == 1
                                  select new BeTipoMedidaCombustible()
                                  {
                                      TipoMedidaCombustibleID = tm.TipoMedidaCombustibleID,
                                      Medida = tm.Medida


                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Tipo Combustible
        /// </summary>
        /// <returns></returns>
        public List<BeTipoCombustible> GetTipoCombustible()
        {
            List<BeTipoCombustible> data = new List<BeTipoCombustible>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoCombustible
                                  where tm.EstatusID == 1
                                  select new BeTipoCombustible()
                                  {
                                      TipoCombustibleID = tm.TipoCombustibleID,
                                      Nombre = tm.Nombre


                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Dalc Tipo Apresamientos
        /// </summary>
        /// <returns></returns>
        public List<BeTipoApresamiento> GetTipoApresamientos()
        {
            List<BeTipoApresamiento> data = new List<BeTipoApresamiento>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoApresamiento
                                  select new BeTipoApresamiento()
                                  {
                                      ID = tm.TipoApresamientoID,
                                      Nombre = tm.Nombre,

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// Dalc Tipo Medidas
        /// </summary>
        /// <returns></returns>
        public List<BeTipoMedida> GetTipoMedidas()
        {
            List<BeTipoMedida> data = new List<BeTipoMedida>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoMedidas where tm.EstatusID==1
                                  select new BeTipoMedida()
                                  {
                                      TipoMedidaID = tm.TipoMedidaID,
                                      Medida = tm.Nombre,

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Dalc Tipo Decomiso
        /// </summary>
        /// <returns></returns>
        public List<BeTipoDecomiso> GetTipoDecomisos()
        {
            var data = new List<BeTipoDecomiso>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from d in db.TipoDecomiso where d.EstatusID ==1

                                  select new BeTipoDecomiso()
                                  {

                                      ID = d.TipoDecomisoID,
                                      TipoNovedadID = d.TipoNovedadID,
                                      //Nombre  = d.Nombre,
                                  });
                    return data.ToList();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Tipo Medicamento
        /// </summary>
        /// <returns></returns>
        public List<BeTipoMedicamento> GetTipoMedicamentos()
        {
            List<BeTipoMedicamento> data = new List<BeTipoMedicamento>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoMedicamento
                                  where tm.EstatusID == 1
                                  select new BeTipoMedicamento()
                                  {
                                      TipoMedicamentoID = tm.TipoMedicamentoID,
                                      Nombre = tm.Nombre                                     


                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Tipo Presentación Medicamento
        /// </summary>
        /// <returns></returns>
        public List<BeTipoPresetacionMedicamento> GetTipoPresentacionMedicamento()
        {
            List<BeTipoPresetacionMedicamento> data = new List<BeTipoPresetacionMedicamento>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tm in db.TipoPresentacionMedicamento
                                  where tm.EstatusID == 1
                                  select new BeTipoPresetacionMedicamento()
                                  {
                                      ID = tm.TipoPresentacionMedicamentoID,
                                      Nombre = tm.Nombre


                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
