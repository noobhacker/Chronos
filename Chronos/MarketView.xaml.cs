using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MarketView : Page
    {
        MarketViewModel vm = new MarketViewModel();
        public MarketView()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string response = await WebAPIClass.GetJsonFromServerAsync("MarketItem");
            var _vm = JsonConvert.DeserializeObject<MarketViewModel>(response);
            vm = _vm;

            gridview.ItemsSource = vm.itemList;
        }

        private void sellBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddMarketItemView));
        }
    }
}
