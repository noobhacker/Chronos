using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CalendarView : Page
    {
        CalendarViewModel vm = new CalendarViewModel();
        public CalendarView()
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            refresh();
        }

        private async void refresh()
        {
            string result = await WebAPIClass.GetJsonFromServerAsync("Calendar", vm.student.Id.ToString());
            var _vm = JsonConvert.DeserializeObject<CalendarViewModel>(result);
            vm.eventList = _vm.eventList;
            generateUpcoming();
            upcomingLst.ItemsSource = vm.upcomingList;
        }

        private void generateUpcoming()
        {
            vm.upcomingList.Clear();
            foreach (var itm in vm.eventList)
            {
                string dueday = itm.DueDate.Subtract(DateTime.Now).Days.ToString();
                vm.upcomingList.Add(dueday + " : " + itm.Desc);
            }
        }

        private async void addBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.input.DueDate = dueDateDP.Date.Date.Date;
            vm.input.DueDate.Add(dueTimeTP.Time);

            var _vm = vm;

            // clear off useless thing before post to server

            _vm.eventList = new ObservableCollection<ChronosWebAPI.Models.Event>();
            _vm.upcomingList = new ObservableCollection<string>();

            await WebAPIClass.PostJsonToServerAsync(_vm, "Calendar");
            // clear boxes
            refresh();
        }
    }
}