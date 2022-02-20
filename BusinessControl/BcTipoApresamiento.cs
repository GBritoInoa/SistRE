using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeEntity;
using DataLogic;

namespace BusinessControl
{
  public static  class BcTipoApresamiento
    {
        #region objetos y variables
        private static DalcTipoApresamiento _dalc = new DalcTipoApresamiento();
        #endregion


        /// <summary>
        /// Bc Tipo Apresamiento
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoApresamiento> GetAll()
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
        /// Find Tipo Apresamiento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeTipoApresamiento Find(int? id)
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
        /// Create Tipo Apresamiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeTipoApresamiento item)
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
        /// Edit Tipo Apresamiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeTipoApresamiento item)

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
