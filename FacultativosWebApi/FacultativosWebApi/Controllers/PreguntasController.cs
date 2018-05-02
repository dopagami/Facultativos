using FacultativosWebApi.Models;
using FacultativosWebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FacultativosWebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = "facultativos")]
    public class PreguntasController : ApiController
    {
        /// <summary>
        /// Obtiene todas las preguntas.
        /// </summary>
        [ResponseType(typeof(Pregunta))]
        // GET: api/Preguntas
        public IHttpActionResult Get()
        {
            PreguntasProvider pPreguntas = new PreguntasProvider();
            try
            {
                var searchResults = pPreguntas.GetPreguntas();
                if (searchResults == null)
                    return NotFound();
                return Ok(searchResults);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una pregunta por identificador.
        /// </summary>
        /// <param name="id">Identificador de la pregunta.</param>
        [ResponseType(typeof(IEnumerable<Pregunta>))]
        // GET: api/Preguntas/5
        public IHttpActionResult Get(int id)
        {
            PreguntasProvider pPreguntas = new PreguntasProvider();
            try
            {
                var searchResults = pPreguntas.GetPregunta(id);
                if (searchResults == null)
                    return NotFound();
                return Ok(searchResults);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Crea una nueva pregunta.
        /// </summary>
        /// <param name="pregunta">El campo IDPregunta será ignorado en la petición</param>
        [ResponseType(typeof(Pregunta))]
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

        /// <summary>
        /// Modifica una pregunta por identificador.
        /// </summary>
        /// <param name="id">Identificador de la pregunta.</param>
        /// <param name="pregunta"></param>
        [ResponseType(typeof(Pregunta))]
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

        /// <summary>
        /// Elimina una pregunta por identificador.
        /// </summary>
        /// <param name="id">Identificador de la pregunta.</param>
        [ResponseType(typeof(void))]
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
