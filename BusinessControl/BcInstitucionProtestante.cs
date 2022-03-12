using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
    public static class BcInstitucionProtestante
    {

        #region objetos y variables
        private static DalcInstitucionProtestante _dalc = new DalcInstitucionProtestante();
        #endregion


        /// <summary>
        /// GetAll InstitucionProtestante
        /// </summary>
        /// <returns></returns>
        public static List<BeInstitucionProtestante> GetAll()
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
        /// Find InstitucionProtestante
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeInstitucionProtestante Find(int? id)
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
        /// Create InstitucionProtestante
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeInstitucionProtestante item)
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
        /// Edit InstitucionProtestante
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeInstitucionProtestante item)

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
