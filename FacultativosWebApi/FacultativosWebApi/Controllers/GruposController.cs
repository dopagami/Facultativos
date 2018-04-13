using FacultativosWebApi.Models;
using FacultativosWebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FacultativosWebApi.Controllers
{
    public class GruposController : ApiController
    {
        // GET: api/Grupos
        public IEnumerable<Grupo> Get()
        {
            GruposProvider pGrupos = new GruposProvider();
            return pGrupos.GetGrupos();
        }

        // GET: api/Grupos/5
        public IHttpActionResult Get(int id)
        {
            GruposProvider pGrupos = new GruposProvider();
            var searchResults = pGrupos.GetGrupo(id);
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

        // POST: api/Grupos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Grupos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Grupos/5
        public void Delete(int id)
        {
        }
    }
}
