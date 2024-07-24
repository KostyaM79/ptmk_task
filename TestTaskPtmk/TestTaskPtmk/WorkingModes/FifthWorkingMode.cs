using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    /// <summary>
    /// Пятый режим
    /// </summary>
    public class FifthWorkingMode : WorkingMode
    {
        public FifthWorkingMode()
        {
            ModeId = "5";
        }

        /// <summary>
        /// Получает из базы данных записи, где ФИО начинается с F и пол - Male,
        /// также выводит время выполнения запроса
        /// </summary>
        /// <param name="args"></param>
        /// <param name="db"></param>
        /// <returns></returns>
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
