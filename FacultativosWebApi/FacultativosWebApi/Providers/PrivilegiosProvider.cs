using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FacultativosWebApi.Providers
{
    public class PrivilegiosProvider
    {
        public IEnumerable<Privilegio> GetPrivilegios()
        {
            return Converter.toPrivilegios(DAL.DataService.Execute("select * from maestroprivilegios"));
        }
    }
}