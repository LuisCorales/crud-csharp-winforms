using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DL_Connection
    {
        string server = "localhost";
        string port = "3306";
        string db = "-";
        string username = "-";
        string password = "-";

        MySqlConnection dbConnection;
        
        public MySqlConnection DBConnection => dbConnection;

        //Initialize connection to the server
        public DL_Connection()
        {
            string connectionString = "database=" + db + ";datasource=" + server + ";port=" + port + ";username=" + username + ";password=" + password + "";

            try
            {
                dbConnection = new MySqlConnection(connectionString);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //Opens the connection to the server
        public MySqlConnection OpenConnection()
        {
            if (DBConnection.State == ConnectionState.Closed)
                DBConnection.Open();

            return DBConnection;
        }

        //Closes the connection to the server
        public MySqlConnection CloseConnection()
        {
            if (DBConnection.State == ConnectionState.Open)
                DBConnection.Close();

            return DBConnection;
        }
    }

}