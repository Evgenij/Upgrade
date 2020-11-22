using LiveCharts;
using LiveCharts.Wpf;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using Separator = LiveCharts.Wpf.Separator;

namespace Upgrade.Classes.Components
{
    class StatisticChart : Chart
    {
        public StatisticChart(Control box, int x, int y, List<int> valuesD, List<int> valuesF)
        {
            chart = new LiveCharts.WinForms.CartesianChart();
            chart.Top = y;
            chart.Left = x;
            chart.Size = new System.Drawing.Size(400, 230);
            chart.Cursor = Cursors.Hand;

            SetChart(valuesD, valuesF);

            box.Controls.Add(chart);
        }

        public void SetChart(List<int> valuesD, List<int> valuesF, bool month = false, string[] daysMonth = null) 
        {
            chart.Series.Clear();
            chart.AxisX.Clear();
            chart.AxisY.Clear();

            ChartValues<int> valuesDone = new ChartValues<int>();
            ChartValues<int> valuesFail = new ChartValues<int>();

            if (month == false)
            {
                // System.Windows.Media.Brushes brush = new System.Windows.Media.Brushes;

                for (int i = 0; i < valuesD.Count; i++)
                {
                    valuesDone.Add(valuesD[i]);
                }
                for (int i = 0; i < valuesD.Count; i++)
                {
                    valuesFail.Add(valuesF[i]);
                }

                chart.Series.Add(
                    new LineSeries
                    {
                        Title = "Выполнено",
                        Values = valuesDone,
                        StrokeThickness = 2,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(Design.mainColor.R, Design.mainColor.G, Design.mainColor.B)),
                        Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220,220,220))
                    }
                );
                chart.Series.Add(
                    new LineSeries
                    {
                        Title = "Провалено",
                        Values = valuesFail,
                        StrokeThickness = 2,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(110, 110, 110)),
                        Fill = System.Windows.Media.Brushes.Transparent
                    }
                );
                chart.AxisX.Add(
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

                chart.AxisY.Add(new Axis
                {
                    Title = "Количество задач",
                    Separator = new Separator
                    {
                        Step = 1,
                        IsEnabled = false
                    },
                    FontSize = 14
                });
            }
            else 
            {
                for (int i = 0; i < valuesD.Count; i++)
                {
                    valuesDone.Add(valuesD[i]);
                }
                for (int i = 0; i < valuesD.Count; i++)
                {
                    valuesFail.Add(valuesF[i]);
                }

                chart.Series.Add(
                    new LineSeries
                    {
                        Title = "Выполнено",
                        Values = valuesDone,
                        StrokeThickness = 2,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(Design.mainColor.R, Design.mainColor.G, Design.mainColor.B)),
                        Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 220, 220))
                    }
                );
                chart.Series.Add(
                    new LineSeries
                    {
                        Title = "Провалено",
                        Values = valuesFail,
                        StrokeThickness = 2,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(110, 110, 110)),
                        Fill = System.Windows.Media.Brushes.Transparent
                    }
                );
                chart.AxisX.Add(
                    new Axis
                    {
                        Separator = new Separator
                        {
                            Step = 4,
                            IsEnabled = false
                        },
                        FontSize = 14,
                        Labels = daysMonth
                    });

                chart.AxisY.Add(new Axis
                {
                    Title = "Количество задач",
                    Separator = new Separator
                    {
                        Step = 1,
                        IsEnabled = false
                    },
                    FontSize = 14
                });
            }
        }

        public void Hide()
        {
            chart.Hide();
        }
        public void Show()
        {
            chart.Show();
        }
    }
}
