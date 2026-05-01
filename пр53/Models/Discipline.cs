using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр53.Models
{
    public class Discipline
    {
        /// <summary> Код
        public int Id { get; set; }

        /// <summary> Наименование
        public string Name { get; set; }

        /// <summary> Код группы
        public int IdGroup { get; set; }

        /// <summary> Конструктор для заполнения объекта
        public Discipline(int Id, string Name, int IdGroup)
        {
            this.Id = Id;
            this.Name = Name;
            this.IdGroup = IdGroup;
        }
    }
}
