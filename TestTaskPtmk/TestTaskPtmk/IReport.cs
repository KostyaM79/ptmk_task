﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace TestTaskPtmk
{
    public interface IReport
    {
        void CreateReport(IWorker worker);

        void CreateReport(IWorker[] workers);
    }
}
