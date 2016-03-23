using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConfessionView : Page
    {
        ConfessionViewModel vm = new ConfessionViewModel();
        public ConfessionView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        private async void refreshList()
        {
            string response = await WebAPIClass.GetJsonFromServerAsync("Confession");
            var _vm = JsonConvert.DeserializeObject<ConfessionViewModel>(response);
            vm.confessionList = _vm.confessionList;
            listview.ItemsSource = vm.confessionList;

            if (GlobalVariables.CurrentUser.DailyConfessionChance == 0)
                postTB.Visibility = Visibility.Collapsed;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            refreshList();
        }

        private async void postBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.PostMessage = postTB.Text; // remove this after binding is working
            var _vm = vm;
            // remove entries downloaded before upload
            // don't post message only because need student for auth
            _vm.confessionList = new ObservableCollection<ConfessionList>(); 
            await WebAPIClass.PostJsonToServerAsync(_vm, "Confession");

            refreshList();
        }
    }
}
