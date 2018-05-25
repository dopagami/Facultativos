using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class RespuestasProvider
    {
        public Int32 PostRespuesta(Respuesta respuesta)
        {
            try
            {
                return DAL.DataService.ExecuteNonQueryRV("INSERT INTO RESPUESTASFACULTATIVOSDPTO(IDPREGUNTA, IDPRIVILEGIO, OBSERVACIONES, IDFACULTATIVO, IDDEPARTAMENTO) " +
                                "VALUES(:pIDPreg, :pIDprivi, :pObserv, :pIDFacul, :pIDDpto) " +
                                "RETURNING IDRESPUESTASFACULTATIVOSDPTO INTO :pIDRT",
                                "pIDPreg", respuesta.IDPregunta,
                                "pIDprivi", respuesta.IDPrivilegio,
                                "pObserv", respuesta.ObservacionesRespuesta,
                                "pIDFacul", respuesta.IDFacultativo,
                                "pIDDpto", respuesta.IDDepartamento,
                                "pIDRT");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 PutRespuesta(Respuesta respuesta)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("UPDATE RESPUESTASFACULTATIVOSDPTO " +
                                "SET IDPRIVILEGIO = :pIDprivi, " +
                                "OBSERVACIONES = :pObserv " +
                                "WHERE IDRESPUESTASFACULTATIVOSDPTO = :pID",
                                "pIDprivi", respuesta.IDPrivilegio,
                                "pObserv", respuesta.ObservacionesRespuesta,
                                "pID", respuesta.IDRespuestaFacultativo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 DeleteRespuesta(int id)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("DELETE FROM RESPUESTASFACULTATIVOSDPTO " +
                                " WHERE IDRESPUESTASFACULTATIVOSDPTO = :pID",
                                "pID", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}