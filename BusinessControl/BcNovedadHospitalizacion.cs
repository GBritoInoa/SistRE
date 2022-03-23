using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
    public static class BcNovedadHospitalizacion
    {
        #region objetos y variables
        private static DalcNovedadHospitalizacion _dalc = new DalcNovedadHospitalizacion();
        #endregion


        /// <summary>
        /// Create Novedad Hospitalizacion
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadHospitalizacion item)
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
