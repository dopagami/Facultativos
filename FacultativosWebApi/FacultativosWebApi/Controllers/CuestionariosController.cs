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
        public IHttpActionResult Get()
        {
            CuestionariosProvider pCuestionarios = new CuestionariosProvider();
            var searchResults = pCuestionarios.GetCuestionarios();
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

        // GET: api/Cuestionarios/5
        public IHttpActionResult Get(int id)
        {
            CuestionariosProvider pCuestionarios = new CuestionariosProvider();
            var searchResults = pCuestionarios.GetCuestionario(id);
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

        //// POST: api/Cuestionarios
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Cuestionarios/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Cuestionarios/5
        //public void Delete(int id)
        //{
        //}
    }
}
