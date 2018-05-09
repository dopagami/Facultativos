using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultativosWebApi.Providers
{
    public class FacultativosProvider
    {
        public IEnumerable<Facultativo> GetFacultativos()
        {
            try
            {
                return Converter.toFacultativos(DAL.DataService.Execute("SELECT SG02COD, SG02NOM, SG02APE1, SG02APE2, SG02NUMCOLEGIADO " +
                                                                "FROM SG0200"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Facultativo GetFacultativo(string id)
        {
            try
            {
                return Converter.toFacultativos(DAL.DataService.Execute("SELECT SG02COD, SG02NOM, SG02APE1, SG02APE2, SG02NUMCOLEGIADO " +
                                                                "FROM SG0200" +
                                                                " WHERE SG02COD = :pID",
                                                                "pID", id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}