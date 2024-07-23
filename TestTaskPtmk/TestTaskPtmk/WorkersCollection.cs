using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    public class WorkersCollection : IWorkersCollection
    {
        private List<IWorker> workers = new List<IWorker>();

        public IWorker[] Workers => workers.ToArray();

        public void Create(string fullName, DateTime dateOfBirth, string sex)
        {
            workers.Add(new Worker()
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                Sex = sex
            });
        }
    }
}
