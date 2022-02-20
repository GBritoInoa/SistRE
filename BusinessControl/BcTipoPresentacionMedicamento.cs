using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;

namespace BusinessControl
{

    /// <summary>
    /// BC Tipo Presentación Medicamentos
    /// </summary>
  public static class BcTipoPresentacionMedicamento
    {
        #region objetos y variables
        private static DalcTipoPresentacionMedicamento _dalc = new DalcTipoPresentacionMedicamento();
        #endregion


        /// <summary>
        /// Find All Tipo Presentación Medicamentos
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoPresetacionMedicamento> GetAll()
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
        /// Find Tipo Presentación Medicamentos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeTipoPresetacionMedicamento Find(int? id)
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
        /// Create Tipo Presentación Medicamentos
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeTipoPresetacionMedicamento item)
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
        /// Edit Tipo Presentación Medicamentos
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeTipoPresetacionMedicamento item)

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
