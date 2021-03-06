﻿using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class GruposProvider
    {
        public IEnumerable<Grupo> GetGrupos()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Grupo GetGrupo(int id)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 PostGrupo(Grupo grupo)
        {
            try
            {                
                Int32 IDGrupo = DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROGRUPOS(DESCRIPCION, IDAREA, IDCUESTIONARIO, ORDEN) " +
                        "VALUES(:pDesc, :pArea, :pCuestionario, :pOrden) " +
                        "RETURNING IDGRUPO INTO :pIDRT",
                        "pDesc", grupo.Descripcion,
                        "pArea", grupo.IDArea,
                        "pCuestionario", grupo.IDCuestionario,
                        "pOrden", grupo.Orden,
                        "pIDRT");                

                if (grupo.Preguntas != null)
                {
                    PreguntasProvider pPreguntas = new PreguntasProvider();

                    foreach (Pregunta pregunta in grupo.Preguntas)
                    {
                        pregunta.IDGrupo = IDGrupo;
                        pregunta.IDArea = grupo.IDArea;
                        pregunta.IDCuestionario = grupo.IDCuestionario;
                        pregunta.IDPregunta = pPreguntas.PostPregunta(pregunta);
                    }
                }                
                
                return IDGrupo;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Int32 PutGrupo(Grupo grupo)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("UPDATE MAESTROGRUPOS " +
                                "SET DESCRIPCION = :pDesc, " +
                                " IDAREA = :pArea, " +
                                " IDCUESTIONARIO = :pCuestionario, " +
                                " ORDEN = :pOrden " +
                                " WHERE IDGRUPO = :pID",
                                "pDesc", grupo.Descripcion,
                                "pArea", grupo.IDArea,
                                "pCuestionario", grupo.IDCuestionario,
                                "pOrden", grupo.Orden,
                                "pID", grupo.IDGrupo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 DeleteGrupo(int id)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("DELETE FROM MAESTROGRUPOS " +
                                " WHERE IDGRUPO = :pID",
                                "pID", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}