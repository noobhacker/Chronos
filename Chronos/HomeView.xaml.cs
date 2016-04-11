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
using Chronos.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeView : Page
    {
        HomeViewModel vm = new HomeViewModel();
        DispatcherTimer timer = new DispatcherTimer();
        public HomeView()
        {
            this.InitializeComponent();
            //this.NavigationCacheMode = NavigationCacheMode.Enabled;
            nowTB.Text = DateTime.Now.ToString("D");
            nameTB.Text = GlobalVariables.CurrentUser.FullName;

            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Tick += Timer_Tick;
            timer.Start();

            ProgressControl2.SetBarLength(1);
        }

        private void Timer_Tick(object sender, object e)
        {
            if (vm.laterGVItems.Count == 0)
                return;

            DateTime start = DateTime.Today.Add(vm.laterGVItems[0].StartTime);
            DateTime end = DateTime.Today.Add(vm.laterGVItems[0].EndTime);

            DateTime now = DateTime.Now;

            if (now > start && now < end)
            {
                stackPanel.Visibility = Visibility.Visible;
                var maxValue = end.TimeOfDay.TotalSeconds - start.TimeOfDay.TotalSeconds;
                var currentValue = now.TimeOfDay.TotalSeconds - start.TimeOfDay.TotalSeconds;

                double percentage = currentValue / maxValue;
                ProgressControl.SetBarLength(percentage);
                nowPercentTB.Text = Math.Round(percentage*100).ToString() + "%";

                nowSubjectTB.Text = vm.laterGVItems[0].SubjectText;
                nowClassTypeTB.Text = vm.laterGVItems[0].ClassType;
                nowSubjectTime.Text = vm.laterGVItems[0].StartTimeText + " - " + 
                    vm.laterGVItems[0].EndTimeText;
                nowSubjectLecturer.Text = vm.laterGVItems[0].Lecturer;
            }
            else
                stackPanel.Visibility = Visibility.Collapsed;
        }

        private async Task<bool> refresh(int id)
        {
            string target = "SubjectTimeTable";
            string subjectsJson = await WebAPIClass.GetJsonFromServerAsync(target, id.ToString());

            var _vm = JsonConvert.DeserializeObject<HomeViewModel>(subjectsJson);
        
            vm.laterGVItems = _vm.laterGVItems;

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
            if (e.Parameter == null || Convert.ToInt32(e.Parameter) == GlobalVariables.CurrentUser.Id)
                await refresh(GlobalVariables.CurrentUser.Id);
            else
            {
                await refresh(Convert.ToInt32(e.Parameter.ToString()));
                hiTB.Visibility = Visibility.Collapsed;
                nameTB.Visibility = Visibility.Collapsed;
            }

            Timer_Tick(null, null); // trigger before update duration, 30 sec
            loading.Visibility = Visibility.Collapsed;
            updatedTB.Text = "updated as of " + DateTime.Now.ToString("hh.mmtt");
        }

        private void addSubjectBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddSubjectView)); ;
        }
    }

}
