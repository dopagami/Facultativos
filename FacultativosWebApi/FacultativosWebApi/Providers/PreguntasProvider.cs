using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class PreguntasProvider
    {
        public IEnumerable<Pregunta> GetPreguntas()
        {
            try
            {
                return Converter.toPreguntas(DAL.DataService.Execute("SELECT * FROM MAESTROPREGUNTAS"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Pregunta GetPregunta(int id)
        {
            try
            {
                return Converter.toPreguntas(DAL.DataService.Execute("SELECT * FROM MAESTROPREGUNTAS" +
                                " WHERE IDPREGUNTA = :pID",
                                "pID", id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 PostPregunta(Pregunta pregunta)
        {
            try
            {
                return DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROPREGUNTAS(DESCRIPCION, IDGRUPO, IDAREA, IDCUESTIONARIO, ORDEN) " +
                                "VALUES(:pDesc, :pGrupo, :pArea, :pCuestionario, :pOrden) " +
                                "RETURNING IDPREGUNTA INTO :pIDRT",
                                "pDesc", pregunta.Descripcion,
                                "pGrupo", pregunta.IDGrupo,
                                "pArea", pregunta.IDArea,
                                "pCuestionario", pregunta.IDCuestionario,
                                "pOrden", pregunta.Orden,
                                "pIDRT");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 PutPregunta(Pregunta pregunta)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("UPDATE MAESTROPREGUNTAS " +
                                "SET DESCRIPCION = :pDesc, " +
                                " IDGRUPO = :pGrupo, " +
                                " IDAREA = :pArea, " +
                                " IDCUESTIONARIO = :pCuestionario, " +
                                " ORDEN = :pOrden " +
                                " WHERE IDPREGUNTA = :pID",
                                "pDesc", pregunta.Descripcion,
                                "pGrupo", pregunta.IDGrupo,
                                "pArea", pregunta.IDArea,
                                "pCuestionario", pregunta.IDCuestionario,
                                "pOrden", pregunta.Orden,
                                "pID", pregunta.IDPregunta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 DeletePregunta(int id)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("DELETE FROM MAESTROPREGUNTAS " +
                                " WHERE IDPREGUNTA = :pID",
                                "pID", id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}