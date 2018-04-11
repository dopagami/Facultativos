using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace FacultativosWebApi.Providers
{
    public class PrivilegiosProvider
    {
        public IEnumerable<Privilegio> GetPrivilegios()
        {
            return Converter.toPrivilegios(DAL.DataService.Execute("SELECT * FROM MAESTROPRIVILEGIOS"));
        }

        public Int32 PostPrivilegio(Privilegio privilegio)
        {            
            return DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROPRIVILEGIOS(DESCRIPCION, VALOR) " +
                        "VALUES(:pDesc, :pValor) " +
                        "RETURNING IDPRIVILEGIO INTO :pIDRT",
                        "pDesc", privilegio.Descripcion,
                        "pValor", privilegio.Valor, 
                        "pIDRT");
        }

        public Int32 PutPrivilegio(Privilegio privilegio)
        {
            return DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROPRIVILEGIOS(DESCRIPCION, VALOR) " +
                        "VALUES(:pDesc, :pValor) " +
                        "RETURNING IDPRIVILEGIO INTO :pIDRT",
                        "pDesc", privilegio.Descripcion,
                        "pValor", privilegio.Valor,
                        "pIDRT");
        }
    }
}