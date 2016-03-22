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
        
        public AddSubjectPage()
        {
            this.InitializeComponent();        
        }

        Subject subject = new Subject();
        ObservableCollection<SubjectSession> sessions = new ObservableCollection<SubjectSession>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            sessions.Add(new SubjectSession());
            sessionsGV.ItemsSource = sessions;

        }
        
        private void addSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            sessions.Add(new SubjectSession());
        }

        private void deleteSessionBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            subject.Code = codeTB.Text;
            subject.Name = subjectTB.Text;
            subject.Lecturer = lecturerTB.Text;

            await postJsonToServer(subject, "Subjects");

            foreach(var s in sessions)
            {
                s.Subject = subject;                
                await postJsonToServer(s, "SubjectSessions");
            }

            await postJsonToServer(new Student_Subject()
            {
                Subject = subject,
                Student = GlobalVariables.CurrentUser
            }, "Student_Subject");

            this.Frame.Navigate(typeof(HomePage));
        }
        
        private async Task<bool> postJsonToServer(object json, string target)
        {
            var subjectJson = JsonConvert.SerializeObject(json);
            var client = new HttpClient();
            var HttpContent = new HttpStringContent(subjectJson);
            HttpContent.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");

            var returnValue = await client.PostAsync(new Uri(GlobalVariables.WebAPIAddress + target), HttpContent);

            string a = "";

            return true;
        }

    }
}
