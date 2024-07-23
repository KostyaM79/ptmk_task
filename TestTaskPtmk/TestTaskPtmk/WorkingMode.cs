using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    public abstract class WorkingMode
    {
        public string ModeId { get; protected set; }

        public abstract string Run(string[] args, IDataBase db);
    }
}
