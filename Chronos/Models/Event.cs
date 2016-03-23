using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Desc { get; set; }
        public int StudentId { get; set; }
    }
}
