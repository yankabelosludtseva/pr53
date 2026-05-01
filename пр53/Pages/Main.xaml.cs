using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using пр53.Classes;

namespace пр53.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        /// <summary> Список всех групп из базы данных
        public List<GroupContext> AllGroups = GroupContext.AllGroups();

        /// <summary> Список всех студентов
        public List<StudentContext> AllStudents = StudentContext.AllStudent();

        /// <summary> Список всех работ
        public List<WorkContext> AllWorks = WorkContext.AllWorks();

        /// <summary> Список оценок студентов
        public List<EvaluationContext> AllEvaluation = EvaluationContext.AllEvaluations();

        /// <summary> Список дисциплин
        public List<DisciplineContext> AllDisciplines = DisciplineContext.AllDisciplines();

        public Main()
        {
            InitializeComponent();
            CreateGroupUI();
        }

        /// <summary> Добавление групп в выпадающий список
        public void CreateGroupUI()
        {
            // перебираем группы в списке и добавляем их в комбобокс
            foreach (GroupContext Group in AllGroups)
                CBBGroups.Items.Add(Group.Name);

            // добавляем последний элемент в список "Выберите ..."
            CBBGroups.Items.Add("Выберите");

            // Выбираем последний элемент в списке
            CBBGroups.SelectedIndex = CBBGroups.Items.Count - 1;
        }

        /// <summary> Добавление студентов в интерфейс
        public void CreateStudents(List<StudentContext> AllStudents)
        {
            // Очищаем список, потому что метод будет использоваться несколько раз
            Parent.Children.Clear();

            // Перебираем студентов
            foreach (StudentContext Student in AllStudents)
                // Добавляем студентов в список
                Parent.Children.Add(new Items.Student(Student, this));
        }

        /// <summary> Фильтрация студентов по группе
        private void SelectGroup(object sender, SelectionChangedEventArgs e)
        {
            // Проверяем что в списке выбрана группа, а не элемент "Выберите"
            if (CBBGroups.SelectedIndex != CBBGroups.Items.Count - 1)
            {
                // Получаем группу
                int IdGroup = AllGroups.Find(x => x.Name == CBBGroups.SelectedItem).Id;

                // Создаём студентов, из списка группы
                CreateStudents(AllStudents.FindAll(x => x.IdGroup == IdGroup));
            }
        }

        /// <summary> Поиск определённого студента
        private void SelectStudents(object sender, KeyEventArgs e)
        {
            // Получаем всех студентов
            List<StudentContext> SearchStudent = AllStudents;

            // Проверяем что в списке выбрана группа, а не элемент "Выберите"
            if (CBBGroups.SelectedIndex != CBBGroups.Items.Count - 1)
            {
                // Получаем группу
                int IdGroup = AllGroups.Find(x => x.Name == CBBGroups.SelectedItem).Id;

                // Фильтруем студентов по группе
                SearchStudent = AllStudents.FindAll(x => x.IdGroup == IdGroup);
            }

            // Сортируем отсортированных студентов, по ФИО
            CreateStudents(SearchStudent.FindAll(x => $"{x.Lastname} {x.Firstname}".Contains(TBFIO.Text)));
        }

        private void ReportGeneration(object sender, RoutedEventArgs e)
        {
            // Метод для генерации отчёта
        }
    }
}
