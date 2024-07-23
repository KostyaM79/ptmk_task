using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    public class FifthWorkingMode : WorkingMode
    {
        public FifthWorkingMode()
        {
            ModeId = "5";
        }

        public override string Run(string[] args, IDataBase db)
        {
            WorkersCollection workers = new WorkersCollection();

            DateTime startTime = DateTime.Now;

            db.GetWorkers(workers, "F%", "Male");

            DateTime endTime = DateTime.Now;

            Report.CreateReport(workers.Workers);

            Console.WriteLine($"Время выполнения запроса: {(endTime-startTime).TotalSeconds}");

            return "OK";
        }
    }
}
