using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataBase
    {
        bool CreateWorkersTable();

        void CreateOneRecord(string fullName, DateTime dateOfBirth, string sex);

        void GetWorkers(IWorkersCollection workers);

        void GetWorkers(IWorkersCollection workers, string nameExpression, string sex);

        void CreateRecordsSet(IWorker[] workers);
    }
}
