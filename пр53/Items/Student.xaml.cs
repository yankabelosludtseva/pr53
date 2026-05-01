using System;
using System.Collections.Generic;
using System.Windows.Controls;
using пр53.Classes;
using пр53.Pages;

namespace пр53.Items
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : UserControl
    {
        public Student(StudentContext student, Main main)
        {
            InitializeComponent();
            LoadStudentData(student, main);
        }

        /// <summary>
        /// Загрузка данных студента и расчёт статистики
        /// </summary>
        private void LoadStudentData(StudentContext student, Main main)
        {
            // Присваиваем значение в текстовое поле с ФИО
            TB_fio.Text = $"{student.Lastname} {student.Firstname}";

            // Активируем checkbox отчислен
            CBExpelled.IsChecked = student.Expelled;

            // Получаем дисциплины, в которых участвует студент
            List<DisciplineContext> studentDisciplines = main.AllDisciplines
                .FindAll(x => x.IdGroup == student.IdGroup);

            // Создаём переменные, отвечающие за расчёты
            int necessarilyCount = 0;  // Обязательных работ
            int worksCount = 0;         // Всего занятий
            int doneCount = 0;          // Выполненных работ
            int missedCount = 0;        // Пропущенных минут

            // Перебираем дисциплины
            foreach (DisciplineContext studentDiscipline in studentDisciplines)
            {
                // Подсчитаем кол-во работ, принадлежащих к группе студента
                // К обязательным работам относятся: [теоретические тесты], [экзамены] и [практические работы]
                List<WorkContext> studentWorks = main.AllWorks.FindAll(x =>
                    (x.IdType == 1 || x.IdType == 2 || x.IdType == 3) &&
                    x.IdDiscipline == studentDiscipline.Id);

                // Увеличиваем кол-во обязательных работ
                necessarilyCount += studentWorks.Count;

                // Перебираем обязательные работы
                foreach (WorkContext studentWork in studentWorks)
                {
                    EvaluationContext evaluation = main.AllEvaluation.Find(x =>
                        x.IdWork == studentWork.Id &&
                        x.IdStudent == student.Id);

                    // Проверяем: если есть оценка за занятие, она не пустая и не "2"
                    if (evaluation != null &&
                        !string.IsNullOrWhiteSpace(evaluation.Value) &&
                        evaluation.Value.Trim() != "2")
                    {
                        // Значит работа сдана
                        doneCount++;
                    }
                }
            }

            // Получаем все занятия, кроме экзамена и оценки за месяц
            List<WorkContext> allStudentWorks = main.AllWorks.FindAll(x =>
                x.IdType != 4 && x.IdType != 3);

            // Увеличиваем количество занятий
            worksCount += allStudentWorks.Count;

            // Перебираем занятия
            foreach (WorkContext studentWork in allStudentWorks)
            {
                // Получаем оценку к занятию с пропусками
                EvaluationContext evaluation = main.AllEvaluation.Find(x =>
                    x.IdWork == studentWork.Id &&
                    x.IdStudent == student.Id);

                // Если оценка не пустая и есть прогул
                if (evaluation != null && !string.IsNullOrWhiteSpace(evaluation.Lateness))
                {
                    // Добавляем его в общее кол-во пропущенных минут
                    if (int.TryParse(evaluation.Lateness.Trim(), out int minutes))
                        missedCount += minutes;
                }
            }

            // Выводим в ProgressBar: 100 / (кол-во занятий) * выполненные
            if (necessarilyCount > 0)
                doneWorks.Value = (100f / necessarilyCount) * doneCount;
            else
                doneWorks.Value = 0;

            // Выводим в ProgressBar: 100 / (кол-во занятий * 90 мин) * пропущенные минуты
            if (worksCount > 0)
                missedCountBar.Value = (100f / (worksCount * 90f)) * missedCount;
            else
                missedCountBar.Value = 0;

            // Отображаем название группы
            var group = main.AllGroups.Find(x => x.Id == student.IdGroup);
            if (group != null)
                TBGroup.Text = group.Name;
        }
    }
}