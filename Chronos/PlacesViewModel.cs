using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
{
    public class EventList
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string TimeText { get; set; }
        public string LocationText { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

    }
    public class PlacesViewModel
    {
        public ObservableCollection<EventList> eventList
            = new ObservableCollection<EventList>();
    }
}
