﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BeEntity;

namespace BusinessControl
{
  public static  class BcNovedadApresamiento
    {
        #region objetos y variables
        private static DalcNovedadApresamiento _dalc = new DalcNovedadApresamiento();
        #endregion


        /// <summary>
        /// Create Novedad Apresamiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeNovedadApresamientos item)
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
