using System;
using System.Collections.Generic;

namespace Lesson_8.Exercise
{
    internal class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Initiator { get; set; }
        public Employee ProjectLead { get; set; }
        public List<Task> Tasks { get; } = new List<Task>();
        public ProjectStatus Status { get; set; }

        public Project(string description, DateTime deadline, Employee initiator, Employee projectLead)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            ProjectLead = projectLead;
            Status = ProjectStatus.Проект;
        }

        public void CreateTask(string taskDescription, DateTime taskDeadline, Employee assignee)
        {
            if (Status == ProjectStatus.Проект)
            {
                Task task = new Task(taskDescription, taskDeadline, Initiator, assignee);
                Tasks.Add(task);
            }
            else
            {
                Console.WriteLine("Не удается создать задачу для проекта, который не находится в статусе *Проект*.");
            }
        }

        public void TransitionToExecution()
        {
            if (Tasks.Count > 0)
            {
                Status = ProjectStatus.Исполнение;
            }
            else
            {
                Console.WriteLine("Не удается перейти к выполнению без каких-либо назначенных задач.");
            }
        }

        public bool IsClosed()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Завершена)
                {
                    return false;
                }
            }
            return true;
        }
        public void PrintProjectInfo()
        {
            Console.WriteLine("Project Information:");
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("Deadline: " + Deadline);
            Console.WriteLine("Initiator: " + Initiator.Name);
            Console.WriteLine("Project Lead: " + ProjectLead.Name);
            Console.WriteLine("Status: " + Status);
            Console.WriteLine("Tasks:");

            foreach (var task in Tasks)
            {
                Console.WriteLine("  Task Description: " + task.Description);
                Console.WriteLine("  Task Deadline: " + task.Deadline);
                Console.WriteLine("  Task Initiator: " + task.Initiator.Name);
                Console.WriteLine("  Task Assignee: " + task.Assignee.Name);
                Console.WriteLine("  Task Status: " + task.Status);
                Console.WriteLine("  Task Reports:");
                foreach (var report in task.Reports)
                {
                    Console.WriteLine("    Report Date: " + report.Date);
                    Console.WriteLine("    Report Performer: " + report.Performer.Name);
                    Console.WriteLine("    Report Text: " + report.Text);
                }
            }
        }
    }
}
