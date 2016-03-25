using Chronos.FoursquareJson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos
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

    public class FoodListItem
    {
        public FoursquareRootObject JsonRootObject { get; set; } // to pass to next page
        
        public string ImageUrl { get; set; }
        public string LocationName { get; set; }
        public string Category { get; set; }
        public int Distance { get; set; }
    }

    public class PlacesViewModel
    {
        public ObservableCollection<HapListItem> hapList
            = new ObservableCollection<HapListItem>();

        public ObservableCollection<FoodListItem> foodList
            = new ObservableCollection<FoodListItem>();
    }
}
