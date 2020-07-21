using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers
using LiveCharts.Definitions.Series;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cartesianChart1.Series.Add(
                new LineSeries
                {
                    Title = "Выполнено",
                    Values = new ChartValues<double> { 3, 4, 5, 3, 7, 5, 6 },
                    StrokeThickness = 2,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(200,75,0)),
                    Fill = System.Windows.Media.Brushes.LightSalmon
                }
            );
            cartesianChart1.Series.Add(
                new LineSeries
                {
                    Title = "Провалено",
                    Values = new ChartValues<double> { 5, 7, 3, 4, 5, 3, 8 },
                    StrokeThickness = 2,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(110, 110, 110)),
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            );
            cartesianChart1.AxisX.Add(
                new Axis
                {
                    Separator = new Separator
                    {
                        Step = 1,
                        IsEnabled = false
                    },
                    FontSize = 14,
                    Labels = new[] { "ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС" }
                });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Количество задач",
                Separator = new Separator
                {
                    Step = 1,
                    IsEnabled = false
                },
                FontSize = 14
            });

            Func<ChartPoint, string> labelPoint = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "В процессе",
                    FontSize = 12,
                    Foreground = System.Windows.Media.Brushes.Black,
                    Values = new ChartValues<double> {4},
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
                    Values = new ChartValues<double> {3},
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
                    Values = new ChartValues<double> {1},
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(110, 110, 110)),
                    Fill = System.Windows.Media.Brushes.Silver,
                    PushOut = 3,
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            pieChart1.LegendLocation = LegendLocation.Right;


            //cartesianChart1.Series = new
            //{
            //    new LineSeries
            //    {
            //        Values = new ChartValues<double> { 3, 5, 7, 4 }
            //    },
            //    new BarSeries
            //    {
            //        Values = new ChartValues<decimal> { 5, 6, 2, 7 }
            //    }
            //};
        }
    }
}
