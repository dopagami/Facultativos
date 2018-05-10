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
                return Converter.toFacultativos(DAL.DataService.Execute("SELECT S.SG02COD, S.SG02NOM, S.SG02APE1, S.SG02APE2, S.SG02NUMCOLEGIADO, S.SG02EMAIL, AD30.AD30DESCATEGORIA, AD31.AD31DESPUESTO, AD02.AD02CODDPTO, AD02.AD02DESDPTO, AD74.AD74DESCENTRO " +
                                                                "FROM SG0200 S INNER JOIN AD0300 AD03 " +
                                                                "ON S.SG02COD = AD03.SG02COD " +
                                                                "INNER JOIN AD0200 AD02 " + 
                                                                "ON AD03.AD02CODDPTO = AD02.AD02CODDPTO " +
                                                                "INNER JOIN AD3000 AD30 " +
                                                                "ON S.AD30CODCATEGORIA = AD30.AD30CODCATEGORIA " +
                                                                "INNER JOIN AD3100 AD31 " +
                                                                "ON AD03.AD31CODPUESTO = AD31.AD31CODPUESTO " +
                                                                "INNER JOIN AD7400 AD74 " + 
                                                                "ON AD02.AD74CODCENTRO = AD74.AD74CODCENTRO " +
                                                                "WHERE AD03.AD31CODPUESTO IN(1, 5)"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Facultativo GetFacultativo(string id, string dpto)
        {
            try
            {
                return Converter.toFacultativos(DAL.DataService.Execute("SELECT S.SG02COD, S.SG02NOM, S.SG02APE1, S.SG02APE2, S.SG02NUMCOLEGIADO, S.SG02EMAIL, AD30.AD30DESCATEGORIA, AD31.AD31DESPUESTO, AD02.AD02CODDPTO, AD02.AD02DESDPTO, AD74.AD74DESCENTRO " +
                                                                "FROM SG0200 S INNER JOIN AD0300 AD03 " +
                                                                "ON S.SG02COD = AD03.SG02COD " +
                                                                "INNER JOIN AD3000 AD30 " +
                                                                "ON S.AD30CODCATEGORIA = AD30.AD30CODCATEGORIA " +
                                                                "INNER JOIN AD0200 AD02 " +
                                                                "ON AD03.AD02CODDPTO = AD02.AD02CODDPTO " +
                                                                "INNER JOIN AD3100 AD31 " +
                                                                "ON AD03.AD31CODPUESTO = AD31.AD31CODPUESTO " +
                                                                "INNER JOIN AD7400 AD74 " +
                                                                "ON AD02.AD74CODCENTRO = AD74.AD74CODCENTRO " +
                                                                "WHERE AD03.AD31CODPUESTO IN(1, 5) " +
                                                                "AND S.SG02COD = :pID " +
                                                                "AND AD02.AD02CODDPTO = :pDpto",
                                                                "pID", id, "pDpto", dpto)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}