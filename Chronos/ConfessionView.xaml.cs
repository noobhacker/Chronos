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
            vm = JsonConvert.DeserializeObject<ConfessionViewModel>(response);
            listview.ItemsSource = vm.confessionList;

            if (vm.student.DailyConfessionChance == 0)
                postTB.Visibility = Visibility.Collapsed;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            refreshList();
        }

        private async void postBtn_Click(object sender, RoutedEventArgs e)
        {
            var _vm = vm;
            // remove entries downloaded before upload
            // don't post message only because need student for auth
            _vm.confessionList = new ObservableCollection<ConfessionList>(); 
            await WebAPIClass.PostJsonToServerAsync(_vm, "Confession");

            refreshList();
        }
    }
}
