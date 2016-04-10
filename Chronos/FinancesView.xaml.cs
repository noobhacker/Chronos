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
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Chronos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinancesView : Page
    {
        public FinancesView()
        {
            this.InitializeComponent();
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lst = new List<ChartItem>();

            lst.Add(new ChartItem()
            {
                Name = "Breakfast",
                Amount = Convert.ToInt32(breakfastTB.Text)
            });
            lst.Add(new ChartItem()
            {
                Name = "Lunch",
                Amount = lunchTB.Text == ""? 0 : Convert.ToInt32(lunchTB.Text)
            });
            lst.Add(new ChartItem()
            {
                Name = "Dinner",
                Amount = dinnerTB.Text == "" ? 0 : Convert.ToInt32(dinnerTB.Text)
            });
            lst.Add(new ChartItem()
            {
                Name = "Internet",
                Amount = internetTB.Text == "" ? 0 : Convert.ToInt32(internetTB.Text)
            });
            lst.Add(new ChartItem()
            {
                Name = "Network Data",
                Amount = dataTB.Text == "" ? 0 : Convert.ToInt32(dataTB.Text)
            });
            lst.Add(new ChartItem()
            {
                Name = "Utilities",
                Amount = rentalTB.Text == "" ? 0 : Convert.ToInt32(rentalTB.Text)
            });

            (PieChart.Series[0] as PieSeries).ItemsSource = lst;

        }
    }

    public class ChartItem
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }
}
