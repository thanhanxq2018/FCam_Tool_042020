using Microsoft.ApplicationBlocks.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MapOpennet.App_Code
{
    public class InsideConnect
    {
        public OleDbConnection connection = null;
        public static string sqlInsideConnectString = ConfigurationManager.ConnectionStrings["insideConnectString"].ConnectionString;

        public InsideConnect()
        {
            try
            {
                connection = new OleDbConnection(sqlInsideConnectString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi ket noi du lieu: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if ((connection != null) || connection.State.Equals(ConnectionState.Open))
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi dong ket noi: " + ex.Message);
            }
        }

        public DataSet BindGrid(string sp)
        {
            try
            {
                if (connection == null || connection.State.Equals(ConnectionState.Closed))
                    OpenConnection();

                OleDbCommand cmd = new OleDbCommand(sp, this.connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 200;
                OleDbDataAdapter adp = new OleDbDataAdapter();
                adp.SelectCommand = cmd;

                DataSet ds = new DataSet();
                adp.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery(string sp)
        {
            try
            {
                if (connection == null || connection.State.Equals(ConnectionState.Closed))
                    OpenConnection();

                OleDbCommand cmd = new OleDbCommand(sp, this.connection);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}