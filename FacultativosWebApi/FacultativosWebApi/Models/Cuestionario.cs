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
    public class Cuestionario
    {
        /// <summary>
        /// Identificador del cuestionario.
        /// </summary>
        public int IDCuestionario { get; set; }
        /// <summary>
        /// Descripción del cuestionario.
        /// </summary>
        [Required]
        public string Descripcion { get; set; }
        /// <summary>
        /// Identificador del departamento al que pertenece el cuestionario.
        /// </summary>
        [Required]
        public int IDDepartamento { get; set; }
        /// <summary>
        /// Areas del cuestionario.
        /// </summary>
        public List<Area> Areas { get; set; }
        /// <summary>
        /// Grupos del cuestionario.
        /// </summary>
        public List<Grupo> Grupos { get; set; }
        /// <summary>
        /// Preguntas del cuestionario.
        /// </summary>
        public List<Pregunta> Preguntas { get; set; }
    }
}