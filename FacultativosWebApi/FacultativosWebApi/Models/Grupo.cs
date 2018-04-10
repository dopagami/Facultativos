using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Grupo
    {
        public int IDGrupo { get; set; }
        public string Descripcion { get; set; }
        public int IDArea { get; set; }
        public int IDCuestionario { get; set; }
        public int Orden { get; set; }

        public List<Pregunta> Preguntas { get; set; }
    }
}