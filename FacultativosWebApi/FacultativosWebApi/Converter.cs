using FacultativosWebApi.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi
{
    public static class Converter
    {
        public static IEnumerable<Privilegio> toPrivilegios(DataTable dtPrivilegios)
        {
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
            Cuestionario cuestionario = null;

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

                    area.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

                    cuestionario.Areas.Add(area);
                }

                //Grupos
                if (System.Convert.ToString(row["nivel"]) == "3")
                {
                    Grupo grupo = new Grupo();

                    grupo.Preguntas = new List<Pregunta>();

                    grupo.IDGrupo = System.Convert.ToInt32(row["IDGRUPO"]);

                    grupo.Descripcion = System.Convert.ToString(row["DESCRIPCIONGRUPO"]);

                    grupo.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

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

                //Preguntas
                if (System.Convert.ToString(row["nivel"]) == "4")
                {
                    Pregunta pregunta = new Pregunta();

                    pregunta.IDPregunta = System.Convert.ToInt32(row["IDPREGUNTA"]);

                    pregunta.Descripcion = System.Convert.ToString(row["DESCRIPCIONPREGUNTA"]);

                    pregunta.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

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

        public static IEnumerable<Pregunta> toPreguntas(DataTable dtPreguntas)
        {
            var preguntas = new List<Pregunta>();
            foreach (DataRow row in dtPreguntas.Rows)
            {
                var pregunta = new Pregunta();

                pregunta.IDPregunta = System.Convert.ToInt32(row["IDPREGUNTA"]);
                pregunta.Descripcion = System.Convert.ToString(row["DESCRIPCION"]);
                if (!Convert.IsDBNull(row["IDGRUPO"]))
                    pregunta.IDGrupo = System.Convert.ToInt32(row["IDGRUPO"]);
                if (!Convert.IsDBNull(row["IDAREA"]))
                    pregunta.IDArea = System.Convert.ToInt32(row["IDAREA"]);
                if (!Convert.IsDBNull(row["IDCUESTIONARIO"]))
                    pregunta.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);
                pregunta.Orden = System.Convert.ToInt32(row["ORDEN"]);

                preguntas.Add(pregunta);
            }
            return preguntas.AsEnumerable();
        }

        public static IEnumerable<Grupo> toGrupos(DataTable dtGrupos)
        {
            List<Grupo> grupos = new List<Grupo>();
            Grupo grupo = null;
            foreach (DataRow row in dtGrupos.Rows)
            {
                //Grupos
                if (System.Convert.ToString(row["nivel"]) == "1")
                {
                    grupo = new Grupo();

                    grupo.Preguntas = new List<Pregunta>();

                    grupo.IDGrupo = System.Convert.ToInt32(row["IDGRUPO"]);

                    grupo.Descripcion = System.Convert.ToString(row["DESCRIPCIONGRUPO"]);

                    if (!Convert.IsDBNull(row["IDAREA"]))
                        grupo.IDArea = System.Convert.ToInt32(row["IDAREA"]);

                    grupo.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

                    grupos.Add(grupo);
                }

                //Preguntas
                if (System.Convert.ToString(row["nivel"]) == "2")
                {
                    Pregunta pregunta = new Pregunta();

                    pregunta.IDPregunta = System.Convert.ToInt32(row["IDPREGUNTA"]);

                    pregunta.Descripcion = System.Convert.ToString(row["DESCRIPCIONPREGUNTA"]);

                    pregunta.IDGrupo = System.Convert.ToInt32(row["IDGRUPO"]);

                    if (!Convert.IsDBNull(row["IDAREA"]))
                        pregunta.IDArea = System.Convert.ToInt32(row["IDAREA"]);

                    pregunta.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

                    grupo.Preguntas.Add(pregunta);
                }
            }
            return grupos.AsEnumerable();
        }

        public static IEnumerable<Area> toAreas(DataTable dtAreas)
        {
            List<Area> areas = new List<Area>();
            Area area = null;
            foreach (DataRow row in dtAreas.Rows)
            {
                //Areas
                if (System.Convert.ToString(row["nivel"]) == "1")
                {
                    area = new Area();

                    area.Grupos = new List<Grupo>();

                    area.Preguntas = new List<Pregunta>();

                    area.IDArea = System.Convert.ToInt32(row["IDAREA"]);

                    area.Descripcion = System.Convert.ToString(row["DESCRIPCIONAREA"]);

                    area.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

                    areas.Add(area);
                }

                //Grupos
                if (System.Convert.ToString(row["nivel"]) == "2")
                {
                    Grupo grupo = new Grupo();

                    grupo.Preguntas = new List<Pregunta>();

                    grupo.IDGrupo = System.Convert.ToInt32(row["IDGRUPO"]);

                    grupo.Descripcion = System.Convert.ToString(row["DESCRIPCIONGRUPO"]);

                    if (!Convert.IsDBNull(row["IDAREA"]))
                        grupo.IDArea = System.Convert.ToInt32(row["IDAREA"]);

                    grupo.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

                    area.Grupos.Add(grupo);
                }

                //Preguntas
                if (System.Convert.ToString(row["nivel"]) == "3")
                {
                    Pregunta pregunta = new Pregunta();

                    pregunta.IDPregunta = System.Convert.ToInt32(row["IDPREGUNTA"]);

                    pregunta.Descripcion = System.Convert.ToString(row["DESCRIPCIONPREGUNTA"]);

                    if (!Convert.IsDBNull(row["IDGRUPO"]))
                        pregunta.IDGrupo = System.Convert.ToInt32(row["IDGRUPO"]);

                    if (!Convert.IsDBNull(row["IDAREA"]))
                        pregunta.IDArea = System.Convert.ToInt32(row["IDAREA"]);

                    pregunta.IDCuestionario = System.Convert.ToInt32(row["IDCUESTIONARIO"]);

                    //Si el grupo pertenece a un área se añade a ese área del cuestionario, si no se añade al cuestionario
                    if (!string.IsNullOrEmpty(row["IDGRUPO"].ToString()))
                    {
                        Grupo Grupo = area.Grupos.Last();
                        Grupo.Preguntas.Add(pregunta);
                    }
                    else
                    {
                        area.Preguntas.Add(pregunta);
                    }                    
                }
            }
            return areas.AsEnumerable();
        }

        public static IEnumerable<Facultativo> toFacultativos(DataTable dtFacultativos)
        {
            var facultativos = new List<Facultativo>();
            foreach (DataRow row in dtFacultativos.Rows)
            {
                var facultativo = new Facultativo();

                facultativo.IDFacultativo = System.Convert.ToString(row["SG02COD"]);
                facultativo.Nombre = System.Convert.ToString(row["SG02NOM"]);
                facultativo.Apellido1 = System.Convert.ToString(row["SG02APE1"]);
                facultativo.Apellido2 = System.Convert.ToString(row["SG02APE2"]);
                if (!Convert.IsDBNull(row["SG02NUMCOLEGIADO"]))
                    facultativo.NumColegiado = System.Convert.ToInt32(row["SG02NUMCOLEGIADO"]);
                facultativo.Categoria = System.Convert.ToString(row["AD30DESCATEGORIA"]);
                facultativo.Puesto = System.Convert.ToString(row["AD31DESPUESTO"]);
                facultativo.IDDepartamento = System.Convert.ToInt32(row["AD02CODDPTO"]);
                facultativo.Departamento = System.Convert.ToString(row["AD02DESDPTO"]);
                facultativo.Centro = System.Convert.ToString(row["AD74DESCENTRO"]);
                facultativo.email = System.Convert.ToString(row["SG02EMAIL"]);
                facultativo.CodRecurso = System.Convert.ToString(row["AG11CODRECURSO"]);

                facultativos.Add(facultativo);
            }
            return facultativos.AsEnumerable();
        }
    }
}