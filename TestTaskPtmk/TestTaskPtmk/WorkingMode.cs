using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    /// <summary>
    /// Базовый класс для режимов работы
    /// </summary>
    public abstract class WorkingMode
    {
        // Объект, формирующий отчёт
        private readonly IReport report = new ConsoleReport();

        protected IReport Report => report;

        /// <summary>
        /// Идентификатор режима работы
        /// </summary>
        public string ModeId { get; protected set; }

        /// <summary>
        /// Абстрактный метод.
        /// В производном классе запускает работу
        /// </summary>
        /// <param name="args"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public abstract string Run(string[] args, IDataBase db);
    }
}
