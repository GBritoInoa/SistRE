using BeEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{

    /// <summary>
    /// Dalc Reporte Novedades
    /// </summary>
   public class DalcReporteNovedades
    {

           /// <summary>
        /// Listado Novedades
        /// </summary>
        /// <param name="TipoNovedadId"></param>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<BeResultadoNovedad> GetAll(int TipoNovedadId, DateTime FechaDesde, DateTime FechaHasta)
        {
            var data = new List<BeResultadoNovedad>();
            using (var db = new Context_SistRE())
            {

                if(TipoNovedadId== 0)
                {
                    //Primero obtenemos el día actual
                     DateTime date = DateTime.Now;

                    //Asi obtenemos el primer dia del mes actual
                    DateTime fechadesde = new DateTime(date.Year, date.Month, 1);

                    //Y de la siguiente forma obtenemos el ultimo dia del mes
                    //agregamos 1 mes al objeto anterior y restamos 1 día.
                    DateTime fechahasta = fechadesde.AddMonths(1).AddDays(-1);
                    //DateTime fechadesde = new DateTime(2020, 01, 01);
                    //DateTime fechahasta = new DateTime(2022, 03, 31);
                    TipoNovedadId = 0;
                    data.AddRange(db.usp_ReporteNovedades(TipoNovedadId, fechadesde, fechahasta).Select(rn => new BeResultadoNovedad()
                    {
                        Cantidad = rn.CantidadNovedad ?? 0,
                        Provincia = rn.LugarNovedad,
                        Novedad = rn.C_TipoNovedad + ";"
                    }));

                }

                else
                {
                    data.AddRange(db.usp_ReporteNovedades(TipoNovedadId, FechaDesde, FechaHasta).Select(rn => new BeResultadoNovedad()
                    {
                        Cantidad = rn.CantidadNovedad ?? 0,
                        Provincia = rn.LugarNovedad,
                        Novedad = rn.C_TipoNovedad + ";"
                    }));
                }

            
            }


            return data;

        }


        /// <summary>
        /// Porciento Novedes mes en curso
        /// </summary>
        /// <returns></returns>
        public List<BeResultadoNovedad> PorcientoNovedadesMes_Encurso()
        {
            try
            {

                var data = new List<BeResultadoNovedad>();
                using (var db = new Context_SistRE())
                {
                    data.AddRange(db.usp_porcientoNovedades_mesencurso().Select(rn => new BeResultadoNovedad()
                    {
                        Novedad = rn.TipoNovedad,
                        PorcientoNovedad = (string)rn.total.ToString(),
            

                    }));
                }
                return data;
            }
            catch (Exception)
            {

                throw;
            }

            
        }
        
    }
}
