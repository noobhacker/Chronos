using ChronosWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.ViewModels
{
    public class MarketViewModel
    {
        public ObservableCollection<MarketItem> itemList = 
            new ObservableCollection<MarketItem>();
    }
}
