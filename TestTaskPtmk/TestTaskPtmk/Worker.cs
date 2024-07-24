using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    public class Worker : IWorker
    {
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Sex { get; set; }

        public int GetAge()
        {
            int years = DateTime.Today.Year - DateOfBirth.Year;
            DateTime newDate = DateOfBirth.AddYears(years);
            return newDate > DateTime.Today ? years - 1 : years;
        }

        public void SendToDataBase(IDataBase db)
        {
            db.CreateOneRecord(FullName, DateOfBirth, Sex);
        }
    }
}
