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
    public sealed partial class PrivateMessageView : Page
    {
        PrivateMessageViewModel vm = new PrivateMessageViewModel();
        public PrivateMessageView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ActualWidth > 1024)
            {
                secondColumn.Width = new GridLength(1, GridUnitType.Star);
                secondaryFrame.Navigate(typeof(PostMessageView));
            }
            else
            {
                secondColumn.Width = GridLength.Auto;
                this.Frame.Navigate(typeof(PostMessageView));
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string response = await WebAPIClass.GetJsonFromServerAsync("PrivateMessage", GlobalVariables.CurrentUser.Id.ToString());

            vm = JsonConvert.DeserializeObject<PrivateMessageViewModel>(response);

            listview.ItemsSource = vm.inboxList;
        }
    }
}
