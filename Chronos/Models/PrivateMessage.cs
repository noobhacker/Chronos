using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public Student Sender { get; set; }
        public Student Receiver { get; set; }
        public string Message { get; set; }
        public DateTime SentDatetime { get; set; }
    }
}
