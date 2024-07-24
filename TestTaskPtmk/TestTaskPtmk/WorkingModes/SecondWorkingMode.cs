using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
            if (IsValid(args))
            {
                Worker worker = new Worker()
                {
                    FullName = args[1],
                    DateOfBirth = DateTime.Parse(args[2]),
                    Sex = args[3]
                };

                worker.SendToDataBase(db);

                Report.CreateReport(worker);

                return "OK";
            }

            return "Количество аргументов не соответствует данному режиму работы!";
        }

        

        private bool IsValid(string[] args)
        {
            return args.Length == 4;
        }
    }
}
