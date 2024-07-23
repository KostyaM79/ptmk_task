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
        private readonly IReport report = new Report();

        protected IReport Report => report;

        public string ModeId { get; protected set; }

        public abstract string Run(string[] args, IDataBase db);
    }
}
