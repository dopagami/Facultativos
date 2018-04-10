using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FacultativosWebApi.Models;
using FacultativosWebApi.Providers;

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

        //// POST: api/Privilegios
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Privilegios/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Privilegios/5
        //public void Delete(int id)
        //{
        //}
    }
}
