
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DataLogic;
//using BeEntity;

//namespace BusinessControl
//{

//    /// <summary>
//    /// Class BC Tipo Novedad
//    /// </summary>
//    public static class BcTipoHospitalizacion
//    {

//        #region objetos y variables
//        private static DalcTipoHospitalizacion _dalc = new DalcTipoHospitalizacion();
//        #endregion


//        /// <summary>
//        /// Find All Tipo Novedades
//        /// </summary>
//        /// <returns></returns>
//        public static List<BeTipoHospitalizacion> GetAll()
//        {
//            try
//            {
//                return _dalc.GetAll();

//            }
//            catch (Exception ex)
//            {

//                throw new Exception(ex.Message);
//            }


//        }

//        /// <summary>
//        /// Find Tipo Novedad
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public static BeTipoHospitalizacion Find(int? id)
//        {
//            try
//            {
//                return _dalc.Find(id);

//            }
//            catch (Exception ex)
//            {

//                throw new Exception(ex.Message);
//            }


//        }

//        /// <summary>
//        /// Create Tipo Novedad
//        /// </summary>
//        /// <param name="item"></param>
//        /// <returns></returns>
//        public static bool Create(BeTipoHospitalizacion item)
//        {
//            try
//            {
//                return _dalc.Create(item);

//            }
//            catch (Exception ex)
//            {

//                throw new Exception(ex.Message);
//            }

//        }

//        /// <summary>
//        /// Edit Tipo Novedad
//        /// </summary>
//        /// <param name="item"></param>
//        /// <returns></returns>
//        public static bool Edit(BeTipoHospitalizacion item)

//        {
//            try
//            {

//                return _dalc.Edit(item);
//            }
//            catch (Exception ex)
//            {

//                throw new Exception(ex.Message);
//            }


//        }




//    }
//}
