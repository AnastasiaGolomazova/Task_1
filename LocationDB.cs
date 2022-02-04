using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Task_1
{
    class LocationDB
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS02; Database=CoordinatesLocation;  Integrated Security=SSPI; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection = new SqlConnection(connectionString);

        public void OpenBbConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection is open");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Connection error testset");
                Console.WriteLine(ex.Message);
            }

        }

        public void CloseBdConnection()
        {
            connection.Close();
        }

        public bool IsConnectionOpen()
        {
            return connection != null && connection.State == ConnectionState.Open;
        }

        public List<DBUnit> GetAll()
        {
            var units = new List<DBUnit>();
            if (IsConnectionOpen())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM LocationDB", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var latitude = reader.GetDouble(2);
                        var longitude = reader.GetDouble(3);

                        units.Add(new DBUnit(id, name, latitude, longitude));
                    }
                }
                else {Console.WriteLine("No data available");}
                reader.Close();
            }
            return units;
        }

        public void ChangePosition(int id, double latitude, double longitude)
        {
            if (IsConnectionOpen())
            {
                string lat = $"{latitude}".Replace(',', '.');
                string lng = $"{longitude}".Replace(',', '.');
                string newPos = $"UPDATE LocationDB SET latitude = {lat}, longitude = {lng} WHERE ID = {id}";
                var command = new SqlCommand(newPos, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
