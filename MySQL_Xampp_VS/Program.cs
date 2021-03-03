/*
 * A simple Console Application that, connects to a MySQL database ran through Xampp.
 * Then justs reads the specified table line by line and prints it out.
 */

using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySQL_Xampp_VS
{
    class Program
    {
        private static string server;
        private static string database;
        private static string username;
        private static string password;

        static void Main(string[] args)
        {
            server = "localhost";
            database = "my_New_Test_Data_Base";
            username = "root";
            password = "";

            string connstring = $"SERVER={server};" + $"DATABASE={database};" +
                $"USERNAME={username};" + $"PASSWORD={password};";

            MySqlConnection conn = null;
            
            try
            {
                conn = new MySqlConnection(connstring);
                conn.Open();

                string query = "SELECT * FROM [myTestTable]";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                // Read per line then write it out, nothing fancy.
                while (reader.Read())
                {
                    //Console.WriteLine(
                    //    reader.GetString("Id") + "\t" + reader.GetString("Name") + "\t" + reader.GetString("Age"));

                    Console.WriteLine(
                        reader["Id"].ToString() + "\t" +
                        reader["Name"].ToString() + "\t" +
                        reader["Age"].ToString());

                    // NOTE: would be better to get "data" into a "box" then show the box "contents" instead.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR..\n{0}", e.ToString());
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}