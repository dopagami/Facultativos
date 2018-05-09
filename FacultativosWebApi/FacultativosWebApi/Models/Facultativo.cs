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
    public class Facultativo
    {
        /// <summary>
        /// Identificador del facultativo.
        /// </summary>
        public string IDFacultativo { get; set; }
        /// <summary>
        /// Nombre del facultativo.
        /// </summary>
        [Required]
        public string Nombre { get; set; }
        /// <summary>
        /// Primer apellido del facultativo.
        /// </summary>
        [Required]
        public string Apellido1 { get; set; }
        /// <summary>
        /// Segundo apellido del facultativo.
        /// </summary>
        [Required]
        public string Apellido2 { get; set; }
        /// <summary>
        /// Número de colegiado del facultativo.
        /// </summary>        
        public int NumColegiado { get; set; }
    }
}