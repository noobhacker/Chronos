using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Media.SpeechRecognition;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private string[] uniList = {"Multimedia University Malacca", "INTI University" };

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

            switch(listview.SelectedIndex)
            {
                case 7: case 8:
                    searchGroup.Visibility = Visibility.Collapsed;
                    break;
                default:
                    searchGroup.Visibility = Visibility.Visible;
                    break;
            }

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
                        navigationFrame.Navigate(typeof(FinancesView));
                        break;
                    case 3:
                        navigationFrame.Navigate(typeof(ConfessionView));
                        break;
                    case 4:
                        navigationFrame.Navigate(typeof(PlacesView));
                        break;
                    case 5:
                        navigationFrame.Navigate(typeof(MarketView));
                        break;
                    case 6:
                        navigationFrame.Navigate(typeof(PrivateMessageView));
                        break;
                    case 7:
                        navigationFrame.Navigate(typeof(SettingsView));
                        break;
                    case 8:
                        navigationFrame.Navigate(typeof(WebFrame),
                            "https://webchat.botframework.com/embed/9NBLGGH4RBMQ?s=DJkp4A8IKgg.cwA.518.8GDTadzh9y2dNXy8pVCupmuR57_7GZoROQ3dIXHs1oQ");
                        break;
                }
                
            }
            catch { }
        }

        SpeechRecognizer sr = new SpeechRecognizer();
        private async void startVoiceRecogAsync()
        {
            searchBoxTB.Text = "";
            searchBoxTB.PlaceholderText = "Listening";
            
            try
            {
                if (sr.State == SpeechRecognizerState.Idle)
                {
                    var res = await sr.RecognizeAsync();

                    if (res.Text != "")
                    {
                        searchBoxTB.Text = res.Text;
                        search(searchBoxTB.Text);
                        searchBoxTB.PlaceholderText = "Search";
                    }
                }

            }
            catch
            {
                //searchBoxTB.PlaceholderText = "Restarting session";
                //await Task.Delay(1000);
                searchBoxTB.PlaceholderText = "Search";
            }
        }

        private async void search(string keyword)
        {
            switch (listview.SelectedIndex)
            {
                case 0:
                    try
                    {
                        Convert.ToInt32(keyword);
                    }
                    catch
                    {
                        await new MessageDialog("To search in time table view, enter your friend's ID to search").ShowAsync();
                        return;
                    }
                    navigationFrame.Navigate(typeof(HomeView), keyword);
                    break;
              
            }
        }

        private void voiceRecogBtn_Click(object sender, RoutedEventArgs e)
        {
            startVoiceRecogAsync();
        }

        private void imageRecogBtn_Click(object sender, RoutedEventArgs e)
        {
            navigationFrame.Navigate(typeof(WebFrame), "https://www.captionbot.ai/");
        }

        private void searchBoxTB_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                search(searchBoxTB.Text);
                return;
            }

            switch (listview.SelectedIndex)
            {
                case 3:
                case 4:
                case 5:
                    searchBoxTB.ItemsSource = new List<string>(uniList).Where(x => x.Contains(searchBoxTB.Text));
                    break;
            }
            
        }

        private void searchBoxTB_GotFocus(object sender, RoutedEventArgs e)
        {
            switch (listview.SelectedIndex)
            {
                case 3:
                case 4:
                case 5:
                    searchBoxTB.ItemsSource = uniList;
                    break;
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            search(searchBoxTB.Text);
        }
    }
}
