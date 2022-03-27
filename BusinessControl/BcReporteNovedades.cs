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
    public static class BcReporteNovedades
    {
        #region objetos y variables
        private static DalcReporteNovedades _dalc = new DalcReporteNovedades();
        #endregion

        /// <summary>
        /// Find All Reporte Novedades
        /// </summary>
        /// <returns></returns>
        public static List<BeResultadoNovedad> GetAll(int TipoNovedadId, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                return _dalc.GetAll(TipoNovedadId, FechaDesde, FechaHasta);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
    }
}
