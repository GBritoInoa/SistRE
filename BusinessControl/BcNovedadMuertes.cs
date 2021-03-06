using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
    public static class BcNovedadMuerte
    {
        #region objetos y variables
        private static DalcNovedadMuerte _dalc = new DalcNovedadMuerte();
        #endregion


        /// <summary>
        /// Create Novedad Muerte
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadMuertes item)
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


    }
}
