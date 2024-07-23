using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    public class ThirdWorkingMode : WorkingMode
    {
        public ThirdWorkingMode()
        {
            ModeId = "3";
        }

        public override string Run(string[] args, IDataBase db)
        {
            throw new NotImplementedException();
        }
    }
}
