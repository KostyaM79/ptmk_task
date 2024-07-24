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
    /// <summary>
    /// Второй режим
    /// </summary>
    public class SecondWorkingMode : WorkingMode
    {
        public SecondWorkingMode()
        {
            ModeId = "2";
        }

        /// <summary>
        /// Создаёт объект Worker на основе переданных аргументов и отправляет его в базу данных,
        /// выводит данные добавленного Worker
        /// </summary>
        /// <param name="args"></param>
        /// <param name="db"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Проверяет количество аргументов
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private bool IsValid(string[] args)
        {
            return args.Length == 4;
        }
    }
}
