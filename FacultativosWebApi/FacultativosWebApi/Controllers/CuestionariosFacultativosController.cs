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
    public class CuestionariosFacultativosController : ApiController
    {
        // GET: api/CuestionariosFacultativos
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        /// <summary>
        /// Obtiene un cuestionario de un facultativo y un departamento
        /// </summary>
        /// <param name="idFacultativo">ID del facultativo</param>
        /// <param name="idDpto">ID del departamento</param>
        [Route("api/CuestionariosFacultativos/{idFacultativo}/{idDpto}")]
        [ResponseType(typeof(IEnumerable<Cuestionario>))]
        // GET: api/CuestionariosFacultativos/5
        public IHttpActionResult Get(int idFacultativo, int idDpto)
        {
            CuestionariosFacultativosProvider pCuestionariosFacultativos = new CuestionariosFacultativosProvider();
            try
            {
                var searchResults = pCuestionariosFacultativos.GetCuestionarioFacultativo(idFacultativo, idDpto);
                if (searchResults == null)
                    return NotFound();
                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/CuestionariosFacultativos
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/CuestionariosFacultativos/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/CuestionariosFacultativos/5
        //public void Delete(int id)
        //{
        //}
    }
}
