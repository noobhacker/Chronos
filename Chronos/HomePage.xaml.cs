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
        HomePageViewModel vm = new HomePageViewModel();
        public HomePage()
        {
            this.InitializeComponent();
            nowTB.Text = DateTime.Now.ToString("D");
            nameTB.Text = GlobalVariables.CurrentUser.FullName;
        }

        private async Task<bool> update()
        {
            string target = "SubjectTimeTable";
            string subjectsJson = await WebAPIClass.GetJsonFromServerAsync(target);

            vm = JsonConvert.DeserializeObject<HomePageViewModel>(subjectsJson);

            foreach (var s in vm.laterGVItems)
                s.StartTimeText = DateTime.Today.Add(s.StartTime).ToString("hh.mmtt");

            foreach (var e in vm.laterGVItems)
                e.EndTimeText = DateTime.Today.Add(e.EndTime).ToString("hh.mmtt");

            laterGV.ItemsSource = vm.laterGVItems;
            return true;
        }   


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //ProgressControl.SetBarLength(0.78);
            await update();
            updatedTB.Text = "updated as of " + DateTime.Now.ToString("hh.mmtt");
        }

        private void addSubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddSubjectView)); ;
        }
    }

}
