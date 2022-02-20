
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{

    /// <summary>
    /// Class BC Causa Repatriación
    /// </summary>
    public static class BcTipoRepatriacion
    {

        #region objetos y variables
        private static DalcTipoRepatriacion _dalc = new DalcTipoRepatriacion();
        #endregion


        /// <summary>
        /// Find All Causa Repatriación
        /// </summary>
        /// <returns></returns>
        public static List<BeCausaRepatriacion> GetAll()
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
        /// Find Causa Repatriación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeCausaRepatriacion Find(int? id)
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
        /// Create Causa Repatriación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeCausaRepatriacion item)
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
        /// Edit Causa Repatriación
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeCausaRepatriacion item)

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
