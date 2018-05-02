using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class AreasProvider
    {
        public IEnumerable<Area> GetAreas()
        {
            try
            {
                return Converter.toAreas(DAL.DataService.Execute("SELECT MA.IDAREA, " +
                                "MA.DESCRIPCION DESCRIPCIONAREA, MA.IDCUESTIONARIO IDCUESTIONARIO, NULL IDGRUPO, NULL DESCRIPCIONGRUPO, NULL IDPREGUNTA, " +
                                "NULL DESCRIPCIONPREGUNTA, 1 NIVEL, MA.ORDEN ORDEN " +
                                "FROM MAESTROAREAS MA " +
                                "UNION ALL " +
                                "SELECT MA.IDAREA, " +
                                "MA.DESCRIPCION DESCRIPCIONAREA, MA.IDCUESTIONARIO IDCUESTIONARIO, MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                                "NULL IDPREGUNTA, NULL DESCRIPCIONPREGUNTA, 2 NIVEL, MG.ORDEN ORDEN " +
                                "FROM MAESTROGRUPOS MG " +
                                "INNER JOIN MAESTROAREAS MA " +
                                "ON MG.IDAREA = MA.IDAREA " +
                                "UNION ALL " +
                                "SELECT MA.IDAREA, " +
                                "MA.DESCRIPCION DESCRIPCIONAREA, MA.IDCUESTIONARIO IDCUESTIONARIO, MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                                "MP.IDPREGUNTA, MP.DESCRIPCION DESCRIPCIONPREGUNTA, 3 NIVEL, MP.ORDEN ORDEN " +
                                "FROM MAESTROPREGUNTAS MP " +
                                "INNER JOIN MAESTROGRUPOS MG " +
                                "ON MP.IDGRUPO = MG.IDGRUPO " +
                                "INNER JOIN MAESTROAREAS MA " +
                                "ON MP.IDAREA = MA.IDAREA " +
                                "ORDER BY IDAREA, NIVEL, ORDEN"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Area GetArea(int id)
        {
            try
            {
                return Converter.toAreas(DAL.DataService.Execute("SELECT MA.IDAREA, " +
                                "MA.DESCRIPCION DESCRIPCIONAREA, MA.IDCUESTIONARIO IDCUESTIONARIO, NULL IDGRUPO, NULL DESCRIPCIONGRUPO, NULL IDPREGUNTA, " +
                                "NULL DESCRIPCIONPREGUNTA, 1 NIVEL, MA.ORDEN ORDEN " +
                                "FROM MAESTROAREAS MA " +
                                "WHERE MA.IDAREA = :pID " +
                                "UNION ALL " +
                                "SELECT MA.IDAREA, " +
                                "MA.DESCRIPCION DESCRIPCIONAREA, MA.IDCUESTIONARIO IDCUESTIONARIO, MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                                "NULL IDPREGUNTA, NULL DESCRIPCIONPREGUNTA, 2 NIVEL, MG.ORDEN ORDEN " +
                                "FROM MAESTROGRUPOS MG " +
                                "INNER JOIN MAESTROAREAS MA " +
                                "ON MG.IDAREA = MA.IDAREA " +
                                "WHERE MA.IDAREA = :pID " +
                                "UNION ALL " +
                                "SELECT MA.IDAREA, " +
                                "MA.DESCRIPCION DESCRIPCIONAREA, MA.IDCUESTIONARIO IDCUESTIONARIO, MG.IDGRUPO, MG.DESCRIPCION DESCRIPCIONGRUPO, " +
                                "MP.IDPREGUNTA, MP.DESCRIPCION DESCRIPCIONPREGUNTA, 3 NIVEL, MP.ORDEN ORDEN " +
                                "FROM MAESTROPREGUNTAS MP " +
                                "INNER JOIN MAESTROGRUPOS MG " +
                                "ON MP.IDGRUPO = MG.IDGRUPO " +
                                "INNER JOIN MAESTROAREAS MA " +
                                "ON MP.IDAREA = MA.IDAREA " +
                                "WHERE MA.IDAREA = :pID " +
                                "ORDER BY IDAREA, NIVEL, ORDEN",
                                "pID", id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 PostArea(Area area)
        {

            try
            {                

                Int32 IDArea = DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROAREAS(DESCRIPCION, IDCUESTIONARIO, ORDEN) " +
                        "VALUES(:pDesc, :pCuestionario, :pOrden) " +
                        "RETURNING IDAREA INTO :pIDRT",
                        "pDesc", area.Descripcion,
                        "pCuestionario", area.IDCuestionario,
                        "pOrden", area.Orden,
                        "pIDRT");                

                if (area.Grupos != null)
                {
                    GruposProvider pGrupos = new GruposProvider();

                    foreach (Grupo grupo in area.Grupos)
                    {
                        grupo.IDArea = IDArea;
                        grupo.IDCuestionario = area.IDCuestionario;
                        grupo.IDGrupo = pGrupos.PostGrupo(grupo);
                    };
                }                

                if (area.Preguntas != null)
                {
                    PreguntasProvider pPreguntasArea = new PreguntasProvider();

                    foreach (Pregunta pregunta in area.Preguntas)
                    {
                        pregunta.IDArea = IDArea;
                        pregunta.IDCuestionario = area.IDCuestionario;
                        pregunta.IDPregunta = pPreguntasArea.PostPregunta(pregunta);
                    };
                }
               
                return IDArea;

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Int32 PutArea(Area area)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("UPDATE MAESTROAREAS " +
                                "SET DESCRIPCION = :pDesc, " +
                                " IDCUESTIONARIO = :pCuestionario, " +
                                " ORDEN = :pOrden " +
                                " WHERE IDAREA = :pID",
                                "pDesc", area.Descripcion,
                                "pCuestionario", area.IDCuestionario,
                                "pOrden", area.Orden,
                                "pID", area.IDArea);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 DeleteArea(int id)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("DELETE FROM MAESTROAREAS " +
                                " WHERE IDAREA = :pID",
                                "pID", id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}