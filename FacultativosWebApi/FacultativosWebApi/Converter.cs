﻿using FacultativosWebApi.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi
{
    public static class Converter
    {
        public static IEnumerable<Privilegio> toPrivilegios(DataTable dtPrivilegios) {

            var privilegios = new List<Privilegio>();
            foreach (DataRow row in dtPrivilegios.Rows)
            {
                var privilegio = new Privilegio();

                privilegio.IDPrivilegio = System.Convert.ToInt32(row["IDPRIVILEGIO"]);
                privilegio.Descripcion = System.Convert.ToString(row["DESCRIPCION"]);
                privilegio.Valor = System.Convert.ToString(row["VALOR"]);

                privilegios.Add(privilegio);
            }
            return privilegios.AsEnumerable();
        }

        public static IEnumerable<Cuestionario> toCuestionarios(DataTable dtCuestionarios)
        {

            List<Cuestionario> cuestionarios = new List<Cuestionario>();
            Cuestionario cuestionario = null; ;

            foreach (DataRow row in dtCuestionarios.Rows)
            {
                //Cuestionarios
                if (System.Convert.ToString(row["nivel"]) == "1")
                {
                    if (cuestionario != null) cuestionarios.Add(cuestionario);
                    cuestionario = new Cuestionario();

                    cuestionario.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

                    cuestionario.Descripcion = System.Convert.ToString(row["DESCRIPCIONCUESTIONARIO"]);

                    cuestionario.Areas = new List<Area>();

                    cuestionario.Grupos = new List<Grupo>();

                    cuestionario.Preguntas = new List<Pregunta>();
                }

                //Areas
                if (System.Convert.ToString(row["nivel"]) == "2")
                {                                        
                    Area area = new Area();

                    area.Grupos = new List<Grupo>();

                    area.Preguntas = new List<Pregunta>();

                    area.IDArea = System.Convert.ToInt32(row["IDAREA"]);

                    area.Descripcion = System.Convert.ToString(row["DESCRIPCIONAREA"]);

                    cuestionario.Areas.Add(area);

                }

                //Grupos
                if (System.Convert.ToString(row["nivel"]) == "3")
                {
                    Grupo grupo = new Grupo();

                    grupo.Preguntas = new List<Pregunta>();

                    grupo.IDGrupo = System.Convert.ToInt32(row["IDGRUPO"]);

                    grupo.Descripcion = System.Convert.ToString(row["DESCRIPCIONGRUPO"]);

                    //Si el grupo pertenece a un área se añade a ese área del cuestionario, si no se añade al cuestionario
                    if (!string.IsNullOrEmpty(row["IDAREA"].ToString())) {
                        Area area = cuestionario.Areas.Last();
                        area.Grupos.Add(grupo);
                    }
                    else
                    {
                        cuestionario.Grupos.Add(grupo);
                    }                    

                }

                //Privilegios
                if (System.Convert.ToString(row["nivel"]) == "4")
                {
                    Pregunta pregunta = new Pregunta();

                    pregunta.IDPregunta = System.Convert.ToInt32(row["IDPREGUNTA"]);

                    pregunta.Descripcion = System.Convert.ToString(row["DESCRIPCIONPREGUNTA"]);

                    //Si la pregunta no tiene ni grupo ni area se añade al cuestionario
                    if (string.IsNullOrEmpty(row["IDGRUPO"].ToString()) && string.IsNullOrEmpty(row["IDAREA"].ToString()))
                    {
                        cuestionario.Preguntas.Add(pregunta);
                    }
                    else
                    {   //si tiene grupo 
                        if (!string.IsNullOrEmpty(row["IDGRUPO"].ToString()))
                        {   //y tiene area se añade al grupo del area del cuestionario
                            if (!string.IsNullOrEmpty(row["IDAREA"].ToString()))
                            {
                                Area area = cuestionario.Areas.Last();
                                Grupo grupo = area.Grupos.Last();
                                grupo.Preguntas.Add(pregunta);
                            }
                            else //si no tiene area se añade al grupo del cuestionario
                            {
                                Grupo grupo = cuestionario.Grupos.Last();
                                grupo.Preguntas.Add(pregunta);
                            }                            
                        }//si no tiene grupo y tiene area, se añade al area del cuestionario
                        else
                        {
                            Area area = cuestionario.Areas.Last();
                            area.Preguntas.Add(pregunta);
                        }
                    }                    

                }
            }

            if (cuestionario != null) cuestionarios.Add(cuestionario);
            return cuestionarios.AsEnumerable();
        }
    }
}