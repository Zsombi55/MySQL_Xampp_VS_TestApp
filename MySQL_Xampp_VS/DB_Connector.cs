using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySQL_Xampp_VS
{
	public class DB_Connector
	{
        private MySqlConnection connection;
        private string server;
        private string database;
        private string username;
        private string password;

        /// <summary>
        /// Constructor, calls the initializer function.
        /// </summary>
        public DB_Connector()
        {
            Initialize();
        }

        /// <summary>
        /// Sets the specified connection credentials.
        /// </summary>
        private void Initialize()
        {
            server = "localhost";
            database = "my_New_Test_Data_Base";
            username = "root";
            password = "";

            string connectionString;
            connectionString = $"SERVER={server};" + $"DATABASE={database};" +
                $"USERNAME={username};" + $"PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Attempting to establish connection to server & database.
        /// </summary>
        /// <returns>Boolean: was it succesful?</returns>
        /// <exception>MySqlException: something went wrong while trying to make connection.</exception>
        /// <remarks>The two most common error numbers are:
        ///     0 (cannot connect to server) and
        ///     1045 (invalid user credentials
        /// </remarks>
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Error code: 0 .  Contact administrator.");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password. Error code: 1045 . Please try again.");
                        break;
                    default:
                        Console.WriteLine($"ERROR.. code: {ex.Number} .\n{ex.Message}");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"ERROR..\n{ex.Message}");
                return false;
            }
        }


        // Insert, Create.
        public void Insert(){}

        // Select, Read.
        public List <string> [] Select()
        {
            string query = "SELECT * FROM [myTestTable]";

            List< string >[] list = new List< string >[3];
            list[0] = new List< string >();
            list[1] = new List< string >();
            list[2] = new List< string >();

            
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
        
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["Id"].ToString());
                    list[1].Add(dataReader["Name"].ToString());
                    list[2].Add(dataReader["Age"].ToString());
                }

                dataReader.Close();
                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        // Update.
        public void Update(){}
        
        // Delete.
        public void Delete(){}
        

        // Count.
        public int Count(){ return 0; }
	}
}
