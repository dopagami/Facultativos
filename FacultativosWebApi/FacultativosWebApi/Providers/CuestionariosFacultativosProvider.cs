using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class CuestionariosFacultativosProvider
    {
        /// <summary>
        /// Looks up some data by ID.
        /// </summary>
        /// <param name="idFacultativo">ID del facultativo</param>
        /// <param name="idDpto">ID del departamento</param>
        public Cuestionario GetCuestionarioFacultativo(int idFacultativo, int idDpto)
        {
            try
            {
                return Converter.toCuestionariosFacultativos(DAL.DataService.Execute("SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "NULL IDAREA, " +
                        "NULL DESCRIPCIONAREA, " +
                        "NULL IDGRUPO, " +
                        "NULL DESCRIPCIONGRUPO, " +
                        "NULL IDPREGUNTA, " +
                        "NULL DESCRIPCIONPREGUNTA, " +
                        "MC.IDDEPARTAMENTO IDDEPARTAMENTO, " +
                        "NULL RESPUESTAPREGUNTA, " +
                        "NULL IDRESPUESTAPREGUNTA, " +
                        "1 NIVEL, " +
                        "NULL ORDEN " +
                        "FROM MAESTROCUESTIONARIOS MC INNER JOIN CUESTIONARIOSFACULTATIVOSDPTO C " +
                        "ON MC.IDCUESTIONARIO = C.IDCUESTIONARIO " +
                        "WHERE C.IDFACULTATIVO = " + idFacultativo.ToString() + " " +
                        "AND C.IDDEPARTAMENTO = " + idDpto.ToString() + " " +
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
                        "NULL RESPUESTAPREGUNTA, " +
                        "NULL IDRESPUESTAPREGUNTA, " +
                        "2 NIVEL, " +
                        "MA.ORDEN ORDEN " +
                        "FROM MAESTROAREAS MA INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MA.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "INNER JOIN CUESTIONARIOSFACULTATIVOSDPTO C " +
                        "ON MC.IDCUESTIONARIO = C.IDCUESTIONARIO " +
                        "WHERE C.IDFACULTATIVO = " + idFacultativo.ToString() + " " +
                        "AND C.IDDEPARTAMENTO = " + idDpto.ToString() + " " +
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
                        "NULL RESPUESTAPREGUNTA, " +
                        "NULL IDRESPUESTAPREGUNTA, " +
                        "3 NIVEL, " +
                        "MG.ORDEN ORDEN " +
                        "FROM MAESTROGRUPOS MG " +
                        "LEFT JOIN MAESTROAREAS MA " +
                        "ON MG.IDAREA = MA.IDAREA " +
                        "INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MG.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "INNER JOIN CUESTIONARIOSFACULTATIVOSDPTO C " +
                        "ON MC.IDCUESTIONARIO = C.IDCUESTIONARIO " +
                        "WHERE C.IDFACULTATIVO = " + idFacultativo.ToString() + " " +
                        "AND C.IDDEPARTAMENTO = " + idDpto.ToString() + " " +
                        "UNION ALL " +
                        "SELECT MC.IDCUESTIONARIO, " +
                        "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                        "MA.IDAREA, " +
                        "MA.DESCRIPCION DESCRIPCIONAREA, " +
                        "MG.IDGRUPO, " +
                        "MG.DESCRIPCION " +
                        "DESCRIPCIONGRUPO, " +
                        "MP.IDPREGUNTA, " +
                        "MP.DESCRIPCION DESCRIPCIONPREGUNTA, " +
                        "NULL IDDEPARTAMENTO, " +
                        "MPR.DESCRIPCION RESPUESTAPREGUNTA, " +
                        "R.IDRESPUESTASFACULTATIVOSDPTO IDRESPUESTAPREGUNTA, " +
                        "4 NIVEL, " +
                        "MP.ORDEN ORDEN " +
                        "FROM MAESTROPREGUNTAS MP " +
                        "LEFT JOIN MAESTROGRUPOS MG " +
                        "ON MP.IDGRUPO = MG.IDGRUPO " +
                        "LEFT JOIN MAESTROAREAS MA " +
                        "ON MP.IDAREA = MA.IDAREA " +
                        "INNER JOIN MAESTROCUESTIONARIOS MC " +
                        "ON MP.IDCUESTIONARIO = MC.IDCUESTIONARIO " +
                        "INNER JOIN CUESTIONARIOSFACULTATIVOSDPTO C " +
                        "ON MC.IDCUESTIONARIO = C.IDCUESTIONARIO " +
                        "LEFT JOIN RESPUESTASFACULTATIVOSDPTO R " +
                        "ON R.IDPREGUNTA = MP.IDPREGUNTA " +
                        "AND R.IDDEPARTAMENTO = C.IDDEPARTAMENTO " +
                        "AND R.IDFACULTATIVO = C.IDFACULTATIVO " +
                        "LEFT JOIN MAESTROPRIVILEGIOS MPR " +
                        "ON R.IDPRIVILEGIO = MPR.IDPRIVILEGIO " +
                        "WHERE C.IDFACULTATIVO = " + idFacultativo.ToString() + " " +
                        "AND C.IDDEPARTAMENTO = " + idDpto.ToString() + " " +
                        "ORDER BY IDCUESTIONARIO, NIVEL, ORDEN; ")).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}