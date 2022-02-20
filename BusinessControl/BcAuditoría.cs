using BeEntity;
using DataLogic;
using System;

namespace BusinessControl
{
    public  static class BcAuditoría
    {
        #region objetos y variables
        private static DalcAuditoria _dalc = new DalcAuditoria();
        #endregion


        /// <summary>
        /// Get Last Auditoría
        /// </summary>
        /// <returns></returns>
        public static BeAuditoria GetLast()
        {
            try
            {
                return _dalc.GetLast();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        /// <summary>
        /// Find Auditoría
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeAuditoria Find(int? id)
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
        /// Create Auditoría
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeAuditoria item)
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
        /// Edit Auditoría
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeAuditoria item)

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
