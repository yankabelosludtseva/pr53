using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using пр53.Classes.Common;
using пр53.Models;

namespace пр53.Classes
{
    public class GroupContext : Group
    {
        /// <summary> Конструктор для контекста групп
        public GroupContext(int Id, string Name) : base(Id, Name) { }

        /// <summary> Получение всех групп из БД
        public static List<GroupContext> AllGroups()
        {
            // Коллекция групп
            List<GroupContext> allGroups = new List<GroupContext>();
            // Открываем соединение
            MySqlConnection connection = Connection.OpenConnection();
            // Выполняем запрос
            MySqlDataReader BDGroups = Connection.Query("SELECT * FROM `group` ORDER BY `Name`", connection);
            // Читаем данные из БД
            while (BDGroups.Read())
            {
                // Добавляем данные в коллекцию
                allGroups.Add(new GroupContext(
                    BDGroups.GetInt32(0),
                    BDGroups.GetString(1)));
            }
            // Закрываем подключение
            Connection.CloseConnection(connection);
            // Возвращаем группы
            return allGroups;
        }
    }
}
