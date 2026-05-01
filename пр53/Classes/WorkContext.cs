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
    public class WorkContext : Work
    {
        /// <summary> Конструктор для заполнения объектов
        public WorkContext(int Id, int IdDiscipline, int IdType, DateTime Date, string Name, int Semester) :
            base(Id, IdDiscipline, IdType, Date, Name, Semester)
        { }

        /// <summary> Получение всех работ
        public static List<WorkContext> AllWorks()
        {
            // Коллекция работ
            List<WorkContext> allWorks = new List<WorkContext>();
            // Открываем соединение
            MySqlConnection connection = Connection.OpenConnection();
            // Выполняем запрос
            MySqlDataReader BDWorks = Connection.Query("SELECT * FROM `work` ORDER BY `Date`", connection);
            // Читаем данные из БД
            while (BDWorks.Read())
            {
                // Добавляем данные в коллекцию
                allWorks.Add(new WorkContext(
                    BDWorks.GetInt32(0),
                    BDWorks.GetInt32(1),
                    BDWorks.GetInt32(2),
                    BDWorks.GetDateTime(3),
                    BDWorks.GetString(4),
                    BDWorks.GetInt32(5)));
            }
            // Закрываем подключение
            Connection.CloseConnection(connection);
            // Возвращаем коллекцию работ
            return allWorks;
        }
    }
}
