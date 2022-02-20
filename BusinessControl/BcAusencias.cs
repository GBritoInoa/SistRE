using BeEntity;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessControl
{
  public static  class BcAusencias
    {
        #region objetos y variables
        private static DalcAusencias _dalc = new DalcAusencias();
        #endregion


        /// <summary>
        /// Find All Tipo Ausencia
        /// </summary>
        /// <returns></returns>
        public static List<BeAusencias> GetAll()
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
        /// Find Tipo Ausencia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeAusencias Find(int? id)
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
        /// Create Tipo Ausencia
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeAusencias item)
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
        /// Edit Tipo Ausencia
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeAusencias item)

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
