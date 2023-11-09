using System;

namespace Lesson_8.Exercise
{
    internal class Report
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Employee Performer { get; set; }

        public Report(string text, DateTime date, Employee performer)
        {
            Text = text;
            Date = date;
            Performer = performer;
        }

    }
}
