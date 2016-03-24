using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
{

    public class PostMessageViewModel
    {
        public Student student { get; set; } = GlobalVariables.CurrentUser;
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }
    }
}
