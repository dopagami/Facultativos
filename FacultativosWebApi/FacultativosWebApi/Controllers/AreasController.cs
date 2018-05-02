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
    public class AreasController : ApiController
    {
        /// <summary>
        /// Obtiene todas las áreas.
        /// </summary>
        [ResponseType(typeof(Area))]
        // GET: api/Areas
        public IEnumerable<Area> Get()
        {
            AreasProvider pAreas = new AreasProvider();
            try
            {                
                return pAreas.GetAreas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un área por identificador.
        /// </summary>
        /// <param name="id">Identificador del área.</param>
        [ResponseType(typeof(IEnumerable<Area>))]
        // GET: api/Areas/5
        public IHttpActionResult Get(int id)
        {
            AreasProvider pAreas = new AreasProvider();
            try
            {                
                var searchResults = pAreas.GetArea(id);
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
        /// Crea un nuevo área.
        /// </summary>
        /// <param name="area">El campo IDArea será ignorado en la petición</param>
        [ResponseType(typeof(Privilegio))]
        // POST: api/Areas
        public IHttpActionResult Post([FromBody]Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AreasProvider pAreas = new AreasProvider();

            try
            {
                DAL.DataService.createTransaction();

                area.IDArea = pAreas.PostArea(area);

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

            return CreatedAtRoute("DefaultApi", new { id = area.IDArea }, area);
        }

        /// <summary>
        /// Modifica un área por identificador.
        /// </summary>
        /// <param name="id">Identificador del área.</param>
        /// <param name="area"></param>
        [ResponseType(typeof(Area))]
        // PUT: api/Areas/5
        public IHttpActionResult Put(int id, [FromBody]Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != area.IDArea)
            {
                return BadRequest();
            }

            AreasProvider pAreas = new AreasProvider();

            try
            {
                int i = pAreas.PutArea(area);
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
            return Ok(area);
        }

        /// <summary>
        /// Elimina un área por identificador.
        /// </summary>
        /// <param name="id">Identificador del área.</param>
        [ResponseType(typeof(void))]
        // DELETE: api/Areas/5
        public IHttpActionResult Delete(int id)
        {
            AreasProvider pAreas = new AreasProvider();

            try
            {
                int i = pAreas.DeleteArea(id);
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
