using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    public class FourthWorkingMode : WorkingMode
    {
        public FourthWorkingMode()
        {
            ModeId = "4";
        }

        public override string Run(string[] args, IDataBase db)
        {
            WorkersCollection workers = new WorkersCollection();
            NameGenerator nameGenerator = new NameGenerator();
            nameGenerator.Generate(workers, 1000000);
            db.CreateRecordsSet(workers.Workers);
            return "OK";
        }
    }
}
