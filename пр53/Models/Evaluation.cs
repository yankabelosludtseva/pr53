using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр53.Models
{
    public class Evaluation
    {
        /// <summary> Код
        public int Id { get; set; }

        /// <summary> Код работы
        public int IdWork { get; set; }

        /// <summary> Код студента
        public int IdStudent { get; set; }

        /// <summary> Оценка
        public string Value { get; set; }

        /// <summary> Опоздание
        public string Lateness { get; set; }

        /// <summary> Конструктор для заполнения объекта
        public Evaluation(int Id, int IdWork, int IdStudent, string Value, string Lateness)
        {
            this.Id = Id;
            this.IdWork = IdWork;
            this.IdStudent = IdStudent;
            this.Value = Value;
            this.Lateness = Lateness;
        }
    }
}
