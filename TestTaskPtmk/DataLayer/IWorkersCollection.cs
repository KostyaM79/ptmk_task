using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IWorkersCollection
    {
        void Create(string fullName, DateTime dateOfBirth, string sex);

        IWorker[] Workers { get; }
    }
}
