using BeEntity;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessControl
{

    /// <summary>
    /// Bc Tipo Arma
    /// </summary>
 public  static class BcTipoArma
    {

        #region objetos y variables
        private static DalcTipoArma _dalc = new DalcTipoArma();
        #endregion


        /// <summary>
        /// Find All Tipo Arma
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoArma> GetAll()
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
        /// Find Tipo Arma
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeTipoArma Find(int? id)
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
        /// Create Tipo Arma
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeTipoArma item)
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
        /// Edit Tipo Arma
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeTipoArma item)

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
