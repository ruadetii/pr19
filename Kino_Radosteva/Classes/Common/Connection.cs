using MySql.Data.MySqlClient;

namespace Kino_Radosteva.Classes.Common
{
    public class Connection
    {
        public static readonly string config = "server=localhost;uid=root;database=pr19";
        public MySqlConnection OpenConnection() 
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();

            return connection;
        }

        public MySqlDataReader Query(string SQL, MySqlConnection connection) 
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }

        public void CloseConnection(MySqlConnection connection) 
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
