using BeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;

namespace BusinessControl
{

    /// <summary>
    /// Clase BC Estatus
    /// </summary>
    public static class BcEstatus
    {
        #region objetos y variables
        private static DalcEstatus _dalc = new DalcEstatus();
        #endregion

        /// <summary>
        /// Find All Estatus
        /// </summary>
        /// <returns></returns>
        public static List<BeEstatus> GetAll()
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
    }
}
