using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.ViewModels
{
    public class CalendarViewModel
    {
        public ObservableCollection<Event> eventList =
            new ObservableCollection<Event>();

        public ObservableCollection<string> upcomingList =
            new ObservableCollection<string>();

        public Event input { get; set; }
        public Student student { get; set; }
        public CalendarViewModel()
        {
            student = GlobalVariables.CurrentUser;
            input = new Event();
        }
    }
}
