using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http.Description;

namespace FacultativosWebApi.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Privilegio
    {
        /// <summary>
        /// Identificador del privilegio.
        /// </summary>
        public int IDPrivilegio { get; set; }
        /// <summary>
        /// Descripción del privilegio.
        /// </summary>
        [Required]
        public string Descripcion { get; set; }
        /// <summary>
        /// Valor del privilegio.
        /// </summary>
        [Required]
        public string Valor { get; set; }
    }
}