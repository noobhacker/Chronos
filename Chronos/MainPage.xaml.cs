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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            listview.SelectedIndex = 0;
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationFrame.Navigate(typeof(HomeView));
        }

        private void hamburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            splitview.IsPaneOpen = !splitview.IsPaneOpen;
        }

        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (listview.SelectedIndex != ((ListView)e.OriginalSource).SelectedIndex) // experiment

            //if (listview.SelectedIndex == 5)
            //    navigationFrame.Margin = new Thickness(0);
            //else
            //    navigationFrame.Margin = new Thickness(32, 0, 32, 0);

            try
            {
                switch (listview.SelectedIndex)
                {
                    case 0:
                        navigationFrame.Navigate(typeof(HomeView));
                        break;
                    case 1:
                        navigationFrame.Navigate(typeof(CalendarView));
                        break;
                    case 2:
                        navigationFrame.Navigate(typeof(ConfessionView));
                        break;
                    case 3:
                        navigationFrame.Navigate(typeof(PlacesView));
                        break;
                    case 4:
                        navigationFrame.Navigate(typeof(MarketView));
                        break;
                    case 5:
                        navigationFrame.Navigate(typeof(PrivateMessageView));
                        break;
                    case 6:
                        navigationFrame.Navigate(typeof(SettingsView));
                        break;
                }
                
            }
            catch { }
        }
    }
}
