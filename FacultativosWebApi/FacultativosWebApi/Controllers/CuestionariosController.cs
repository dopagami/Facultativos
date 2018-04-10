using FacultativosWebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacultativosWebApi.Models;

namespace FacultativosWebApi.Controllers
{
    public class CuestionariosController : ApiController
    {
        // GET: api/Cuestionarios
        public IEnumerable<Cuestionario> Get()
        {
            CuestionariosProvider pCuestionarios = new CuestionariosProvider();
            return pCuestionarios.GetCuestionarios();
        }

        // GET: api/Cuestionarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cuestionarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cuestionarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cuestionarios/5
        public void Delete(int id)
        {
        }
    }
}
