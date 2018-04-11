using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacultativosWebApi.Models;
using FacultativosWebApi.Providers;
using System.Threading.Tasks;

namespace FacultativosWebApi.Controllers
{
    public class PrivilegiosController : ApiController
    {
        // GET: api/Privilegios
        public IEnumerable<Privilegio> Get()
        {
            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();
            return pPrivilegios.GetPrivilegios();
        }

        //// GET: api/Privilegios/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Privilegios
        public IHttpActionResult Post(Privilegio privilegio)
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
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = privilegio.IDPrivilegio }, privilegio);
        }

        // PUT: api/Privilegios/5
        public IHttpActionResult Put(int id, Privilegio privilegio)
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
                //pPrivilegios.PutPrivilegio(privilegio);
            }
            catch (Exception ex)
            {
                //if (!MAESTROPRIVILEGIOSExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// DELETE: api/Privilegios/5
        //public void Delete(int id)
        //{
        //    MAESTROPRIVILEGIOS mAESTROPRIVILEGIOS = await db.MAESTROPRIVILEGIOS.FindAsync(id);
        //        if (mAESTROPRIVILEGIOS == null)
        //        {
        //            return NotFound();
        //}

        //db.MAESTROPRIVILEGIOS.Remove(mAESTROPRIVILEGIOS);
        //        await db.SaveChangesAsync();

        //        return Ok(mAESTROPRIVILEGIOS);
        //}
    }
}
