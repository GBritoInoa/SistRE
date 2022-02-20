using BeEntity;
using DataLogic;
using System;
using System.Collections;

namespace BusinessControl
{
    public static class BcNovedadRepatriacion
    {

        #region Objetos y clases
        private static DalcNovedadRepatriacion _dalc = new DalcNovedadRepatriacion();
        #endregion


        /// <summary>
        /// BC Novedad Repatriación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create (BeNovedadRepatriacion item)
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
