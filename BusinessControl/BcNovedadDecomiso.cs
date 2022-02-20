using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using DataLogic;

namespace BusinessControl
{
  public static  class BcNovedadDecomiso
    {
        #region objetos y variables
        private static DalcNovedadDecomiso _dalc = new DalcNovedadDecomiso();
        #endregion

        /// <summary>
        /// Create Novedad Decomiso
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadDecomiso item)
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
        ///// Edit Novedad Decomiso
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public static bool Edit(BeNovedadDecomiso item)

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

