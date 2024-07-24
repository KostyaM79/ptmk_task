using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    /// <summary>
    /// Представляет работника
    /// </summary>
    public class Worker : IWorker
    {
        /// <summary>
        /// Полное имя работника
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Дата рождения работника
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Пол работника
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Возарвщает возраст работника
        /// </summary>
        /// <returns></returns>
        public int GetAge()
        {
            int years = DateTime.Today.Year - DateOfBirth.Year;
            DateTime newDate = DateOfBirth.AddYears(years);
            return newDate > DateTime.Today ? years - 1 : years;
        }

        /// <summary>
        /// Отправляет данные в базу данных
        /// </summary>
        /// <param name="db"></param>
        public void SendToDataBase(IDataBase db)
        {
            db.CreateOneRecord(FullName, DateOfBirth, Sex);
        }
    }
}
