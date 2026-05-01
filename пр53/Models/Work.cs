using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр53.Models
{
    public class Work
    {
        /// <summary> Код
        public int Id { get; set; }

        /// <summary> Код дисциплины
        public int IdDiscipline { get; set; }

        /// <summary> Тип пары
        public int IdType { get; set; }

        /// <summary> Дата проведения занятия
        public DateTime Date { get; set; }

        /// <summary> Наименование занятия
        public string Name { get; set; }

        /// <summary> Семестр в котором было проведено занятие
        public int Semester { get; set; }

        /// <summary> Конструктор для заполнения объектов
        public Work(int Id, int IdDiscipline, int IdType, DateTime Date, string Name, int Semester)
        {
            this.Id = Id;
            this.IdDiscipline = IdDiscipline;
            this.IdType = IdType;
            this.Date = Date;
            this.Name = Name;
            this.Semester = Semester;
        }
    }
}
