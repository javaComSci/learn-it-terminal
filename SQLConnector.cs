using System;
using System.IO;
using System.Data.SqlClient;

namespace learn_it_terminal {
    public class SQLConnector {

        private string connectionString = "Server=localhost, 1433;Database=LearnIt;User Id=SA;Password=1Secure*Password1";

        public void PutWord(string word){
            
            string commandText = "IF NOT EXISTS (SELECT * FROM Words WHERE Word = (@word)) INSERT INTO Words VALUES (@word)";
            // Console.WriteLine("PUTTING WORD HERE");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Console.WriteLine("IN THE CONNECTION");
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@word", word);
                try
                {
                    connection.Open();
                    int addedWord = command.ExecuteNonQuery();
                    // Console.WriteLine("ADDED WORD " + addedWord);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}