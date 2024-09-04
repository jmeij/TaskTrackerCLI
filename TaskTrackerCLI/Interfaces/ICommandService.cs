using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerCLI.Interfaces
{
    internal interface ICommandService
    {
        public void HandleCommand(string[] args);
    }
}
