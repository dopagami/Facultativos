using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Cuestionario
    {
        public int IDCuestionario { get; set; }
        [Required]
        public string Descripcion { get; set; }

        public List<Area> Areas { get; set; }

        public List<Grupo> Grupos { get; set; }

        public List<Pregunta> Preguntas { get; set; }
    }
}