using Webapp.Models;
using MySqlConnector;

namespace Webapp.dal
{
    public class BodyDataDAL
    {
        private MySqlConnection connection;

        public BodyDataDAL()
        {
            connection = new MySqlConnection("server=192.168.44.122;user=marwan;password=marwan;database=challenge");
        }

        public List<BodyDataViewModel> getBodyDatas()
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM bodydata";
                List<BodyDataViewModel> bodyDatas = new List<BodyDataViewModel>();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bodyDatas.Add(new BodyDataViewModel() { id = Convert.ToInt32(reader["id"]), temperature = Convert.ToInt32(reader["temperature"]), heat = Convert.ToDouble(reader["heat"]) });
                    }
                }
                return bodyDatas;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
