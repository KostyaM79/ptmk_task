using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    public class FirstWorkingMode : WorkingMode
    {
        public FirstWorkingMode()
        {
            ModeId = "1";
        }

        public override string Run(string[] args, IDataBase db)
        {
            if (db.CreateWorkersTable())
                return "Таблица успешно создана!";
            else
                return "Нет необходимости создавать таблицу, так как она уже имеется в БД!";
        }
    }
}
