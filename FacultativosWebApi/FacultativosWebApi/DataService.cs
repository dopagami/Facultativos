using System;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Collections.Generic;

namespace FacultativosWebApi.DAL
{
    public class DataService
    {
        public static DataTable Execute(string psql, List<OdbcParameter> pParameters)
        {
            DataTable data = new DataTable();
            OdbcConnection cnn = new OdbcConnection();

            try
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                cnn.Open();

                OdbcCommand command = new OdbcCommand(psql, cnn);
                command.CommandTimeout = 15;

                foreach (OdbcParameter itemOdbcParameter in pParameters)
                {
                    command.Parameters.Add(itemOdbcParameter);
                }



                var da = new OdbcDataAdapter(command);
                da.Fill(data);
            }
            catch (Exception e)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            cnn.Close();

            return data;
        }

        public static DataTable Execute(string sql, params object[] parameters)
        {
            DataTable data = new DataTable();
            OdbcConnection cnn = new OdbcConnection();

            try
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                cnn.Open();

                OdbcCommand command = new OdbcCommand(sql, cnn);
                command.CommandTimeout = 15;

                for (int i = 0; i < parameters.Length; i += 2)
                {
                    command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
                }
                var da = new OdbcDataAdapter(command);
                da.Fill(data);
            }
            catch (Exception e)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
                throw;
            }

            cnn.Close();
            return data;
        }

        public static IEnumerable<T> Execute<T>(Func<IDataReader, T> selector, string sql, params object[] parameters)
        {
            var cnn = new OdbcConnection();
            OdbcCommand command;
            OdbcDataReader dr;

            try
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                cnn.Open();

                command = new OdbcCommand(sql, cnn);
                command.CommandTimeout = 15;

                for (int i = 0; i < parameters.Length; i += 2)
                {
                    command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
                }

                dr = command.ExecuteReader();
            }
            catch
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
                throw;
            }

            while (dr.Read())
            {
                yield return selector(dr);
            }

            cnn.Close();
        }

        public static int ExecuteNonQuery(string sql, params object[] parameters)
        {
            int data = -1;
            var cnn = new OdbcConnection();

            try
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                cnn.Open();

                var command = new OdbcCommand(sql, cnn);
                command.CommandTimeout = 15;

                for (int i = 0; i < parameters.Length; i += 2)
                {
                    command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1] == null ? DBNull.Value : parameters[i + 1]);
                }
                data = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
                throw ex;
            }

            cnn.Close();
            return data;
        }

        public static Int32 ExecuteNonQueryRV(string sql, params object[] parameters)
        {
            int data = -1;
            Int32 RV = -1;
            var cnn = new OdbcConnection();

            try
            {
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                cnn.Open();

                var command = new OdbcCommand(sql, cnn);
                command.CommandTimeout = 15;

                int i;
                for (i = 0; i < parameters.Length-1; i += 2)
                {
                    command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1] == null ? DBNull.Value : parameters[i + 1] );
                }

                OdbcParameter paramRV = new OdbcParameter(parameters[parameters.Length - 1].ToString(), 1);
                paramRV.IsNullable = true;
                paramRV.OdbcType = OdbcType.Numeric;
                paramRV.Direction = ParameterDirection.ReturnValue;
                paramRV.Value = 1;
                command.Parameters.Add(paramRV);
                data = command.ExecuteNonQuery();
                RV = System.Convert.ToInt32(command.Parameters[command.Parameters.Count - 1].Value);                
            }
            catch
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
                throw;
            }

            cnn.Close();
            return RV;
        }
    }
}