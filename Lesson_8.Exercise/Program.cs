using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8.Exercise
{
    enum ProjectStatus
    {
        Project,
        Execution,
        Closed
    }
    enum TaskStatus
    {
        Назначена,
        Выполняется,
        Рассматривается,
        Выполнена
    }
    class Program
    {
        static void PrintProjectInfo(Project project)
        {
            Console.WriteLine($"Проект: {project.Description}");
            Console.WriteLine($"Сроки: {project.Deadline}");
            Console.WriteLine($"Инициатор: {project.Initiator}");
            Console.WriteLine($"Ответственный за проект: {project.ProjectLead}");
            Console.WriteLine("Задачи:");
            foreach (var task in project.Tasks)
            {
                Console.WriteLine($"- {task.Description} (Статус: {task.Status})");
            }
        }
        static void Main(string[] args)
        {
            List<string> teamMembers = new List<string>
            {
                "Ваня", "Анна", "Алексей", "Илюша", "Карим",
                "Марат", "Егор", "Настя", "Амир", "Камиля"
            };
            List<string> tasks = new List<string>
            {
                "Приносить кофе", "Программирование", "Подметать пол", "Бить в баклуши", "Работать над дизайном",
                "Действительно работать", "Стоять над душой", "Устранять ошибки", "Руководство всеми", "Составление плана"
            };

            Project project = new Project
            {
                Description = "Разработка современных приложений",
                Deadline = new DateTime(2023, 12, 31),
                Initiator = "Крупный инвестор",
                ProjectLead = "Ганиев Марат",
                Status = ProjectStatus.Project,
                Tasks = new List<Task>()
            };

            foreach (var member in teamMembers)
            {
                foreach (var _task in tasks)
                {
                    Task task = new Task
                    {
                        Description = $"Задача *{_task}* для {member}",
                        Deadline = new DateTime(2023, 11, 15),
                        Initiator = "Руководитель проекта",
                        Assignee = member,
                        Status = TaskStatus.Назначена,
                        Reports = new List<Report>()                     
                    };
                    project.Tasks.Add(task);
                    continue;
                }    
            }
            PrintProjectInfo(project);
        }
    }
}


