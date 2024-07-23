using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TestTaskPtmk
{
    public class WorkingModesCollection
    {
        List<WorkingMode> workingModes = new List<WorkingMode>();

        public WorkingModesCollection()
        {
            CollectionInitialize();
        }

        public WorkingMode GetWorkingMode(string modeId)
        {
            return workingModes.SingleOrDefault(m => m.ModeId == modeId) ?? workingModes.SingleOrDefault(m => m.ModeId == "0");
        }

        private void CollectionInitialize()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(WorkingMode));                              // Получаем сборку, содержащую класс WorkingMode
            Type[] types = assembly.GetTypes();                                                         // Получаем все типы сборки
            Type[] modesTypes = types.Where(t => t.BaseType == typeof(WorkingMode)).ToArray();          // Получаем только типы режимов работы
            foreach (Type t in modesTypes)
                workingModes.Add(t.GetConstructor(new Type[] { }).Invoke(new object[] { }) as WorkingMode);
        }
    }
}
