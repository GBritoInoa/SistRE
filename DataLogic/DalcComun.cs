using BeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic
{
    public class DalcComun
    {


        /// <summary>
        /// Dalc Sexo
        /// </summary>
        /// <returns></returns>
        public List<BeSexo> GetSexo()
        {
            List<BeSexo> data = new List<BeSexo>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from s in db.Sexo
                                  where s.SexoID <= 4
                                  select new BeSexo()
                                  {
                                      SexoID = s.SexoID,
                                      Nombre = s.Nombre

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get Mienbro ERD
        /// </summary>
        /// <returns></returns>
        public BeMilitar GetMemberERD(int user)
        {
            var data = new List<BeMilitar>();
            try
            {
                using (var dbERD = new ContextDbERD())
                {
                    data.AddRange(from m in dbERD.Miembros
                                  join i in dbERD.Instituciones on m.InstitucionID equals i.InstitucionID
                                  join r in dbERD.Rangos on m.RangoID equals r.RangoID
                                   where m.numero_carnet == user

                                  select new BeMilitar()
                                  {
                                     Miembro  = m.Apellidos + "," + m.Nombres,
                                     Rango = r.nombre,
                                     RangoID = m.RangoID,
                                     InstitucionID = i.InstitucionID,
                                     Institucion = i.nombre,
                                     NumCarnet = m.numero_carnet,



                                  });

                };
                return data.FirstOrDefault();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        
        /// <summary>
        /// Dalc Provincias
        /// </summary>
        /// <returns></returns>
        public List<BeProvincias> GetProvincias()
        {
            List<BeProvincias> data = new List<BeProvincias>();
            try
            {
                using (var db = new ContextDbERD())
                {
                    data.AddRange(from c in db.Provincias
                                  select new BeProvincias()
                                  {
                                      ProvinciaID = c.ProvinciaID,
                                      Nombre = c.nombre,

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Dalc Compañías
        /// </summary>
        /// <returns></returns>
        public List<BeCompania> GetCompania()
        {
            List<BeCompania> data = new List<BeCompania>();
            try
            {
                using (var db = new ContextDbERD())
                {
                    data.AddRange(from c in db.Companias
                                  select new BeCompania()
                                  {
                                      CompaniaID = c.CompaniaID,
                                      Nombre = c.nombre,
                                      BatallonID = c.BatallonID

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Dalc Rangos
        /// </summary>
        /// <returns></returns>
        public List<BeRangos> GetRangos()
        {
            List<BeRangos> data = new List<BeRangos>();
            try
            {
                using (var db = new ContextDbERD())
                {
                    data.AddRange(from r in db.Rangos
                                  where r.RangoID <= 25
                                  select new BeRangos()
                                  {
                                      RangoID = r.RangoID,
                                      Rango = r.nombre

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Dalc Brigadas
        /// </summary>
        /// <returns></returns>
        public List<BeBrigada> GetBrigadas()
        {
            List<BeBrigada> data = new List<BeBrigada>();
            try
            {

                using (var db = new ContextDbERD())
                {
                    data.AddRange(from b in db.Unidades
                                  where b.nombre.Contains("Brigada")
                                  select new BeBrigada
                                  {
                                      UnidadID = b.UnidadID,
                                      Nombre = b.nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }


        public List<BeCategoriaProtesta> GetCategoriaProtesta()
        {
            List<BeCategoriaProtesta> data = new List<BeCategoriaProtesta>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from c in db.CategoriaProtesta
                                  select new BeCategoriaProtesta()
                                  {
                                      CategoriaProtestaID = c.CategoriaProtestaID,
                                      Nombre = c.Nombre,

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Get Tipo Protesta
        /// </summary>
        /// <returns></returns>
        public List<BeTipoProtesta> GetTipoProtesta()
        {
            List<BeTipoProtesta> data = new List<BeTipoProtesta>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from tp in db.TipoProtesta
                                   join a in db.Auditoria on
                                  tp.AuditoriaID equals a.AuditoriaID
                                  join e in db.Estatus
                                  on tp.EstatusID equals e.EstatusID
                                  where tp.EstatusID != 3
                                  select new BeTipoProtesta()

                                  {
                                      
                                      Nombre = tp.Nombre,
                                      TipoNovedadID = tp.TipoNovedadID,
                                      TipoProtestaID = tp.TipoProtestaID,
                                      EstatusID = tp.EstatusID,
                                      UsuarioCreo = a.UsuarioCreo,
                                      FechaCreo = a.FechaCreo,
                                      UsuarioActualizo = a.UsuarioActualizo,
                                      FechaActualizo = a.FechaActualizo,

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<BeProtestaConvocatoria> GetProtestaConvocatoria()
        {
            List<BeProtestaConvocatoria> data = new List<BeProtestaConvocatoria>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.ProtestaConvocatoria
                                  where b.Nombre.Contains("Nombre")
                                  select new BeProtestaConvocatoria
                                  {
                                      ProtestaConvocatoriaID = b.ProtestaConvocatoriaID,
                                      Nombre = b.Nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<BeInstitucionProtestante> GetInstitucionProtestante()
        {
            List<BeInstitucionProtestante> data = new List<BeInstitucionProtestante>();
            try
            {
                using (var db = new Context_SistRE())
                {
                    data.AddRange(from c in db.InstitucionProtestante
                                  select new BeInstitucionProtestante()
                                  {
                                      InstitucionProtestanteID = c.InstitucionProtestanteID,
                                      Nombre = c.Nombre,

                                  });
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<BeTipoDroga> GetTipoDroga()
        {
            List<BeTipoDroga> data = new List<BeTipoDroga>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.TipoDroga
                                  where b.Nombre.Contains("Nombre")
                                  select new BeTipoDroga
                                  {
                                      TipoDrogaID = b.TipoDrogaID,
                                      Nombre = b.Nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        //public List<BeTipoPerdidaDocumento> GetTipoPerdidaDocumento()
        //{
        //    List<BeTipoPerdidaDocumento> data = new List<BeTipoPerdidaDocumento>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.TipoPerdidaDocumento
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeTipoPerdidaDocumento
        //                          {
        //                              TipoPerdidaDocumentoID = b.TipoPerdidaDocumentoID,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        public List<BeTipoMedicamento> GetTipoMedicamento()
        {
            List<BeTipoMedicamento> data = new List<BeTipoMedicamento>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.TipoMedicamento
                                  where b.Nombre.Contains("Nombre")
                                  select new BeTipoMedicamento
                                  {
                                      TipoMedicamentoID = b.TipoMedicamentoID,
                                      Nombre = b.Nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public List<BeTipoContrabando> GetTipoContrabando()
        {
            List<BeTipoContrabando> data = new List<BeTipoContrabando>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.TipoContrabando
                                 
                                 where b.EstatusID == 1
                                  select new BeTipoContrabando
                                  {
                                      ID = b.TipoContrabandoID,                                      
                                      TipoProductoID = b.TipoProductoID

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public List<BeTipoFallecimiento> GetTipoFallecimiento()
        //{
        //    List<BeTipoFallecimiento> data = new List<BeTipoFallecimiento>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.TipoFallecimiento
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeTipoFallecimiento
        //                          {
        //                              TipoFallecimientoID = b.TipoFallecimientoD,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        //public List<BeTipoHospitalizacion> GetTipoHospitalizacion()
        //{
        //    List<BeTipoHospitalizacion> data = new List<BeTipoHospitalizacion>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.TipoHospitalizacion
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeTipoHospitalizacion
        //                          {
        //                              TipoHospitalizacionID = b.TipoHospitalizacionID,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        //public List<BeTipoEntrega> GetTipoEntrega()
        //{
        //    List<BeTipoEntrega> data = new List<BeTipoEntrega>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.TipoEntrega
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeTipoEntrega
        //                          {
        //                              TipoEntregaID = b.TipoEntregaID,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        //public List<BeTipoProtesta> GetTipoProtesta()
        //{
        //    List<BeTipoProtesta> data = new List<BeTipoProtesta>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.TipoProtesta
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeTipoProtesta
        //                          {
        //                              TipoProtestaID = b.TipoProtestaID,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        public List<BePais> GetPais()
        {
            List<BePais> data = new List<BePais>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.Pais
                                  where b.Nombre.Contains("Nombre")
                                  select new BePais
                                  {
                                      PaisID = b.PaisID,
                                      Nombre = b.Nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //public List<BeProtestaConvocatoria> GetProtestaConvocatoria()
        //{
        //    List<BeProtestaConvocatoria> data = new List<BeProtestaConvocatoria>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.ProtestaConvocatoria
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeProtestaConvocatoria
        //                          {
        //                              ProtestaConvocatoriaID = b.ProtestaConvocatoriaID,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        public List<BeNacionalidad> GetNacionalidad()
        {
            List<BeNacionalidad> data = new List<BeNacionalidad>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.Nacionalidad
                                  where b.Nombre.Contains("Nombre")
                                  select new BeNacionalidad
                                  {
                                      ID = b.NacionalidadID,
                                      Nombre = b.Nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        public List<BeTipoVehiculo> GetTipoVehiculo()
        {
            List<BeTipoVehiculo> data = new List<BeTipoVehiculo>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.TipoVehiculo
                                  where b.Nombre.Contains("Nombre")
                                  select new BeTipoVehiculo
                                  {
                                      TipoVehiculoID = b.TipoVehiculoID,
                                      Nombre = b.Nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //public List<BeTipoCausaMuerte> GetTipoCausaMuerte()
        //{
        //    List<BeTipoCausaMuerte> data = new List<BeTipoCausaMuerte>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.TipoCausaMuerte
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeTipoCausaMuerte
        //                          {
        //                              TipoCausaMuerteID = b.TipoCausaMuerteID,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        //public List<BeTipoCausaHerida> GetTipoCausaHerida()
        //{
        //    List<BeTipoCausaHerida> data = new List<BeTipoCausaHerida>();
        //    try
        //    {

        //        using (var db = new Context_SistRE())
        //        {
        //            data.AddRange(from b in db.TipoCausaHerida
        //                          where b.Nombre.Contains("Nombre")
        //                          select new BeTipoCausaHerida
        //                          {
        //                              TipoCausaHeridaID = b.TipoCausaHeridaID,
        //                              Nombre = b.Nombre

        //                          });
        //            return data.ToList();
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }

        //}

        public List<BeTipoIncautacion> GetTipoIncautacion()
        {
            List<BeTipoIncautacion> data = new List<BeTipoIncautacion>();
            try
            {

                using (var db = new Context_SistRE())
                {
                    data.AddRange(from b in db.TipoIncautacion
                                  join c in db.TipoNovedad
                                  on b.TipoNovedadID equals c.TipoNovedadID
                                  select new BeTipoIncautacion
                                  {
                                      ID = b.TipoIncautacionID,
                                      Nombre = c.Nombre

                                  });
                    return data.ToList();
                }

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
