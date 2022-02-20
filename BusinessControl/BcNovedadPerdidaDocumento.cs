using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessControl;
using BeEntity;

namespace BusinessControl
{

    /// <summary>
    /// Class BcNovedadPerdidaDocumento
    /// </summary>
  public static  class BcNovedadPerdidaDocumento
    {
        #region objetos y variables
        private static DalcNovedadPerdidaDocumento _dalc = new DalcNovedadPerdidaDocumento();
        #endregion

        /// <summary>
        /// Create Novedad Perdida Documento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadPerdidaDocumento item)
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
    }
}
