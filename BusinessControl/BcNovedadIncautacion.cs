using System;
using System.Collections.Generic;
using BeEntity;
using DataLogic;

namespace BusinessControl 
{
    public  static class BcNovedadIncautacion
    {


        #region objetos y variables
        private static DalcNovedadIncautacion _dalc = new DalcNovedadIncautacion();
        #endregion


        /// <summary>
        /// GetAll Registro  Novedades
        /// </summary>
        /// <returns></returns>
        public static List<BeNovedadIncautacion> GetAll()
        {
            try
            {
                return _dalc.GetAll();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        /// <summary>
        /// Find Registro Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeNovedadIncautacion Find(int? id)
        {
            try
            {
                return _dalc.Find(id);

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
        public static bool Create(BeNovedadIncautacion item)
        {
            try
            {
                return _dalc.Create(item);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        ///// <summary>
        ///// Edit Registro Novedad Incautación
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public static bool Edit(BeNovedadIncautacion item)

        //{
        //    try
        //    {

        //        return _dalc.Edit(item);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }


        //}

    }
}

