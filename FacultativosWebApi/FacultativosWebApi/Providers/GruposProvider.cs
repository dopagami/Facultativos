using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class GruposProvider
    {
        public IEnumerable<Grupo> GetGrupos()
        {
            return Converter.toGrupos(DAL.DataService.Execute("SELECT MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                        "MG.IDAREA IDAREA,MG.IDCUESTIONARIO IDCUESTIONARIO, " +
                        "NULL IDPREGUNTA, NULL DESCRIPCIONPREGUNTA, 1 NIVEL, MG.ORDEN ORDEN " +
                        "FROM MAESTROGRUPOS MG " +
                        "UNION ALL " +
                        "SELECT MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO," +
                        "MG.IDAREA IDAREA,MG.IDCUESTIONARIO IDCUESTIONARIO, " +
                        "MP.IDPREGUNTA, MP.DESCRIPCION DESCRIPCIONPREGUNTA, 2 NIVEL, MP.ORDEN ORDEN " +
                        "FROM MAESTROPREGUNTAS MP INNER JOIN MAESTROGRUPOS MG ON MP.IDGRUPO = MG.IDGRUPO " +
                        "ORDER BY IDGRUPO, NIVEL, ORDEN"));
        }

        public Grupo GetGrupo(int id)
        {
            return Converter.toGrupos(DAL.DataService.Execute("SELECT MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                        "MG.IDAREA IDAREA,MG.IDCUESTIONARIO IDCUESTIONARIO, " +
                        "NULL IDPREGUNTA, NULL DESCRIPCIONPREGUNTA, 1 NIVEL, MG.ORDEN ORDEN " +
                        "FROM MAESTROGRUPOS MG " +
                        " WHERE MG.IDGRUPO = :pID " +
                        "UNION ALL " +
                        "SELECT MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO," +
                        "MG.IDAREA IDAREA,MG.IDCUESTIONARIO IDCUESTIONARIO, " +
                        "MP.IDPREGUNTA, MP.DESCRIPCION DESCRIPCIONPREGUNTA, 2 NIVEL, MP.ORDEN ORDEN " +
                        "FROM MAESTROPREGUNTAS MP INNER JOIN MAESTROGRUPOS MG ON MP.IDGRUPO = MG.IDGRUPO " +
                        " WHERE MG.IDGRUPO = :pID " +
                        "ORDER BY IDGRUPO, NIVEL, ORDEN",
                        "pID", id)).FirstOrDefault();
        }
    }
}