using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
    public static class BcEnfermedades
    {

        #region objetos y variables
        private static DalcEnfermedad _dalc = new DalcEnfermedad();
        #endregion


        /// <summary>
        /// GetAll Enfermedades
        /// </summary>
        /// <returns></returns>
        public static List<BeEnfermedades> GetAll()
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
        /// Find Enfermedades
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeEnfermedades Find(int? id)
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
        /// Create Enfermedades
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeEnfermedades item)
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
        /// Edit Enfermedades
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeEnfermedades item)

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
