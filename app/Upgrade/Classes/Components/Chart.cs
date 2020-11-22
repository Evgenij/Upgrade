using LiveCharts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrade.Classes.Components
{
    class Chart
    {
        protected LiveCharts.WinForms.PieChart pieChart;
        protected LiveCharts.WinForms.CartesianChart chart;

        protected Func<ChartPoint, string> labelPoint = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

    }
}
