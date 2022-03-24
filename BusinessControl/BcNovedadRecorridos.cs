using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
    public static class BcNovedadRecorridos
    {
        #region objetos y variables
        private static DalcNovedadRecorridos _dalc = new DalcNovedadRecorridos();
        #endregion


        /// <summary>
        /// Create Novedad Recorridos
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadRecorridos item)
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
