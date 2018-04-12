using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Privilegio
    {
        public int IDPrivilegio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Valor { get; set; }
    }
}