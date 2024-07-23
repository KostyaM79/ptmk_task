using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    public class SecondWorkingMode : WorkingMode
    {
        public SecondWorkingMode()
        {
            ModeId = "2";
        }

        public override string Run(string[] args, IDataBase db)
        {
            throw new NotImplementedException();
        }
    }
}
