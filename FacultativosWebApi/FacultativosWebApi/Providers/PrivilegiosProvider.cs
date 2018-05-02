using FacultativosWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using FacultativosWebApi.Jwt.Filters;

namespace FacultativosWebApi.Providers
{
    public class PrivilegiosProvider
    {
        //[JwtAuthentication]
        public IEnumerable<Privilegio> GetPrivilegios()
        {
            try
            {
                return Converter.toPrivilegios(DAL.DataService.Execute("SELECT * FROM MAESTROPRIVILEGIOS"));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Privilegio GetPrivilegio(int id)
        {
            try
            {
                return Converter.toPrivilegios(DAL.DataService.Execute("SELECT * FROM MAESTROPRIVILEGIOS" +
                                " WHERE IDPRIVILEGIO = :pID",
                                "pID", id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 PostPrivilegio(Privilegio privilegio)
        {
            try
            {
                return DAL.DataService.ExecuteNonQueryRV("INSERT INTO MAESTROPRIVILEGIOS(DESCRIPCION, VALOR) " +
                                "VALUES(:pDesc, :pValor) " +
                                "RETURNING IDPRIVILEGIO INTO :pIDRT",
                                "pDesc", privilegio.Descripcion,
                                "pValor", privilegio.Valor.ToUpper(),
                                "pIDRT");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 PutPrivilegio(Privilegio privilegio)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("UPDATE MAESTROPRIVILEGIOS " +
                                "SET DESCRIPCION = :pDesc, " +
                                " VALOR = :pValor " +
                                " WHERE IDPRIVILEGIO = :pID",
                                "pDesc", privilegio.Descripcion,
                                "pValor", privilegio.Valor,
                                "pID", privilegio.IDPrivilegio);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Int32 DeletePrivilegio(int id)
        {
            try
            {
                return DAL.DataService.ExecuteNonQuery("DELETE FROM MAESTROPRIVILEGIOS " +
                                " WHERE IDPRIVILEGIO = :pID",
                                "pID", id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}