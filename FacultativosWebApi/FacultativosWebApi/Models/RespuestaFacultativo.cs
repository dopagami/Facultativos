using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Models
{
    public class RespuestaFacultativo
    {
        public int IDRESPUESTAFACULTATIVO { get; set; }
        public int IDPREGUNTA { get; set; }
        public int IDPRIVILEGIO { get; set; }
        public string OBSERVACIONES { get; set; }
        public int IDFACULTATIVO { get; set; }
    }
}