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
    [Authorize(Roles = "facultativos")]
    public class RespuestasController : ApiController
    {
        // GET: api/Respuestas
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Respuestas/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        /// <summary>
        /// Crea una respuesta a una pregunta
        /// </summary>
        /// <param name="Respuestas">El campo IDRespuestaFacultativo será ignorado en la petición</param>
        [ResponseType(typeof(Respuesta))]
        // POST: api/Respuestas
        public IHttpActionResult Post([FromBody]IEnumerable <Respuesta> Respuestas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RespuestasProvider pRespuestas = new RespuestasProvider();

            try
            {
                foreach (Respuesta respuesta in Respuestas)
                {
                    respuesta.IDRespuestaFacultativo = pRespuestas.PostRespuesta(respuesta);
                }                
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

            //return CreatedAtRoute("DefaultApi", new { id = Respuesta.IDRespuestaFacultativo }, Respuesta);
            return Ok(Respuestas);
        }

        /// <summary>
        /// Modifica una respuesta de una pregunta por identificador.
        /// </summary>
        /// <param name="Respuestas">Colección de respuesta a modificar</param>
        [ResponseType(typeof(Pregunta))]
        // PUT: api/Respuestas/5
        public IHttpActionResult Put([FromBody]IEnumerable<Respuesta> Respuestas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != pregunta.IDPregunta)
            //{
            //    return BadRequest();
            //}

            RespuestasProvider pRespuestas = new RespuestasProvider();
            IEnumerable<Respuesta> RespuestasModificadas;

            try
            {
                List<Respuesta> lRespuestasModificadas = new List<Respuesta>();
                foreach (Respuesta respuesta in Respuestas)
                {                    
                    int i = pRespuestas.PutRespuesta(respuesta);                    
                    lRespuestasModificadas.Add(respuesta);
                    //if (i == 0) return NotFound();
                }
                RespuestasModificadas = lRespuestasModificadas;
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
            return Ok(RespuestasModificadas);
        }

        /// <summary>
        /// Elimina una respuesta por identificador.
        /// </summary>
        /// <param name="Respuestas">Colección de respuesta a eliminar</param>
        [ResponseType(typeof(Pregunta))]
        // DELETE: api/Respuestas/5
        public IHttpActionResult Delete([FromBody]IEnumerable<Respuesta> Respuestas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RespuestasProvider pRespuestas = new RespuestasProvider();

            try
            {
                //int i = pPrivilegios.DeletePrivilegio(id);
                //if (i == 0) return NotFound();
                foreach (Respuesta respuesta in Respuestas)
                {
                    int id, i;
                    bool result = Int32.TryParse(respuesta.IDRespuestaFacultativo.ToString(), out id);
                    if (result)
                    {
                        i = pRespuestas.DeleteRespuesta(id);
                    }                        
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok();

        }
    }
}
