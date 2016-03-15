using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Chronos
{
    public sealed partial class RoundProgressControl : UserControl
    {
        MyDate date = new MyDate();

        public RoundProgressControl()
        {
            this.InitializeComponent();
            TheGrid.DataContext = date;
        }


        public void SetBarLength(double Value)
        {
            double Angle = 2 * 3.14159265 * Value;

            double X = 50 - Math.Sin(Angle) * 50;
            double Y = 50 + Math.Cos(Angle) * 50;

            if (Value > 0 && (int)X == 50 && (int)Y == 100)
                X += 0.01; // Never make the end the same as the start!

            // Run this on the UI thread because the IsLargeArc and Point values need to get set only in that thread.
            IAsyncAction TheTask =
                CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    TheSegment.IsLargeArc = Angle >= 3.14159265;
                    TheSegment.Point = new Point(X, Y);

                    /*
                     * I had been using a storyboard animation to ensure that 
                     * the UI updated the control smoothly, but that doesn\'t 
                     * seem necessary. The code is still here in case it is 
                     * warranted, but there is a small glitch when the arc 
                     * goes from small to large (IsLargeArc=true).
                     */

                    //                ThePointAnimation.To = new Point( X, Y );
                    //                Storyboard1.Begin();
                    date.GetProgress = Value;
                });
        }

    }

    class MyDate : INotifyPropertyChanged
    {

        private double progress;

        public double GetProgress
        {
            set
            {
                if (value != progress)
                {
                    progress = value;
                    NotifyPropertyChanged();
                }
            }
            get { return progress; }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
