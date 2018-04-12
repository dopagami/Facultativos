using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class PreguntasProvider
    {
        public IEnumerable<Pregunta> GetPreguntas()
        {
            return Converter.toPreguntas(DAL.DataService.Execute("SELECT * FROM MAESTROPREGUNTAS"));
        }

        public Pregunta GetPregunta(int id)
        {
            return Converter.toPreguntas(DAL.DataService.Execute("SELECT * FROM MAESTROPREGUNTAS" +
                        " WHERE IDPREGUNTA = :pID",
                        "pID", id)).FirstOrDefault();
        }

        public Int32 PostPregunta(Pregunta pregunta)
        {
            return DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROPREGUNTAS(DESCRIPCION, IDGRUPO, IDAREA, IDCUESTIONARIO, ORDEN) " +
                        "VALUES(:pDesc, :pGrupo, :pArea, :pCuestionario, :pOrden) " +
                        "RETURNING IDPREGUNTA INTO :pIDRT",
                        "pDesc", pregunta.Descripcion,
                        "pGrupo", pregunta.IDGupo,
                        "pArea", pregunta.IDArea,
                        "pCuestionario", pregunta.IDCuestionario,
                        "pOrden", pregunta.Orden,
                        "pIDRT");
        }

        public Int32 PutPregunta(Pregunta pregunta)
        {
            return DAL.DataService.ExecuteNonQuery("UPDATE MAESTROPREGUNTAS " +
                        "SET DESCRIPCION = :pDesc, " +
                        " IDGRUPO = :pGrupo, " +
                        " IDAREA = :pArea, " +
                        " IDCUESTIONARIO = :pCuestionario, " +
                        " ORDEN = :pOrden " +
                        " WHERE IDPREGUNTA = :pID",
                        "pDesc", pregunta.Descripcion,
                        "pGrupo", pregunta.IDGupo,
                        "pArea", pregunta.IDArea,
                        "pCuestionario", pregunta.IDCuestionario,
                        "pOrden", pregunta.Orden,
                        "pID", pregunta.IDPregunta);
        }

        public Int32 DeletePregunta(int id)
        {
            return DAL.DataService.ExecuteNonQuery("DELETE FROM MAESTROPREGUNTAS " +
                        " WHERE IDPREGUNTA = :pID",
                        "pID", id);
        }
    }
}