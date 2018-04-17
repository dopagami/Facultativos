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
    public class PreguntasController : ApiController
    {
        // GET: api/Preguntas
        public IEnumerable<Pregunta> Get()
        {
            PreguntasProvider pPreguntas = new PreguntasProvider();
            return pPreguntas.GetPreguntas();
        }

        // GET: api/Preguntas/5
        public IHttpActionResult Get(int id)
        {
            PreguntasProvider pPreguntas = new PreguntasProvider();
            var searchResults = pPreguntas.GetPregunta(id);
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

        // POST: api/Preguntas
        public IHttpActionResult Post([FromBody]Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PreguntasProvider pPreguntas = new PreguntasProvider();

            try
            {
                pregunta.IDPregunta = pPreguntas.PostPregunta(pregunta);
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

            return CreatedAtRoute("DefaultApi", new { id = pregunta.IDPregunta }, pregunta);
        }

        // PUT: api/Preguntas/5
        public IHttpActionResult Put(int id, [FromBody]Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pregunta.IDPregunta)
            {
                return BadRequest();
            }

            PreguntasProvider pPreguntas = new PreguntasProvider();

            try
            {
                int i = pPreguntas.PutPregunta(pregunta);
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
            return Ok(pregunta);
        }

        // DELETE: api/Preguntas/5
        public IHttpActionResult Delete(int id)
        {
            PreguntasProvider pPreguntas = new PreguntasProvider();

            try
            {
                int i = pPreguntas.DeletePregunta(id);
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
