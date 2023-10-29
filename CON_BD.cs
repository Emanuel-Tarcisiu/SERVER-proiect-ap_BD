using System;
using System.Data.SqlClient;

namespace SERVER
{
    internal class CON_BD
    {
        private SqlConnection connection;

        //Constructor
        public CON_BD() {
            string connectionString = "Data Source=LAPTOPEMY;Initial Catalog=POSproiect;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        //Destructor
        public void closeConnection()
        {
            connection.Close();
        }


        public string Exec_SQL_angajati(string sql)
        {
            string columnValue = "";

            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                columnValue = reader.GetInt32(0).ToString() + "\t" + reader.GetString(1) + "\t" + reader.GetString(2) + "\n";
            }

            return columnValue;
        }
    }
}
