using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    /// <summary>
    /// Представляет коллекцию Worker
    /// </summary>
    public class WorkersCollection : IWorkersCollection
    {
        private List<IWorker> workers = new List<IWorker>();

        /// <summary>
        /// Возаращает массив Worker
        /// </summary>
        public IWorker[] Workers => workers.ToArray();

        /// <summary>
        /// Создаёт нового Worker и добавляет его в коллекцию
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="sex"></param>
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
