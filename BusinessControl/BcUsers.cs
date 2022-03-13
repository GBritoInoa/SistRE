
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
    /// Class BC Users
    /// </summary>
    public static class BcUsers
    {

        #region objetos y variables
        private static DalcUser _dalc = new DalcUser();
        #endregion


        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        public static List<BeUser> GetAll()
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
        public static BeUser Get(string UserName)
        {
            try
            {
                return _dalc.Get(UserName);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        ///// <summary>
        ///// Find Tipo Novedad
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static BeUser Find(int? id)
        //{
        //    try
        //    {
        //        return _dalc.Find(id);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }


        //}

        /// <summary>
        /// Create Tipo Novedad
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        //public static bool Create(BeUser item)
        //{
        //    try
        //    {
        //        return _dalc.Create(item);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        ///// <summary>
        ///// Edit Tipo Novedad
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public static bool Edit(BeUser item)

        //{
        //    try
        //    {

        //        return _dalc.Edit(item);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }


        //}




    }
}
