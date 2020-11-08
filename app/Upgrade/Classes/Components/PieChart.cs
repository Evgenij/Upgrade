using LiveCharts;
using LiveCharts.Definitions.Series;
using LiveCharts.WinForms; //the WinForm wrappers
using LiveCharts.Wpf;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upgrade.Classes.Components
{
    class PieChart
    {
        private LiveCharts.WinForms.PieChart pieChart;
        Func<ChartPoint, string> labelPoint = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        public PieChart(Control box, int x, int y, int countTaskInWork, int countTaskDone, int countTaskFailed) 
        {
            pieChart = new LiveCharts.WinForms.PieChart();
            pieChart.Top = y;
            pieChart.Left = x;
            pieChart.Size = new System.Drawing.Size(350, 180);
            pieChart.Cursor = Cursors.Hand;

            pieChart.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "В процессе",
                    FontSize = 12,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Values = new ChartValues<double> {countTaskInWork},
                    StrokeThickness = 2,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(200,75,0)),
                    Fill = System.Windows.Media.Brushes.Coral,
                    PushOut = 3,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Выполнено",
                    FontSize = 12,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Values = new ChartValues<double> {countTaskDone},
                    StrokeThickness = 2,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(33,150,83)),
                    Fill = System.Windows.Media.Brushes.LightGreen,
                    PushOut = 3,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Провалено",
                    FontSize = 12,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Values = new ChartValues<double> {countTaskFailed},
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(110, 110, 110)),
                    Fill = System.Windows.Media.Brushes.Silver,
                    PushOut = 3,
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart.LegendLocation = LegendLocation.Right;

            box.Controls.Add(pieChart);
        }

        public void Hide() 
        {
            pieChart.Hide();
        }
        public void Show()
        {
            pieChart.Show();
        }
    }
}
