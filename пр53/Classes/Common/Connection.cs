using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр53.Classes.Common
{
    public class Connection
    {
        /// <summary> Строка с настройками для подключения
        public static string config = "server=127.0.0.1;uid=root;pwd=root;database=journal;";

        /// <summary> Открываем соединение
        public static MySqlConnection OpenConnection()
        {
            // Создаём подключение
            MySqlConnection connection = new MySqlConnection(config);
            // Открываем подключение
            connection.Open();
            // Возвращаем открытое подключение
            return connection;
        }

        /// <summary> Выполнение запроса
        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            // Выполняем запрос, возвращаем обратно
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }

        /// <summary> Закрытие соединения
        public static void CloseConnection(MySqlConnection connection)
        {
            // Закрываем подключение
            connection.Close();
            // Очищаем пул подключений
            MySqlConnection.ClearPool(connection);
        }
    }
}
