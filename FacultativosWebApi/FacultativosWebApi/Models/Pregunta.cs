using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Pregunta
    {
        public int IDPregunta { get; set; }
        public string Descripcion { get; set; }
        public int IDGupo { get; set; }
        public int IDArea { get; set; }
        public int IDCuestionario { get; set; }
        public int Orden { get; set; }
    }
}