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
using ChronosWebAPI.Models;
using System.Collections.ObjectModel;

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

        ObservableCollection<SubjectSession> sessions = new ObservableCollection<SubjectSession>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //dayCB.ItemsSource = days;
            //sessionTypeCB.ItemsSource = sessionTypes;

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

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
