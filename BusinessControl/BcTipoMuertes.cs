using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
    public static class BcTipoMuertes
    {

        #region objetos y variables
        private static DalcTipoMuertes _dalc = new DalcTipoMuertes();
        #endregion


        /// <summary>
        /// GetAll TipoMuertes
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoMuertes> GetAll()
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
        /// Find TipoMuertes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeTipoMuertes Find(int? id)
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
        /// Create TipoMuertes
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeTipoMuertes item)
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
        /// Edit TipoMuertes
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeTipoMuertes item)

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
