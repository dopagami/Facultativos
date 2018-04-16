﻿using System;
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
        public IHttpActionResult Get()
        {            
            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();
            var searchResults = pPrivilegios.GetPrivilegios();
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

        // GET: api/Privilegios/5
        public IHttpActionResult Get(int id)
        {
            PrivilegiosProvider pPrivilegios = new PrivilegiosProvider();
            var searchResults = pPrivilegios.GetPrivilegio(id);
            if (searchResults == null)
                return NotFound();
            return Ok(searchResults);
        }

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
