using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class SubjectTimeTable
    {
        public string SubjectText { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Lecturer { get; set; }
        public string ClassType { get; set; }
    }
}
