using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    class Program
    {
        private static WorkingModesCollection workingModes = new WorkingModesCollection();
        private static IDataBase dataBase = new DataBase();

        static void Main(string[] args)
        {
            WorkingMode mode = workingModes.GetWorkingMode(args[0]);
            //WorkingMode mode = workingModes.GetWorkingMode("1");
            Console.WriteLine(mode.Run(args, dataBase));
        }
    }
}
