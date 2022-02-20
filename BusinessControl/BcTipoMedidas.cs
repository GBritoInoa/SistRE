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
    /// BcTipoMedidas
    /// </summary>
  public  class BcTipoMedidas
    {
        #region objetos y variables
        private static DalcTipoMedidas _dalc = new DalcTipoMedidas();
        #endregion

        /// <summary>
        /// List Tipo Medidas
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoMedidas> GetAll()
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
        /// Find Tipo Medida
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeTipoMedidas Find(int? id)
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
        /// Create Tipo Medida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeTipoMedidas item)
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
        /// Edit Tipo Medida
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeTipoMedidas item)

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
