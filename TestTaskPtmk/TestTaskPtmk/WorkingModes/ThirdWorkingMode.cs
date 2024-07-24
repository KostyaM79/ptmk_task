using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    /// <summary>
    /// Третий режим
    /// </summary>
    public class ThirdWorkingMode : WorkingMode
    {
        public ThirdWorkingMode()
        {
            ModeId = "3";
        }

        /// <summary>
        /// Получает из базы данных уникальных Worker и выводит их на консоль
        /// </summary>
        /// <param name="args"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override string Run(string[] args, IDataBase db)
        {
            WorkersCollection workers = new WorkersCollection();
            db.GetWorkers(workers);
            Report.CreateReport(workers.Workers);
            return "OK";
        }

        
    }
}
