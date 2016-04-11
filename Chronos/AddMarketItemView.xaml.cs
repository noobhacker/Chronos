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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Chronos.ViewModels;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddMarketItemView : Page
    {
        AddMarketItemViewModel vm = new AddMarketItemViewModel();
        public AddMarketItemView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        // if implement notifychaged in mvvm will upload
        // twice amount of data to cloud
        #region Update previews
        private void itemNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            previewNameTB.Text = itemNameTB.Text;
        }

        private void priceTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            previewPriceTB.Text = priceTB.Text;
        }

        private void descTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            previewDescTB.Text = descTB.Text;
        }

        private void imageUrlTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                previewImg.Source = new BitmapImage(new Uri(imageUrlTB.Text));
            }
            catch { }
        }
        #endregion

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            loading.IsActive = true;
            await WebAPIClass.PostJsonToServerAsync(vm, "MarketItem");
            this.Frame.Navigate(typeof(MarketView));
        }

        private async void cloudBtn_Click(object sender, RoutedEventArgs e)
        {
            await uploadToOneDrive();
    
        }

        const string onedriveUrl= @"https://login.live.com/oauth20_authorize.srf?client_id=0000000044184D12&scope=onedrive.readwrite&response_type=token&redirect_uri=https://login.live.com/oauth20_desktop.srf";

        private async Task uploadToOneDrive()
        {
            webView.Visibility = Visibility.Visible;
            //var fop = new FileOpenPicker();
            //var file = await fop.PickSingleFileAsync();

            //if(file != null)
            {
                webView.Navigate(new Uri(onedriveUrl));

                webView.NavigationCompleted += (sender, e) =>
                {
                    var url = webView.Source.ToString();
                    if (url.Contains("&authentication_token="))
                    {
                        webView.Visibility = Visibility.Collapsed;
                        var hc = new HttpClient();

                    }
                };

            }

        }
    }
}
