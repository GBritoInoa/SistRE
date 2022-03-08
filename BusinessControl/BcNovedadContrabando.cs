using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;


namespace BusinessControl
{
        
    public static  class BcNovedadContrabando
    {

        #region objetos y variables
        private static DalcNovedadContrabando _dalc = new DalcNovedadContrabando();
        #endregion

        /// <summary>
        /// Create  Novedad Contrabando
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadContrabando item)
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
