using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace пр53.Models
{
    public class Group
    {
        /// <summary> Код группы
        public int Id { get; set; }

        /// <summary> Наименование группы
        public string Name { get; set; }

        /// <summary> Конструктор для групп
        public Group(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
