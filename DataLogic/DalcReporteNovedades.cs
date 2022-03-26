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
        public List<BeReporteNovedades> GetAll( int TipoNovedadId, DateTime FechaDesde, DateTime FechaHasta)
        {
            var data = new List<BeReporteNovedades>();
            using (var db = new Context_SistRE())
            {
                data.AddRange(db.usp_ReporteNovedades(TipoNovedadId, FechaDesde, FechaHasta).Select(rn => new BeReporteNovedades() {
                    CantidadNovedad = rn.CantidadNovedad ?? 0,
                    Provincia = rn.LugarNovedad,
                    Novedad = rn.C_TipoNovedad
                }));
            }


            return data;

            //try
            //{

            //    var conexionStr = ConfigurationManager
            //        .ConnectionStrings["Context_SistRE"].ConnectionString;

            //    List<BeReporteNovedades> listReporte = new List<BeReporteNovedades>();

            //    using (var conexion = new SqlConnection(conexionStr))
            //    {
                  


            //        conexion.Open();
            //        var comando = new SqlCommand("usp_ReporteNovedades", conexion);
            //        comando.CommandType = CommandType.StoredProcedure;
            //        comando.Parameters.Add(new SqlParameter("@TipoNovedadID", TipoNovedadId));
            //        comando.Parameters.Add(new SqlParameter("@FechaDesde", FechaDesde));
            //        comando.Parameters.Add(new SqlParameter("@FechaHasta", FechaHasta));
            //        var dataReader = comando.ExecuteReader();
            //        while (dataReader.Read())
            //        {
            //            var result = new BeReporteNovedades();
            //            result.TipoNovedadID = (int)dataReader["TipoNovedad"];
            //            result.Provincia = (string)dataReader["LugarNovedad"];
            //            result.CantidadNovedad = (int)dataReader["CantidadNovedad"];
            //            listReporte.Add(result);
            //        }

            //        conexion.Close();
            //    }

            //    return listReporte;

            //    //using (var db = new configura())
            //    //{


            //    //    //data.AddRange(from hn in db.HistoricoNovedades
            //    //    //              join tn in db.TipoNovedad
            //    //    //              on hn.TipoNovedadID equals  tn.TipoNovedadID
                                                                  
            //    //    //              where  hn.TipoNovedadID == TipoNovedadId && hn.FechaNovedad ==  FechaDesde && hn.FechaNovedad == FechaHasta
            //    //    //              && tn.EstatusID ==1
            //    //    //              select new BeReporteNovedades()

            //    //    //              {
            //    //    //                  NovedadID = hn.NovedadesID,
            //    //    //                  TipoNovedadID = hn.TipoNovedadID,
            //    //    //                  Novedad = tn.Nombre,

                                   
            //    //    //              });

            //    //};
            //    //return data.ToList();
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}

        }
    }
}
