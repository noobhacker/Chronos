using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
{
    public class ConfessionList
    {
        public int Id { get; set; } //hold id for likes target
        public string Message { get; set; }
        public int Likes { get; set; }
        public DateTime PostDateTime { get; set; }
        public string PostDateTimeText { get; set; }
    }
    public class ConfessionViewModel
    {
        public ObservableCollection<ConfessionList> confessionList = new ObservableCollection<ConfessionList>();
        public string PostMessage { get; set; }
        public Student student { get; set; }
        public ConfessionViewModel()
        {
            //stud = GlobalVariables.CurrentUser;
        }
    }
}
