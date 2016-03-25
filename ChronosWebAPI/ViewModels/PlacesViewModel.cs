using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.ViewModels
{
    public class HapListItem
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string TimeText { get; set; }
        public string LocationText { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }

    }
    public class PlacesViewModel
    {
        public ObservableCollection<HapListItem> hapList
            = new ObservableCollection<HapListItem>();
    }
}
