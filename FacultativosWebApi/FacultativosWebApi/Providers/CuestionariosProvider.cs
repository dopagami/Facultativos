using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    /// <summary>
    /// Controlador de cuestionarios.
    /// </summary>
    public class CuestionariosProvider
    {
        /// <summary>
        /// Looks up some data by ID.
        /// </summary>
        public IEnumerable<Cuestionario> GetCuestionarios()
        {
            try
            {
                return Converter.toCuestionarios(DAL.DataService.Execute("SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "NULL IDAREA, " +
                        "NULL DESCRIPCIONAREA, " +
                        "NULL IDGRUPO, " +
                        "NULL DESCRIPCIONGRUPO, " +
                        "NULL IDPREGUNTA, " +
                        "NULL DESCRIPCIONPREGUNTA, " +
                        "MC.IDDEPARTAMENTO IDDEPARTAMENTO, " +
                        "1 NIVEL, " +
                        "NULL ORDEN " +
                        "FROM MAESTROCUESTIONARIOS MC " +
                        "UNION ALL " +
                        "SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "MA.IDAREA, " +
                        "MA.DESCRIPCION DESCRIPCIONAREA, " +
                        "NULL IDGRUPO, " +
                        "NULL DESCRIPCIONGRUPO, " +
                        "NULL IDPREGUNTA, " +
                        "NULL DESCRIPCIONPREGUNTA, " +
                        "NULL IDDEPARTAMENTO, " +
                        "2 NIVEL, " +
                        "MA.ORDEN ORDEN " +
                        "FROM MAESTROAREAS MA INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MA.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "UNION ALL " +
                        "SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "MA.IDAREA, " +
                        "MA.DESCRIPCION DESCRIPCIONAREA, " +
                        "MG.IDGRUPO, " +
                        "MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                        "NULL IDPREGUNTA, " +
                        "NULL DESCRIPCIONPREGUNTA, " +
                        "NULL IDDEPARTAMENTO, " +
                        "3 NIVEL, " +
                        "MG.ORDEN ORDEN " +
                        "FROM MAESTROGRUPOS MG " +
                        "LEFT JOIN MAESTROAREAS MA " +
                        "ON MG.IDAREA = MA.IDAREA " +
                        "INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MG.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "UNION ALL " +
                        "SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "MA.IDAREA, " +
                        "MA.DESCRIPCION DESCRIPCIONAREA, " +
                        "MG.IDGRUPO, " +
                        "MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                        "MP.IDPREGUNTA, " +
                        "MP.DESCRIPCION DESCRIPCIONPREGUNTA, " +
                        "NULL IDDEPARTAMENTO, " +
                        "4 NIVEL, " +
                        "MP.ORDEN ORDEN " +
                        "FROM MAESTROPREGUNTAS MP " +
                        "LEFT JOIN MAESTROGRUPOS MG " +
                        "ON MP.IDGRUPO = MG.IDGRUPO " +
                        "LEFT JOIN MAESTROAREAS MA " +
                        "ON MP.IDAREA = MA.IDAREA " +
                        "INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MP.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "ORDER BY IDCUESTIONARIO, NIVEL, ORDEN; "));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Looks up some data by ID.
        /// </summary>
        /// <param name="id">The ID of the data.</param>
        public Cuestionario GetCuestionario(int id)
        {
            try
            {
                return Converter.toCuestionarios(DAL.DataService.Execute("SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "NULL IDAREA, " +
                        "NULL DESCRIPCIONAREA, " +
                        "NULL IDGRUPO, " +
                        "NULL DESCRIPCIONGRUPO, " +
                        "NULL IDPREGUNTA, " +
                        "NULL DESCRIPCIONPREGUNTA, " +
                        "MC.IDDEPARTAMENTO IDDEPARTAMENTO, " +
                        "1 NIVEL, " +
                        "NULL ORDEN " +
                        "FROM MAESTROCUESTIONARIOS MC " +
                        "WHERE MC.IDCUESTIONARIO = " + id.ToString() + " " +
                        "UNION ALL " +
                        "SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "MA.IDAREA, " +
                        "MA.DESCRIPCION DESCRIPCIONAREA, " +
                        "NULL IDGRUPO, " +
                        "NULL DESCRIPCIONGRUPO, " +
                        "NULL IDPREGUNTA, " +
                        "NULL DESCRIPCIONPREGUNTA, " +
                        "NULL IDDEPARTAMENTO, " +
                        "2 NIVEL, " +
                        "MA.ORDEN ORDEN " +
                        "FROM MAESTROAREAS MA INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MA.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "WHERE MC.IDCUESTIONARIO = " + id.ToString() + " " +
                        "UNION ALL " +
                        "SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "MA.IDAREA, " +
                        "MA.DESCRIPCION DESCRIPCIONAREA, " +
                        "MG.IDGRUPO, " +
                        "MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                        "NULL IDPREGUNTA, " +
                        "NULL DESCRIPCIONPREGUNTA, " +
                        "NULL IDDEPARTAMENTO, " +
                        "3 NIVEL, " +
                        "MG.ORDEN ORDEN " +
                        "FROM MAESTROGRUPOS MG " +
                        "LEFT JOIN MAESTROAREAS MA " +
                        "ON MG.IDAREA = MA.IDAREA " +
                        "INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MG.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "WHERE MC.IDCUESTIONARIO = " + id.ToString() + " " +
                        "UNION ALL " +
                        "SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "MA.IDAREA, " +
                        "MA.DESCRIPCION DESCRIPCIONAREA, " +
                        "MG.IDGRUPO, " +
                        "MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                        "MP.IDPREGUNTA, " +
                        "MP.DESCRIPCION DESCRIPCIONPREGUNTA, " +
                        "NULL IDDEPARTAMENTO, " +
                        "4 NIVEL, " +
                        "MP.ORDEN ORDEN " +
                        "FROM MAESTROPREGUNTAS MP " +
                        "LEFT JOIN MAESTROGRUPOS MG " +
                        "ON MP.IDGRUPO = MG.IDGRUPO " +
                        "LEFT JOIN MAESTROAREAS MA " +
                        "ON MP.IDAREA = MA.IDAREA " +
                        "INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MP.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "WHERE MC.IDCUESTIONARIO = " + id.ToString() + " " +
                        "ORDER BY IDCUESTIONARIO, NIVEL, ORDEN; ")).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Looks up some data by ID.
        /// </summary>
        public Int32 PostCuestionario(Cuestionario cuestionario)
        {
            try
            {
                Int32 IDCuestionario = DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROCUESTIONARIOS(DESCRIPCION, IDDEPARTAMENTO) " +
                        "VALUES(:pDesc, :pDepartamento) " +
                        "RETURNING IDCUESTIONARIO INTO :pIDRT",
                        "pDesc", cuestionario.Descripcion,
                        "pDepartamento", cuestionario.IDDepartamento,
                        "pIDRT");

                //Areas
                if (cuestionario.Areas != null)
                {
                    AreasProvider pAreas = new AreasProvider();

                    foreach (Area area in cuestionario.Areas)
                    {
                        area.IDCuestionario = IDCuestionario;
                        area.IDArea = pAreas.PostArea(area);
                    }
                }

                //Grupos
                if (cuestionario.Grupos != null)
                {
                    GruposProvider pGrupos = new GruposProvider();

                    foreach (Grupo grupo in cuestionario.Grupos)
                    {
                        grupo.IDCuestionario = IDCuestionario;
                        grupo.IDGrupo = pGrupos.PostGrupo(grupo);                        
                    }
                }

                //Preguntas
                if (cuestionario.Preguntas != null)
                {
                    PreguntasProvider pPreguntas = new PreguntasProvider();

                    foreach (Pregunta pregunta in cuestionario.Preguntas)
                    {
                        pregunta.IDCuestionario = IDCuestionario;
                        pregunta.IDPregunta = pPreguntas.PostPregunta(pregunta);
                    }
                }

                return IDCuestionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Looks up some data by ID.
        /// </summary>
        public Int32 PutCuestionario(Cuestionario cuestionario)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("UPDATE MAESTROCUESTIONARIOS " +
                                "SET DESCRIPCION = :pDesc, " +
                                " IDDEPARTAMENTO = :pDepartamento " +
                                " WHERE IDCUESTIONARIO = :pID",
                                "pDesc", cuestionario.Descripcion,
                                "pDepartamento", cuestionario.IDDepartamento,
                                "pID", cuestionario.IDCuestionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Looks up some data by ID.
        /// </summary>
        public Int32 DeleteCuestionario(int id)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("DELETE FROM MAESTROCUESTIONARIOS " +
                                " WHERE IDCUESTIONARIO = :pID",
                                "pID", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}