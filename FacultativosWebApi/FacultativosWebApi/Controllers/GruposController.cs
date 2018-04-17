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
        public IHttpActionResult Post([FromBody]Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            GruposProvider pGrupos = new GruposProvider();

            try
            {
                grupo.IDGrupo = pGrupos.PostGrupo(grupo);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2300")) //integrity constraint violation
                {
                    return Conflict();
                }
                else
                {
                    throw ex;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = grupo.IDGrupo }, grupo);
        }

        // PUT: api/Grupos/5
        public IHttpActionResult Put(int id, [FromBody]Grupo grupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grupo.IDGrupo)
            {
                return BadRequest();
            }

            GruposProvider pGrupos = new GruposProvider();

            try
            {
                int i = pGrupos.PutGrupo(grupo);
                if (i == 0) return NotFound();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2300")) //integrity constraint violation
                {
                    return Conflict();
                }
                else
                {
                    throw ex;
                }
            }

            //return StatusCode(HttpStatusCode.NoContent);
            return Ok(grupo);
        }

        // DELETE: api/Grupos/5
        public IHttpActionResult Delete(int id)
        {
            GruposProvider pGrupos = new GruposProvider();

            try
            {
                int i = pGrupos.DeleteGrupo(id);
                if (i == 0) return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok();
        }
    }
}
