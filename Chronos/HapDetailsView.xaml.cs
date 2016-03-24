using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HapDetailsView : Page
    {
        HapDetailsViewModel vm = new HapDetailsViewModel();
        public HapDetailsView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string result = await WebAPIClass.GetJsonFromServerAsync("HapDetails", e.Parameter.ToString());
            vm = JsonConvert.DeserializeObject<HapDetailsViewModel>(result);

            updateInfo();
        }
        private void updateInfo()
        {
             titleTB.Text = vm.HapDetails.Name;

            posterImg.Source = new BitmapImage(
                new Uri(vm.HapDetails.ImageUrl));

            locationTB.Text = vm.HapDetails.Location;
            startTimeTB.Text = vm.HapDetails.StartDateTime.ToString();
            endTimeTB.Text = vm.HapDetails.EndDateTime.ToString();
            priceTB.Text = vm.HapDetails.Price == 0? "FREE" : "RM " + vm.HapDetails.Price.ToString();
            descTB.Text = vm.HapDetails.Description;
            organizerTB.Text = vm.HapDetails.Organizer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void fbBtn_Click(object sender, RoutedEventArgs e)
        {
            Launcher.LaunchUriAsync(new Uri(vm.HapDetails.FbUrl));
        }
    }
}
