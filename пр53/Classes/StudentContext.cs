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
    public class StudentContext : Student
    {
        /// <summary> Конструктор для контекста студента
        public StudentContext(int Id, string Firstname, string Lastname, int IdGroup, bool Expelled, DateTime DateExpelled) :
            base(Id, Firstname, Lastname, IdGroup, Expelled, DateExpelled)
        { }

        /// <summary> Получение студентов из базы данных
        public static List<StudentContext> AllStudent()
        {
            // Коллекция студентов
            List<StudentContext> allStudent = new List<StudentContext>();
            // Открываем соединение
            MySqlConnection connection = Connection.OpenConnection();
            // Выполняем запрос
            MySqlDataReader BDStudents = Connection.Query("SELECT * FROM `student` ORDER BY `LastName`", connection);
            // Читаем данные из БД
            while (BDStudents.Read())
            {
                // Добавляем данные в коллекцию
                allStudent.Add(new StudentContext(
                    BDStudents.GetInt32(0),
                    BDStudents.GetString(1),
                    BDStudents.GetString(2),
                    BDStudents.GetInt32(3),
                    BDStudents.GetBoolean(4),
                    BDStudents.IsDBNull(5) ? DateTime.Now : BDStudents.GetDateTime(5)
                ));
            }
            // Закрываем подключение
            Connection.CloseConnection(connection);
            // Возвращаем группы
            return allStudent;
        }
    }
}
