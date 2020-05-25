using System;
using System.IO;
using System.Data.SqlClient;

namespace learn_it_terminal {
    public class SQLConnector {

        string connectionString = "";
        
        public void PutWord(string word){

            string commandText = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@word", word);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}