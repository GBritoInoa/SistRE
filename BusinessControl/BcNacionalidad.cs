using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
  public static  class BcNacionalidad
    {

        #region objetos y variables
        private static DalcNacionalidad _dalc = new DalcNacionalidad();
        #endregion


        /// <summary>
        /// GetAll Nacionalidad
        /// </summary>
        /// <returns></returns>
        public static List<BeNacionalidad> GetAll()
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
        /// Find Nacionalidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeNacionalidad Find(int? id)
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
        /// Create Nacionalidad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNacionalidad item)
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
        /// Edit Nacionalidad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeNacionalidad item)

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
