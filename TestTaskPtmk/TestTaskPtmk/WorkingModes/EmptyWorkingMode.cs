using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    public class EmptyWorkingMode : WorkingMode
    {
        public EmptyWorkingMode()
        {
            ModeId = "0";
        }

        public override string Run(string[] args, IDataBase db)
        {
            throw new NotImplementedException();
        }
    }
}
