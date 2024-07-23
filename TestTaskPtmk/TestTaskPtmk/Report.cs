using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    public class Report : IReport
    {
        public void CreateReport(IWorker worker)
        {
            Console.WriteLine($" Name: {worker.FullName, -34}\t|Date of birth: {worker.DateOfBirth,-10:d}\t|Sex: {worker.Sex, -6}\t|Age: {worker.GetAge()}");
        }

        public void CreateReport(IWorker[] workers)
        {
            foreach (IWorker w in workers)
                CreateReport(w);
        }
    }
}
