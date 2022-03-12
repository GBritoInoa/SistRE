using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
    public static class BcCategoriaProtesta
    {

        #region objetos y variables
        private static DalcCategoriaProtesta _dalc = new DalcCategoriaProtesta();
        #endregion


        /// <summary>
        /// GetAll CategoriaProtesta
        /// </summary>
        /// <returns></returns>
        public static List<BeCategoriaProtesta> GetAll()
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
        /// Find CategoriaProtesta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeCategoriaProtesta Find(int? id)
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
        /// Create CategoriaProtesta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeCategoriaProtesta item)
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
        /// Edit CategoriaProtesta
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeCategoriaProtesta item)

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
