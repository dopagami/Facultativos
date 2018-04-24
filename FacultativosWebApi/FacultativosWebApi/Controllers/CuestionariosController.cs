using FacultativosWebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacultativosWebApi.Models;
using System.Web.Http.Description;

namespace FacultativosWebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    ///[Authorize]
    public class CuestionariosController : ApiController
    {
        /// <summary>
        /// Obtiene todos los cuestionarios.
        /// </summary>
        // GET: api/Cuestionarios
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult Get()
        {
            CuestionariosProvider pCuestionarios = new CuestionariosProvider();
            var searchResults = pCuestionarios.GetCuestionarios();
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

        /// <summary>
        /// Obtiene un cuestionario por identificador.
        /// </summary>
        /// <param name="id">ID del cuestionario</param>
        [ResponseType(typeof(IEnumerable<Cuestionario>))]
        // GET: api/Cuestionarios/5
        public IHttpActionResult Get(int id)
        {
            CuestionariosProvider pCuestionarios = new CuestionariosProvider();
            var searchResults = pCuestionarios.GetCuestionario(id);
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

        /// <summary>
        /// Crear un nuevo cuestionario.
        /// </summary>
        /// <param name="cuestionario"></param>
        // POST: api/Cuestionarios
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult Post([FromBody]Cuestionario cuestionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CuestionariosProvider pCuestionarios = new CuestionariosProvider();

            try
            {
                DAL.DataService.createTransaction();

                cuestionario.IDCuestionario = pCuestionarios.PostCuestionario(cuestionario);

                DAL.DataService.transaction.Commit();
                DAL.DataService.closeTransaction();
            }
            catch (Exception ex)
            {
                DAL.DataService.transaction.Rollback();
                DAL.DataService.closeTransaction();

                if (ex.Message.Contains("2300")) //integrity constraint violation
                {
                    return Conflict();
                }
                else
                {
                    throw ex;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cuestionario.IDCuestionario }, cuestionario);
        }

        /// <summary>
        /// Modifica un cuestionario por identificador.
        /// </summary>
        /// <param name="id">Identificador del cuestionario.</param>
        /// <param name="cuestionario"></param>
        [ResponseType(typeof(Cuestionario))]
        public IHttpActionResult Put(int id, [FromBody]Cuestionario cuestionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuestionario.IDCuestionario)
            {
                return BadRequest();
            }

            CuestionariosProvider pCuestionarios = new CuestionariosProvider();

            try
            {
                int i = pCuestionarios.PutCuestionario(cuestionario);
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
            return Ok(cuestionario);
        }

        /// <summary>
        /// Elimina un cuestionario por identificador.
        /// </summary>
        /// <param name="id">Identificador del cuestionario.</param>
        [ResponseType(typeof(void))]
        // DELETE: api/Cuestionarios/5
        public IHttpActionResult Delete(int id)
        {
            CuestionariosProvider pCuestionarios = new CuestionariosProvider();

            try
            {
                int i = pCuestionarios.DeleteCuestionario(id);
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
