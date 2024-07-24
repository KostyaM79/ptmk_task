using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    
    /// <summary>
    /// Выводит в нонсоль данные в виде таблицы
    /// </summary>
    public class ConsoleReport : IReport
    {
        /// <summary>
        /// Выводит данные одного Worker
        /// </summary>
        /// <param name="worker"></param>
        public void CreateReport(IWorker worker)
        {
            Console.WriteLine($" Name: {worker.FullName, -34}\t|Date of birth: {worker.DateOfBirth,-10:d}\t|Sex: {worker.Sex, -6}\t|Age: {worker.GetAge()}");
        }

        /// <summary>
        /// Выводит массив Worker
        /// </summary>
        /// <param name="workers"></param>
        public void CreateReport(IWorker[] workers)
        {
            foreach (IWorker w in workers)
                CreateReport(w);
        }
    }
}
