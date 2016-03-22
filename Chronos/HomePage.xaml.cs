using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using ChronosWebAPI.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            nowTB.Text = DateTime.Now.ToString("d MMM yyyy");
        }
                
        private async void update()
        {
            try
            {
                string subjectsJson = await getJsonFromServer("SubjectTimeTable");
                var subjects = JsonConvert.DeserializeObject<List<Subject>>(subjectsJson);
                laterGV.ItemsSource = subjects;
            }
            catch { }
        }        

        private async Task<string> getJsonFromServer(string target)
        {
            var client = new HttpClient();
            string result = await client.GetStringAsync(GlobalVariables.WebAPIAddress + 
                target + "/" + GlobalVariables.CurrentUser.Id);

            return result;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //ProgressControl.SetBarLength(0.78);
            update();
        }

        private void addSubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddSubjectPage)); ;
        }
    }

}
