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

        private async void addBtn_Click(object sender, RoutedEventArgs e)
        {
            await WebAPIClass.PostJsonToServerAsync(vm, "MarketItem");
            this.Frame.Navigate(typeof(MarketView));
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

    }
}
