using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskPtmk
{
    /// <summary>
    /// Пустой режим
    /// </summary>
    public class EmptyWorkingMode : WorkingMode
    {
        public EmptyWorkingMode()
        {
            ModeId = "0";
        }

        /// <summary>
        /// Возвращает сообщение о том, что режим не реализован
        /// </summary>
        /// <param name="args"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public override string Run(string[] args, IDataBase db)
        {
            return "Данный режим в настоящее время не реализован!";
        }
    }
}
