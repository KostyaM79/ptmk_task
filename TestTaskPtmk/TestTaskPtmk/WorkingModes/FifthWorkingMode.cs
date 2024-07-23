using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk.WorkingModes
{
    public class FifthWorkingMode : WorkingMode
    {
        public FifthWorkingMode()
        {
            ModeId = "5";
        }

        public override string Run(string[] args, IDataBase db)
        {
            throw new NotImplementedException();
        }
    }
}
