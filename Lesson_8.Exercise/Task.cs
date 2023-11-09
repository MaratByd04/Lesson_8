using System;
using System.Collections.Generic;

namespace Lesson_8.Exercise
{
    internal class Task
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Initiator { get; set; }
        public Employee Assignee { get; set; }
        public TaskStatus Status { get; set; }
        public List<Report> Reports { get; } = new List<Report>();

        public Task(string description, DateTime deadline, Employee initiator, Employee assignee)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Assignee = assignee;
            Status = TaskStatus.Назначена;
        }

        public void StartTask()
        {
            if (Status == TaskStatus.Назначена)
            {
                Status = TaskStatus.Выполняется;
            }
            else
            {
                Console.WriteLine("Не удается запустить задачу, которая не находится в статусе *Назначена*.");
            }
        }

        public void CompleteTask()
        {
            if (Status == TaskStatus.Выполняется)
            {
                Status = TaskStatus.Завершена;
            }
            else
            {
                Console.WriteLine("Не удается выполнить задачу, которая не находится в состоянии *Выполняется*.");
            }
        }

        public void DelegateTask(Employee newAssignee)
        {
            if (Status == TaskStatus.Назначена)
            {
                Assignee = newAssignee;
            }
            else
            {
                Console.WriteLine("Невозможно делегировать задачу, которая не находится в статусе *Назначена*.");
            }
        }

        public void AddReport(string reportText)
        {
            Report report = new Report(reportText, DateTime.Now, Assignee);
            Reports.Add(report);
        }

    }
}
