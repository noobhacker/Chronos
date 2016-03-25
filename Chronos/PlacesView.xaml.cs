using Newtonsoft.Json;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlacesView : Page
    {
        PlacesViewModel vm = new PlacesViewModel();

        public PlacesView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string response = await WebAPIClass.GetJsonFromServerAsync("Places","");
            vm = JsonConvert.DeserializeObject<PlacesViewModel>(response);
            hapListview.ItemsSource = vm.hapList;

            var result = await FoursquareClass.GetFoursquareFoodAsync();

            foreach (var v in result.response.venues)
                vm.foodList.Add(new FoodListItem()
                {
                    JsonRootObject = result,
                    ImageUrl = "", //throw notimplementedexception
                    Category = v.categories.Count != 0 ? v.categories[0].name : "",
                    Distance = v.location.distance,
                    LocationName = v.name
                });

            foodGV.ItemsSource = vm.foodList.OrderBy(x => x.Distance).ToList();
            loading.IsActive = false;
        }

        private void hapListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Frame.Navigate(typeof(HapDetailsView), hapListview.SelectedIndex + 1);
        }
    }
}
