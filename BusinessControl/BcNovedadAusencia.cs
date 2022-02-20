using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using DataLogic;

namespace BusinessControl
{
  public static  class BcNovedadAusencia
    {
        #region objetos y variables
        private static DalcNovedadAusencia _dalc = new DalcNovedadAusencia();
        #endregion


        /// <summary>
        /// Create Novedad Ausencia
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadAusencia item)
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
        /// Edit Novedad Ausencia
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeNovedadAusencia item)

        {
            try
            {

                return _dalc.Edit(item);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}
