using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class CuestionariosProvider
    {
        public IEnumerable<Cuestionario> GetCuestionarios()
        {
            return Converter.toCuestionarios(DAL.DataService.Execute("SELECT MC.IDCUESTIONARIO, " +
                "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, "+
                "NULL IDAREA, " +
                "NULL DESCRIPCIONAREA, " +
                "NULL IDGRUPO, " +
                "NULL DESCRIPCIONGRUPO, " +
                "NULL IDPREGUNTA, " +
                "NULL DESCRIPCIONPREGUNTA, " +
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

        public Cuestionario GetCuestionario(int id)
        {
            return Converter.toCuestionarios(DAL.DataService.Execute("SELECT MC.IDCUESTIONARIO, " +
                "MC.DESCRIPCION DESCRIPCIONCUESTIONARIO, " +
                "NULL IDAREA, " +
                "NULL DESCRIPCIONAREA, " +
                "NULL IDGRUPO, " +
                "NULL DESCRIPCIONGRUPO, " +
                "NULL IDPREGUNTA, " +
                "NULL DESCRIPCIONPREGUNTA, " +
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
                "ORDER BY IDCUESTIONARIO, NIVEL, ORDEN; ")).First();
        }
    }
}