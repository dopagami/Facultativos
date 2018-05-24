using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Respuesta:Pregunta
    {
        ///// <summary>
        ///// Identificador de la pregunta.
        ///// </summary>
        //public int IDPregunta { get; set; }
        ///// <summary>
        ///// Descripción de la pregunta.
        ///// </summary>
        //[Required]
        //public string Descripcion { get; set; }
        ///// <summary>
        ///// Identificador del grupo de la pregunta.
        ///// </summary>
        //public int? IDGrupo { get; set; }
        ///// <summary>
        ///// Identificador del área de la pregunta.
        ///// </summary>
        //public int? IDArea { get; set; }
        ///// <summary>
        ///// Identificador del cuestionario de la pregunta.
        ///// </summary>
        //[Required]
        //public int IDCuestionario { get; set; }
        ///// <summary>
        ///// Descripción de la pregunta.
        ///// </summary>
        //public string Respuesta { get; set; }
        ///// <summary>
        ///// Orden de la pregunta.
        ///// </summary>
        //[Required]
        //public int Orden { get; set; }

        /// <summary>
        /// Identificador de la respuesta del facultativo.
        /// </summary>
        public int? IDRespuestaFacultativo { get; set; }
        /// <summary>
        /// Identificador del facultativo.
        /// </summary>
        public int? IDFacultativo { get; set; }
        /// <summary>
        /// Identificador del departamento.
        /// </summary>
        public int? IDDepartamento { get; set; }
        /// <summary>
        /// Identificador del privilegio respondido.
        /// </summary>
        public string IDPrivilegio { get; set; }
        /// <summary>
        /// Observaciones de la respuesta.
        /// </summary>
        public string ObservacionesRespuesta { get; set; }
    }
}