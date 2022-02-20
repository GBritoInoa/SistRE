using BeEntity;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessControl
{
    public static class BcComun
    {

        #region objetos y variables
        private static DalcComun _dalc = new DalcComun();
        #endregion

        /// <summary>
        /// Bc Sexo
        /// </summary>
        /// <returns></returns>
        public static List<BeSexo> GetSexo()
        {
            try
            {
                return _dalc.GetSexo();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Bc Provincias
        /// </summary>
        /// <returns></returns>
        public static List<BeProvincias> GetProvincias()
        {
            try
            {
                return _dalc.GetProvincias();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }




        /// <summary>
        /// Bc Brigadas
        /// </summary>
        /// <returns></returns>
        public static List<BeBrigada> GetBrigadas()
        {

            try
            {
                return _dalc.GetBrigadas();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Bc Rangos
        /// </summary>
        /// <returns></returns>
        public static List<BeRangos> GetRangos()
        {
            try
            {
                return _dalc.GetRangos();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Bc Compañías
        /// </summary>
        /// <returns></returns>
        public static List<BeCompania> GetCompania()
        {
            try
            {
                return _dalc.GetCompania();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public static List<BeTipoDroga> GetTipoDroga()
        {
            try
            {
                return _dalc.GetTipoDroga();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //public static List<BeTipoPerdidaDocumento> GetTipoPerdidaDocumento()
        //{
        //    try
        //    {
        //        return _dalc.GetTipoPerdidaDocumento();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        public static List<BeTipoMedicamento> GetTipoMedicamento()
        {
            try
            {
                return _dalc.GetTipoMedicamento();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static List<BeTipoContrabando> GetTipoContrabando()
        {
            try
            {
                return _dalc.GetTipoContrabando();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //public static List<BeTipoFallecimiento> GetTipoFallecimiento()
        //{
        //    try
        //    {
        //        return _dalc.GetTipoFallecimiento();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public static List<BeTipoHospitalizacion> GetTipoHospitalizacion()
        //{
        //    try
        //    {
        //        return _dalc.GetTipoHospitalizacion();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public static List<BeTipoEntrega> GetTipoEntrega()
        //{
        //    try
        //    {
        //        return _dalc.GetTipoEntrega();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        public static List<BeTipoProtesta> GetTipoProtesta()
        {
            try
            {
                return _dalc.GetTipoProtesta();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static List<BePais> GetPais()
        {
            try
            {
                return _dalc.GetPais();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public static List<BeProtestaConvocatoria> GetProtestaConvocatoria()
        {
            try
            {
                return _dalc.GetProtestaConvocatoria();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static List<BeNacionalidad> GetNacionalidad()
        {
            try
            {
                return _dalc.GetNacionalidad();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static List<BeTipoVehiculo> GetTipoVehiculo()
        {
            try
            {
                return _dalc.GetTipoVehiculo();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //public static List<BeTipoCausaMuerte> GetTipoCausaMuerte()
        //{
        //    try
        //    {
        //        return _dalc.GetTipoCausaMuerte();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public static List<BeTipoCausaHerida> GetTipoCausaHerida()
        //{
        //    try
        //    {
        //        return _dalc.GetTipoCausaHerida();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        public static List<BeTipoIncautacion> GetTipoIncautacion()
        {
            try
            {
                return _dalc.GetTipoIncautacion();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
