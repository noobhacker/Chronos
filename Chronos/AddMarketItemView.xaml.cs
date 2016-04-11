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
using Windows.Storage;
using Windows.UI.Popups;

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

        const string onedriveUrl= @"https://login.live.com/oauth20_authorize.srf?client_id=0000000044184D12&scope=wl.skydrive_update&response_type=token&redirect_uri=https://login.live.com/oauth20_desktop.srf";

        private async Task uploadToOneDrive()
        {
            webView.Visibility = Visibility.Visible;
            //var fop = new FileOpenPicker();
            //var file = await fop.PickSingleFileAsync();

            //if(file != null)
            {
                loading.IsActive = true;

                webView.Navigate(new Uri(onedriveUrl));

                webView.NavigationCompleted += async (sender, e) =>
                {
                    loading.IsActive = false;

                    var url = webView.Source.ToString();
                    string keyword = "access_token=";
                    if (url.Contains(keyword))
                    {
                        loading.IsActive = true;

                        int index = url.IndexOf(keyword) + keyword.Length;
                        string token = url.Substring(index);
                        token = token.Substring(0, token.IndexOf("&"));

                        webView.Visibility = Visibility.Collapsed;
                        
                        var openPicker = new FileOpenPicker();
                        openPicker.ViewMode = PickerViewMode.Thumbnail;
                        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                        openPicker.FileTypeFilter.Add(".jpg");
                        openPicker.FileTypeFilter.Add(".jpeg");
                        openPicker.FileTypeFilter.Add(".png");

                        var file = await openPicker.PickSingleFileAsync();

                        var hc = new HttpClient();
                        var fs = await file.OpenStreamForReadAsync();

                        var HttpContent = new HttpStreamContent(fs.AsInputStream());
                        //HttpContent.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("multipart/form-data;");

                        string puturl = $"https://apis.live.net/v5.0/me/skydrive/files/{DateTime.UtcNow.Ticks}.png?access_token={token}";
                        var returnValue = await hc.PutAsync(new Uri(puturl), HttpContent);

                        if (returnValue.IsSuccessStatusCode)
                        {
                            var returnObj = JsonConvert.DeserializeObject<OnedriveResponseClass.RootObject>(returnValue.Content.ToString());
                            imageUrlTB.Text = returnObj.source;
                            previewImg.Source = new BitmapImage(new Uri(imageUrlTB.Text));
                        }
                        else
                        {
                            await new MessageDialog("error while uploading to onedrive").ShowAsync();
                        }

                        loading.IsActive = false;

                    }
                };

            }
        }
        
    }
}
