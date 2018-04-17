﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Area
    {
        public int IDArea { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int IDCuestionario { get; set; }
        public int Orden { get; set; }

        public List<Grupo> Grupos { get; set; }

        public List<Pregunta> Preguntas { get; set; }
    }
}