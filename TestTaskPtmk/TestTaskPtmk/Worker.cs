﻿using System;
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
    }
}