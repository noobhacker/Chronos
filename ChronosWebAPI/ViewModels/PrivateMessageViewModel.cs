using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
{
    public class InboxItem
    {       
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
        public DateTime SentTime { get; set; }
        public string SentTimeText { get; set; }
    }

    public class PrivateMessageViewModel
    {
        public ObservableCollection<InboxItem> inboxList = new ObservableCollection<InboxItem>();
    }
}
