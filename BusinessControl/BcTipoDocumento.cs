using BeEntity;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessControl
{
   public static class BcTipoDocumento
    {
        #region objetos y variables
        private static DalcTipoDocumento _dalc = new DalcTipoDocumento();
        #endregion


        /// <summary>
        /// Get All Tipo Documentos
        /// </summary>
        /// <returns></returns>
        public static List<BeTipoDocumento> GetTipoDocumento()
        {
            try
            {
                return _dalc.GetTipoDocumento();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        /// <summary>
        /// Find Tipo Documento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeTipoDocumento Find(int? id)
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
        /// Create Tipo Documento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeTipoDocumento item)
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
        /// Edit Tipo Documento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeTipoDocumento item)

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
