using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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

        public Privilegio GetPrivilegio(int id)
        {
            return Converter.toPrivilegios(DAL.DataService.Execute("SELECT * FROM MAESTROPRIVILEGIOS" +
                        " WHERE IDPRIVILEGIO = :pID",
                        "pID", id)).FirstOrDefault();
        }

        public Int32 PostPrivilegio(Privilegio privilegio)
        {
            return DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROPRIVILEGIOS(DESCRIPCION, VALOR) " +
                        "VALUES(:pDesc, :pValor) " +
                        "RETURNING IDPRIVILEGIO INTO :pIDRT",
                        "pDesc", privilegio.Descripcion,
                        "pValor", privilegio.Valor.ToUpper(), 
                        "pIDRT");
        }

        public Int32 PutPrivilegio(Privilegio privilegio)
        {
            return DAL.DataService.ExecuteNonQuery("UPDATE MAESTROPRIVILEGIOS " +
                        "SET DESCRIPCION = :pDesc, " +
                        " VALOR = :pValor " +
                        " WHERE IDPRIVILEGIO = :pID",
                        "pDesc", privilegio.Descripcion,
                        "pValor", privilegio.Valor,
                        "pID", privilegio.IDPrivilegio);
        }

        public Int32 DeletePrivilegio(int id)
        {
            return DAL.DataService.ExecuteNonQuery("DELETE FROM MAESTROPRIVILEGIOS " +
                        " WHERE IDPRIVILEGIO = :pID",
                        "pID", id);
        }
    }
}