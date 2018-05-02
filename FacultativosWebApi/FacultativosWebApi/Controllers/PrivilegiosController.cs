using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacultativosWebApi.Models;
using FacultativosWebApi.Providers;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Collections;
using FacultativosWebApi.Jwt.Filters;

namespace FacultativosWebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(Roles = "facultativos")]
    public class PrivilegiosController : ApiController
    {
        /// <summary>
        /// Obtiene todos los privilegios.
        /// </summary>
        [ResponseType(typeof(Privilegio))]
        // GET: api/Privilegios        
        public IHttpActionResult Get()
        {            
            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();
            try
            {
                var searchResults = pPrivilegios.GetPrivilegios();
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
        /// Obtiene un privilegio por identificador.
        /// </summary>
        /// <param name="id">Identificador del privilegio.</param>
        [ResponseType(typeof(IEnumerable<Privilegio>))]
        // GET: api/Privilegios/5
        public IHttpActionResult Get(int id)
        {
            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();
            try
            {
                var searchResults = pPrivilegios.GetPrivilegio(id);
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
        /// Crea un nuevo privilegio.
        /// </summary>
        /// <param name="privilegio">El campo IDPrivilegio será ignorado en la petición</param>
        [ResponseType(typeof(Privilegio))]
        // POST: api/Privilegios
        public IHttpActionResult Post([FromBody]Privilegio privilegio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();

            try
            {
                privilegio.IDPrivilegio = pPrivilegios.PostPrivilegio(privilegio);
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

            return CreatedAtRoute("DefaultApi", new { id = privilegio.IDPrivilegio }, privilegio);
        }

        /// <summary>
        /// Modifica un privilegio por identificador.
        /// </summary>
        /// <param name="id">Identificador del privilegio.</param>
        /// <param name="privilegio"></param>
        [ResponseType(typeof(Privilegio))]
        // PUT: api/Privilegios/5
        public IHttpActionResult Put(int id, [FromBody]Privilegio privilegio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != privilegio.IDPrivilegio)
            {
                return BadRequest();
            }

            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();

            try
            {
                int i = pPrivilegios.PutPrivilegio(privilegio);
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
            return Ok(privilegio);
        }

        /// <summary>
        /// Elimina un privilegio por identificador.
        /// </summary>
        /// <param name="id">Identificador del privilegio.</param>
        [ResponseType(typeof(void))]
        //// DELETE: api/Privilegios/5
        public IHttpActionResult Delete(int id)
        {
            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();

            try
            {
                int i = pPrivilegios.DeletePrivilegio(id);
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
