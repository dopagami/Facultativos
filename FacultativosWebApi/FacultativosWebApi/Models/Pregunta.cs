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
    public class Pregunta
    {
        /// <summary>
        /// Identificador de la pregunta.
        /// </summary>
        public int IDPregunta { get; set; }
        /// <summary>
        /// Descripción de la pregunta.
        /// </summary>
        [Required]
        public string Descripcion { get; set; }
        /// <summary>
        /// Identificador del grupo de la pregunta.
        /// </summary>
        public int? IDGrupo { get; set; }
        /// <summary>
        /// Identificador del área de la pregunta.
        /// </summary>
        public int? IDArea { get; set; }
        /// <summary>
        /// Identificador del cuestionario de la pregunta.
        /// </summary>
        [Required]
        public int IDCuestionario { get; set; }
        /// <summary>
        /// Orden de la pregunta.
        /// </summary>
        [Required]
        public int Orden { get; set; }
    }
}