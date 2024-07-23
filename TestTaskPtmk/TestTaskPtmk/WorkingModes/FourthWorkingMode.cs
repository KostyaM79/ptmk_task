using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk.WorkingModes
{
    public class FourthWorkingMode : WorkingMode
    {
        public FourthWorkingMode()
        {
            ModeId = "4";
        }

        public override string Run(string[] args, IDataBase db)
        {
            throw new NotImplementedException();
        }
    }
}
