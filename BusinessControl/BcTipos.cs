using BeEntity;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessControl
{
       
    /// <summary>
    /// Class BcTipos
    /// </summary>
    public static class BcTipos
    {
        #region Variables u objetos
        private static DalcTipos _dalc = new DalcTipos();
        #endregion


        #region Tipo Medidas dependiendo del tipo Producto
        /// <summary>
        /// GetTipoMedidas
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoMedida> GetTipoMedidas()
        {

            try
            {
                return _dalc.GetTipoMedidas();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// GetTipoMonedas
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoMoneda>GetTipoMonedas()
        {

            try
            {
                return _dalc.GetTipoMoneda();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
               
        /// <summary>
        /// GetTipoMedidaCombusible
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoMedidaCombustible> GetTipoMedidaCombustible()
        {

            try
            {
                return _dalc.GetTipoMedidaCombustible();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion



        #region Tipo Producto
               
        /// <summary>
        /// GetTipoCombusible
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoCombustible> GetTipoCombustible()
        {

            try
            {
                return _dalc.GetTipoCombustible();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// GetTipoProducto
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoProducto> GetTipoProducto()
        {

            try
            {
                return _dalc.GetTipoProducto();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Get Causa Repatriación
        /// </summary>
        /// <returns></returns>
        public static List<BeCausaRepatriacion> GetCausaRepatriacion()
        {

            try
            {
                return _dalc.GetCausaRepatriacion();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// GetProductos
        /// </summary>
        /// <returns></returns>
        public static List<BeProductos> GetProductos()
        {

            try
            {
                return _dalc.GetProductos();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Get Tipo Decomisos
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoDecomiso> GetTipoDecomisos()
        {

            try
            {
                return _dalc.GetTipoDecomisos();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Get Tipo Drogas
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoDroga> GetTipoDrogas()
        {

            try
            {
                return _dalc.GetTipoDrogras();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Get Tipo Medicamentos
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoMedicamento> GetTipoMedicamentos()
        {

            try
            {
                return _dalc.GetTipoMedicamentos();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Tipo Presentación Medicamentos
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoPresetacionMedicamento> GetTipPresentacionMedicamento()
        {

            try
            {
                return _dalc.GetTipoPresentacionMedicamento();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
