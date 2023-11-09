using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8.Exercise
{
    internal class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Initiator { get; set; }
        public string ProjectLead { get; set; }
        public List<Task> Tasks { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
