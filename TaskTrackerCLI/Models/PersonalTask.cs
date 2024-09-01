using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI.Models
{
    internal class PersonalTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        todo = 0,
        inProgress = 1,
        done = 2
    }
}
