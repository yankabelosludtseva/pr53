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
    public class DisciplineContext : Discipline
    {
        /// <summary> Конструктор для заполнения объекта
        public DisciplineContext(int Id, string Name, int IdGroup) : base(Id, Name, IdGroup) { }

        /// <summary> Получение всех дисциплин
        public static List<DisciplineContext> AllDisciplines()
        {
            // Коллекция предметов
            List<DisciplineContext> allDisciplines = new List<DisciplineContext>();
            // Открываем соединение
            MySqlConnection connection = Connection.OpenConnection();
            // Выполняем запрос
            MySqlDataReader BDDisciplines = Connection.Query("SELECT * FROM `discipline` ORDER BY `Name`;", connection);
            // Читаем данные из БД
            while (BDDisciplines.Read())
            {
                // Добавляем данные в коллекцию
                allDisciplines.Add(new DisciplineContext(
                    BDDisciplines.GetInt32(0),
                    BDDisciplines.GetString(1),
                    BDDisciplines.GetInt32(2)));
            }
            // Закрываем подключение
            Connection.CloseConnection(connection);
            // Возвращаем дисциплины
            return allDisciplines;
        }
    }
}
