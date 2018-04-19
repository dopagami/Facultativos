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
    public class Grupo
    {
        /// <summary>
        /// Identificador del grupo.
        /// </summary>
        public int IDGrupo { get; set; }
        /// <summary>
        /// Descripción del grupo.
        /// </summary>
        [Required]
        public string Descripcion { get; set; }
        /// <summary>
        /// Identificador del área del grupo.
        /// </summary>
        public int? IDArea { get; set; }
        /// <summary>
        /// Identificador del cuestionario del grupo.
        /// </summary>
        [Required]
        public int IDCuestionario { get; set; }
        /// <summary>
        /// Orden del grupo.
        /// </summary>
        [Required]
        public int Orden { get; set; }
        /// <summary>
        /// Preguntas del grupo.
        /// </summary>
        public List<Pregunta> Preguntas { get; set; }
    }
}