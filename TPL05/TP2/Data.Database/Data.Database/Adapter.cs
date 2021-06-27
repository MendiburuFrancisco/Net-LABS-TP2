using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
      
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";

        //  private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        //private SqlConnection sqlConnection = new SqlConnection(consKeyDefaultCnnString);

        private SqlConnection _sqlConn; 
        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value;  }
        }

        protected void OpenConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            throw new Exception("Metodo no implementado");

        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
            throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
