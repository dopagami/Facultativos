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
    public class FacultativosController : ApiController
    {
        /// <summary>
        /// Obtiene todos los facultativos.
        /// </summary>        
        [ResponseType(typeof(Facultativo))]
        // GET: api/Facultativos
        public IHttpActionResult Get()
        {
            FacultativosProvider pPreguntas = new FacultativosProvider();
            try
            {
                var searchResults = pPreguntas.GetFacultativos();
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
        /// Obtiene un facultativo por identificador.
        /// </summary>
        /// <param name="id">Identificador del facultativo.</param>
        [ResponseType(typeof(IEnumerable<Facultativo>))]
        // GET: api/Facultativos/5
        public IHttpActionResult Get(string id)
        {
            FacultativosProvider pPreguntas = new FacultativosProvider();
            try
            {
                var searchResults = pPreguntas.GetFacultativo(id);
                if (searchResults == null)
                    return NotFound();
                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //// POST: api/Facultativos
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Facultativos/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Facultativos/5
        //public void Delete(int id)
        //{
        //}
    }
}
