using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class Confession
    {
        public int Id { get; set; }
        public DateTime PostDateTime { get; set; }
        public Student PostedBy { get; set; }
    }
}
