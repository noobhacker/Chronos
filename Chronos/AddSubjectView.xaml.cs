using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ChronosWebAPI.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Windows.Web.Http;
using System.Threading.Tasks;
using Chronos.ViewModels;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSubjectView : Page
    {
        AddSubjectViewModel vm = new AddSubjectViewModel();
        public AddSubjectView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true;
                }
            };
        }

      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vm.sessions.Add(new SubjectSession());
            sessionsGV.ItemsSource = vm.sessions;

        }

        private void sessionsGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sessionsGV.SelectedItems.Count != 0)
                deleteSessionBtn.IsEnabled = true;
            else
                deleteSessionBtn.IsEnabled = false;
        }

        private void addSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.sessions.Add(new SubjectSession());
        }

        private void deleteSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.sessions.RemoveAt(sessionsGV.SelectedIndex);            
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            loading.IsActive = true;
            string target = string.Format("SubjectTimeTable");
            vm.subject.Code = vm.subject.Code.Replace(" ", "");
            var obj = JsonConvert.SerializeObject(vm);

            vm.student.FullName = ""; // remove this because name doesnt matter in adding subject, only id required

            await WebAPIClass.PostJsonToServerAsync(obj, target);
            
            this.Frame.Navigate(typeof(HomeView));
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void endTimeTP_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {

        }
    }
}
