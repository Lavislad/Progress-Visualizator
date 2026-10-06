using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ProgressVisualizer.Models;
using ScottPlot.WinForms;

namespace ProgressVisualizer.Visualization
{
    public class ChartRenderer
    {
        public void Draw(
    FormsPlot formsPlot,
    Chart chart,
    List<DataPoint> points)
        {
            formsPlot.Plot.Clear();

            if (points == null || points.Count == 0)
            {
                formsPlot.Refresh();
                return;
            }

            if (chart.XAxisType == "Number")
            {
                DrawNumericX(
                    formsPlot,
                    chart,
                    points);
            }
            else if (chart.XAxisType == "Date")
            {
                DrawDateX(
                    formsPlot,
                    chart,
                    points);
            }
            else
            {
                DrawTextX(
                    formsPlot,
                    chart,
                    points);
            }

            formsPlot.Refresh();
        }

        private void DrawDateX(
    FormsPlot formsPlot,
    Chart chart,
    List<DataPoint> points)
        {
            var validPoints = new List<(DateTime Date, double Y)>();

            foreach (DataPoint point in points)
            {
                if (DateTime.TryParse(
                    point.XValue,
                    out DateTime date))
                {
                    validPoints.Add(
                        (date, point.YValue));
                }
            }

            if (validPoints.Count == 0)
                return;

            validPoints = validPoints
                .OrderBy(p => p.Date)
                .ToList();

            double[] xs = validPoints
                .Select(p =>
                    p.Date.ToOADate())
                .ToArray();

            double[] ys = validPoints
                .Select(p => p.Y)
                .ToArray();

            formsPlot.Plot.Add.Scatter(
                xs,
                ys);

            formsPlot.Plot.Axes.AutoScale();

            formsPlot.Plot.XLabel(
                chart.XAxisName);

            string yLabel =
                chart.YAxisName;

            if (!string.IsNullOrWhiteSpace(
                chart.YAxisUnit))
            {
                yLabel +=
                    $" ({chart.YAxisUnit})";
            }

            formsPlot.Plot.YLabel(yLabel);

            formsPlot.Plot.Axes.DateTimeTicksBottom();
        }

        private void DrawNumericX(
            FormsPlot formsPlot,
            Chart chart,
            List<DataPoint> points)
        {
            var validPoints = new List<DataPoint>();

            foreach (DataPoint point in points)
            {
                if (double.TryParse(
                    point.XValue.Replace(',', '.'),
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out _))
                {
                    validPoints.Add(point);
                }
            }

            if (validPoints.Count == 0)
                return;

            validPoints = validPoints
                .OrderBy(p =>
                    double.Parse(
                        p.XValue.Replace(',', '.'),
                        CultureInfo.InvariantCulture))
                .ToList();

            double[] xs = validPoints
                .Select(p =>
                    double.Parse(
                        p.XValue.Replace(',', '.'),
                        CultureInfo.InvariantCulture))
                .ToArray();

            double[] ys = validPoints
                .Select(p => p.YValue)
                .ToArray();

            formsPlot.Plot.Add.Scatter(xs, ys);

            formsPlot.Plot.Axes.AutoScale();

            formsPlot.Plot.XLabel(chart.XAxisName);

            string yLabel = chart.YAxisName;

            if (!string.IsNullOrWhiteSpace(chart.YAxisUnit))
                yLabel += $" ({chart.YAxisUnit})";

            formsPlot.Plot.YLabel(yLabel);
        }

        private void DrawTextX(
            FormsPlot formsPlot,
            Chart chart,
            List<DataPoint> points)
        {
            double[] xs = Enumerable
                .Range(0, points.Count)
                .Select(x => (double)x)
                .ToArray();

            double[] ys = points
                .Select(p => p.YValue)
                .ToArray();

            formsPlot.Plot.Add.Scatter(xs, ys);

            formsPlot.Plot.Axes.AutoScale();

            formsPlot.Plot.XLabel(chart.XAxisName);

            string yLabel = chart.YAxisName;

            if (!string.IsNullOrWhiteSpace(chart.YAxisUnit))
                yLabel += $" ({chart.YAxisUnit})";

            formsPlot.Plot.YLabel(yLabel);

            // Создаём подписи для текстовой оси X
            var tickPositions = xs;
            var tickLabels = points
                .Select(p => p.XValue)
                .ToArray();

            var ticks =
                new ScottPlot.TickGenerators.NumericManual(
                    tickPositions,
                    tickLabels);

            formsPlot.Plot.Axes.Bottom.TickGenerator = ticks;
        }
    }
}
