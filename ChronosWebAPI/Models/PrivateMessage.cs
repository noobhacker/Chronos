using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronosWebAPI.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }  
       
        public int SenderId { get; set; }
        
        public int ReceiverId { get; set; }
        public Student Student { get; set; }

        public DateTime SentDatetime { get; set; }
        public string Message { get; set; }
    }
}
