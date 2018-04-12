using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Pregunta
    {
        public int IDPregunta { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int? IDGupo { get; set; }
        public int? IDArea { get; set; }
        [Required]
        public int IDCuestionario { get; set; }
        [Required]
        public int Orden { get; set; }
    }
}