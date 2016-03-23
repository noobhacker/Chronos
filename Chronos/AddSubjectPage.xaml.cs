using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ChronosWebAPI.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Windows.Web.Http;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSubjectPage : Page
    {
        AddSubjectPageViewModel vm = new AddSubjectPageViewModel();
        public AddSubjectPage()
        {
            this.InitializeComponent();
            this.DataContext = vm;      
        }

      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vm.sessions.Add(new SubjectSession());
            sessionsGV.ItemsSource = vm.sessions;

        }
        
        private void addSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.sessions.Add(new SubjectSession());
        }

        private void deleteSessionBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string target = string.Format("SubjectTimeTable");
            vm.subject.Code = vm.subject.Code.Replace(" ", "");
            var obj = JsonConvert.SerializeObject(vm);

            vm.student.FullName = ""; // remove this because name doesnt matter in adding subject, only id required

            await WebAPIClass.PostJsonToServerAsync(obj, target);
            
            this.Frame.Navigate(typeof(HomePage));
        }
       

    }
}
