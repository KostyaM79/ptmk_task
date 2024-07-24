using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    /// <summary>
    /// Первый режим
    /// </summary>
    public class FirstWorkingMode : WorkingMode
    {
        public FirstWorkingMode()
        {
            ModeId = "1";
        }

        /// <summary>
        /// Создаёт таблицу в базе данных и возвращает сообщение о результатах операции
        /// </summary>
        /// <param name="args"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override string Run(string[] args, IDataBase db)
        {
            if (db.CreateWorkersTable())
                return "Таблица успешно создана!";
            else
                return "Нет необходимости создавать таблицу, так как она уже имеется в БД!";
        }
    }
}
