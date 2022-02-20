using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using DataLogic;

namespace BusinessControl
{
   public static class BcTipoDecomiso
    {
        #region Variables u Objetos
        private static DalcTipoDecomiso _dalc = new DalcTipoDecomiso();
        #endregion

        /// <summary>
        /// Get All Tipo Decomiso
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoDecomiso> GetAll()
        {
            try
            {
                return _dalc.GetTipoDecomisos();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Find Tipo Decomiso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeTipoDecomiso Find(int? id)
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
        /// Create Tipo Decomiso
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeTipoDecomiso item)
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
        /// Edit Tipo Decomiso
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeTipoDecomiso item)

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
