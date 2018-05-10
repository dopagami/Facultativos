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
        /// <summary>
        /// Categoría del facultativo.
        /// </summary>        
        public string Categoria { get; set; }
        /// <summary>
        /// Puesto del facultativo.
        /// </summary>        
        public string Puesto { get; set; }
        /// <summary>
        /// Identificador del departamento del facultativo.
        /// </summary>        
        public int IDDepartamento { get; set; }
        /// <summary>
        /// Departamento del facultativo.
        /// </summary>        
        public string Departamento { get; set; }
        /// <summary>
        /// Centro del facultativo.
        /// </summary>        
        public string Centro { get; set; }
        /// <summary>
        /// Correo electrónico del facultativo.
        /// </summary>        
        public string email { get; set; }
    }
}