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
    public class AreasController : ApiController
    {
        // GET: api/Areas
        public IEnumerable<Area> Get()
        {
            AreasProvider pAreas = new AreasProvider();
            return pAreas.GetAreas();
        }

        // GET: api/Areas/5
        public IHttpActionResult Get(int id)
        {
            AreasProvider pAreas = new AreasProvider();
            var searchResults = pAreas.GetArea(id);
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

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
