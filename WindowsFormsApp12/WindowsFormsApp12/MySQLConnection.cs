using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp12
{
   public class MySQLConnection
    {
         public SqlConnection connection;

        public SqlConnection CreateConnection() //create mysql connection
        {
            string connectionString = "Data Source=DESKTOP-1D3IG54\\SQLEXPRESS;Initial Catalog=Craftsman;Integrated Security=True;";
           connection = new SqlConnection(connectionString);
            return connection;
        }

        private bool OpenConnection() //connect open
        {
            try
            {
                connection = CreateConnection();
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private bool CloseConnection() //conne ction close
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Executing(string query) //execute sql query
        {
            try
            {
                if (OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadData(string Query) //get data using sql query
        {
            try
            {
                DataSet ds = new DataSet();
                if (OpenConnection())
                {

                    SqlCommand cmd = new SqlCommand(Query, connection);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                    }

                    CloseConnection();
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
