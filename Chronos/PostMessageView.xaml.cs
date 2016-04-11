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
using Chronos.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PostMessageView : Page
    {
        PostMessageViewModel vm = new PostMessageViewModel();
        public PostMessageView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
                replyGroup.Visibility = Visibility.Collapsed;
            else
                postGroup.Visibility = Visibility.Collapsed;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
            //else
                // huh??
        }

        private async void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            loading.IsActive = true;

            if (vm.ReceiverId == 0)
                try
                {
                    vm.ReceiverId = Convert.ToInt32(receiverTB.Text);
                }
                catch
                {
                    noReceipentTB.Visibility = Visibility.Visible;
                    return;
                }

            await WebAPIClass.PostJsonToServerAsync(vm,"PrivateMessage");

            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }
    }
}
