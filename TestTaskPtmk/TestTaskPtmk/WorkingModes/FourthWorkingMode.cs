using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    /// <summary>
    /// Четвёртый режим
    /// </summary>
    public class FourthWorkingMode : WorkingMode
    {
        public FourthWorkingMode()
        {
            ModeId = "4";
        }

        /// <summary>
        /// Создаёт 1 000 000 объектов и отправляет их в базу данных
        /// </summary>
        /// <param name="args"></param>
        /// <param name="db"></param>
        /// <returns></returns>
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
