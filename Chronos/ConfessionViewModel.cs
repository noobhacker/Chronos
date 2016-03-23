using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
{
    public class ConfessionTable
    {
        public string Message { get; set; }
        public string Likes { get; set; }
    }
    public class ConfessionViewModel
    {
        public ObservableCollection<ConfessionTable> confessionList = new ObservableCollection<ConfessionTable>();
    }
}
