using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Task_1
{
    class LocationDB
    {

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-JH4MSCG\SQLEXPRESS02; Initial Catalog=CoordinatesLocation; Integrated Security=True");

        public void OpenBbConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection is open");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection error");
                Console.WriteLine(ex.Message);
            }

        }

        public void CloseBdConnection()
        {
            connection.Close();
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }

    }
}
