using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class SubjectSession
    {
        public int Id { get; set; }
        public int Day { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; } // default 1 hr, fixed
        public string SessionType { get; set; }
    }
}
