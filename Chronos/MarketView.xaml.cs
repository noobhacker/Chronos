using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            this.DataContext = vm;
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
