using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uchet_abonetnov_ATC
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server = 37.140.192.92; port = 3306; username = u1016723_vladimi; password = Dibikuper321; database = u1016723_technology_project; charset=utf8");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)                               //установка связи с удаленной базой данных
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
