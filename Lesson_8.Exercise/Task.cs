using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8.Exercise
{
    internal class Task
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Initiator { get; set; }
        public string Assignee { get; set; }
        public TaskStatus Status { get; set; }
        public List<Report> Reports { get; set; }
    }
}
