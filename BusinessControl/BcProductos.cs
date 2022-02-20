using BeEntity;
using DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessControl
{

    /// <summary>
    /// Bc Producto
    /// </summary>
    public static class BcProductos
    {

        #region objetos y variables
        private static DalcProductos _dalc = new DalcProductos();
        #endregion
        
        /// <summary>
        /// List Productos
        /// </summary>
        /// <returns></returns>
        public static List<BeProductos> GetAll()
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
        /// Find Producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BeProductos Find(int? id)
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
        /// Create Producto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Create(BeProductos item)
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
        /// Edit Producto
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Edit(BeProductos item)

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
