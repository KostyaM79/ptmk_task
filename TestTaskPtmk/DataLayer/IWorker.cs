using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IWorker
    {
        string FullName { get; set; }

        DateTime DateOfBirth { get; set; }

        string Sex { get; set; }

        int GetAge();
    }
}
