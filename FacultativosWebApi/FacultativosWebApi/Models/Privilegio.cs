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
    public class Privilegio
    {
        public int IDPrivilegio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Valor { get; set; }
    }
}