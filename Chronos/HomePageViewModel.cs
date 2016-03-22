﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
{
    public class SubjectTimeTable
    {
        public string SubjectText { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Lecturer { get; set; }
        public string ClassType { get; set; }
    }
    public class HomePageViewModel
    {
        ObservableCollection<SubjectTimeTable> laterGVItems = 
            new ObservableCollection<SubjectTimeTable>();
    }
}