using System;
using System.Collections.Generic;
using BeEntity;
using DataLogic;

namespace BusinessControl 
{
    public  static class BcNovedadProtesta
    {


        #region objetos y variables
        private static DalcNovedadProtesta _dalc = new DalcNovedadProtesta();
        #endregion


        /// <summary>
        /// GetAll Registro  Novedades
        /// </summary>
        /// <returns></returns>
        //public static List<BeNovedadProtesta> GetAll()
        //{
        //    try
        //    {
        //        return _dalc.get();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }


        //}


        /// <summary>
        /// Find Registro Novedad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public static BeNovedadProtesta Find(int? id)
        //{
        //    try
        //    {
        //        return _dalc.Find(id);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }


        //}


        /// <summary>
        /// Create  Novedad Incautación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadProtesta item)
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

        /// <summary>
        /// Edit Registro Novedad Incautación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

