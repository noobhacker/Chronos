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
            navigationFrame.Navigate(typeof(CalendarPage));
        }

        private void hamburgerBtn_Click(object sender, RoutedEventArgs e)
        {
            splitview.IsPaneOpen = !splitview.IsPaneOpen;
        }

        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (listview.SelectedIndex != ((ListView)e.OriginalSource).SelectedIndex) // experiment
            try
            {
                switch (listview.SelectedIndex)
                {
                    case 0:
                        navigationFrame.Navigate(typeof(HomePage));
                        break;
                    case 1:
                        navigationFrame.Navigate(typeof(CalendarPage));
                        break;
                    case 2:
                        navigationFrame.Navigate(typeof(ConfessionPage));
                        break;
                    case 3:
                        navigationFrame.Navigate(typeof(PlacesPage));
                        break;
                }
            }
            catch { }
        }
    }
}
