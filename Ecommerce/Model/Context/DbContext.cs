using System;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Model.Context
{
    public class DbContext : IDisposable
    {
        private SqlConnection _conn;
        public SqlConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        private SqlConnection GetOpenConnection()
        {
            SqlConnection conn = null;
            try 
            {
                string connectionString = "Server=DESKTOP-65T434S\\SQLEXPRESS;Database=book-store;Trusted_Connection=True;";
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}; Error Number : {1}", ex.Message, ex.Number);
            }
            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
