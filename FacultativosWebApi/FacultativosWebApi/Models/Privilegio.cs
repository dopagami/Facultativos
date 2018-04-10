using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class Privilegio
    {
        public int IDPrivilegio { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
    }
}