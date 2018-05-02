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
    public class GruposController : ApiController
    {
        /// <summary>
        /// Obtiene todos los grupos.
        /// </summary>
        [ResponseType(typeof(Grupo))]
        // GET: api/Grupos
        public IEnumerable<Grupo> Get()
        {
            GruposProvider pGrupos = new GruposProvider();
            try
            {
                return pGrupos.GetGrupos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un grupo por identificador.
        /// </summary>
        /// <param name="id">Identificador del grupo.</param>
        [ResponseType(typeof(IEnumerable<Grupo>))]
        public IHttpActionResult Get(int id)
        {
            GruposProvider pGrupos = new GruposProvider();
            try
            {
                var searchResults = pGrupos.GetGrupo(id);
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
        /// Crea un nuevo grupo.
        /// </summary>
        /// <param name="area">El campo IDGrupo será ignorado en la petición</param>
        [ResponseType(typeof(Grupo))]
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
                DAL.DataService.createTransaction();

                grupo.IDGrupo = pGrupos.PostGrupo(grupo);

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

            return CreatedAtRoute("DefaultApi", new { id = grupo.IDGrupo }, grupo);
        }

        /// <summary>
        /// Modifica un grupo por identificador.
        /// </summary>
        /// <param name="id">Identificador del grupo.</param>
        /// <param name="grupo"></param>
        [ResponseType(typeof(Area))]
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

        /// <summary>
        /// Elimina un grupo por identificador.
        /// </summary>
        /// <param name="id">Identificador del grupo.</param>
        [ResponseType(typeof(void))]
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
