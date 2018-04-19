using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Identificador del área.
        /// </summary>
        public int IDArea { get; set; }
        /// <summary>
        /// Descripción del área.
        /// </summary>
        [Required]
        public string Descripcion { get; set; }
        /// <summary>
        /// Identificador del cuestionario del área.
        /// </summary>
        [Required]
        public int IDCuestionario { get; set; }
        /// <summary>
        /// Orden del área.
        /// </summary>
        public int Orden { get; set; }
        /// <summary>
        /// Grupos del área.
        /// </summary>
        public List<Grupo> Grupos { get; set; }
        /// <summary>
        /// Preguntas del área.
        /// </summary>
        public List<Pregunta> Preguntas { get; set; }
    }
}