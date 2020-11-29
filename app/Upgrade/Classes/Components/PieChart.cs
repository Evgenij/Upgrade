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
    class PieChart : Chart
    {
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
                    PushOut = 2,
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
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(3, 142, 0)),
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 211, 102)),
                    PushOut = 2,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Провалено",
                    FontSize = 12,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Values = new ChartValues<double> {countTaskFailed},
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(214, 45, 48)),
                    Fill = System.Windows.Media.Brushes.LightCoral,
                    PushOut = 2,
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart.LegendLocation = LegendLocation.Right;

            box.Controls.Add(pieChart);
        }

        public void SetChart(int countTaskInWork, int countTaskDone, int countTaskFailed)
        {
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
                    PushOut = 2,
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
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(3, 142, 0)),
                    Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(105, 211, 102)),
                    PushOut = 2,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Провалено",
                    FontSize = 12,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Values = new ChartValues<double> {countTaskFailed},
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(214, 45, 48)),
                    Fill = System.Windows.Media.Brushes.LightCoral,
                    PushOut = 2,
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart.LegendLocation = LegendLocation.Right;
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
