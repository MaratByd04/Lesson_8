using System;

namespace Lesson_8.Exercise
{
    public enum ProjectStatus
    {
        Проект,
        Исполнение,
        Закрыт
    }
    public enum TaskStatus
    {
        Назначена,
        Выполняется,
        Обозревание,
        Завершена
    }
    class Program
    {
        static void Main()
        {
            Employee teamLead = new Employee("Руководитель группы");
            Employee developer1 = new Employee("Разработчик 1");
            Employee developer2 = new Employee("Разработчик 2");
            Employee qaEngineer1 = new Employee("Инженер по контролю качества 1");
            Employee qaEngineer2 = new Employee("Инженер по контролю качества 2");
            Employee initiator = new Employee("Инициатор");
            Employee reviewer = new Employee("Рецензент");
            Employee employee7 = new Employee("Работник 7");
            Employee employee8 = new Employee("Работник 8");
            Employee employee9 = new Employee("Работник 9");
            Employee employee10 = new Employee("Работник 10");

            Project project = new Project("Примерный проект", DateTime.Now.AddDays(30), initiator, teamLead);

            project.CreateTask("Задача 1", DateTime.Now.AddDays(10), developer1);
            project.CreateTask("Задача 2", DateTime.Now.AddDays(15), developer2);
            project.CreateTask("Задача 3", DateTime.Now.AddDays(20), qaEngineer1);
            project.CreateTask("Задача 4", DateTime.Now.AddDays(25), qaEngineer2);
            project.CreateTask("Задача 5", DateTime.Now.AddDays(10), employee7);
            project.CreateTask("Задача 6", DateTime.Now.AddDays(15), employee8);
            project.CreateTask("Задача 7", DateTime.Now.AddDays(20), employee9);
            project.CreateTask("Задача 8", DateTime.Now.AddDays(25), employee10);

            project.TransitionToExecution();

            foreach (var task in project.Tasks)
            {
                task.StartTask();
                task.CompleteTask();
                task.AddReport("Задача Выполнена.");
            }

            if (project.IsClosed())
            {
                project.Status = ProjectStatus.Закрыт;
            }
            project.PrintProjectInfo();
            Console.WriteLine("Статус проекта: " + project.Status);
        }
    }
}

