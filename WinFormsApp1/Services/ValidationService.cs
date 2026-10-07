using System;
using System.Globalization;
using ProgressVisualizer.Models;

namespace ProgressVisualizer.Services
{
    public class ValidationService
    {
        public bool ValidateChart(Chart chart)
        {
            if (chart == null)
                return false;

            if (string.IsNullOrWhiteSpace(chart.Name))
                return false;

            if (string.IsNullOrWhiteSpace(chart.XAxisName))
                return false;

            if (string.IsNullOrWhiteSpace(chart.XAxisType))
                return false;

            if (string.IsNullOrWhiteSpace(chart.YAxisName))
                return false;

            if (chart.XAxisType != "Number" &&
                chart.XAxisType != "Text" &&
                chart.XAxisType != "Date")
            {
                return false;
            }

            return true;
        }

        public bool ValidateDataPoint(
            DataPoint point,
            string xAxisType)
        {
            if (point == null)
                return false;

            if (string.IsNullOrWhiteSpace(point.XValue))
                return false;

            if (xAxisType == "Number")
            {
                return double.TryParse(
                    point.XValue.Replace(',', '.'),
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out _);
            }

            if (xAxisType == "Date")
            {
                return DateTime.TryParse(
                    point.XValue,
                    out _);
            }

            if (xAxisType == "Text")
            {
                return true;
            }

            return false;
        }

        public bool ValidateY(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return double.TryParse(
                value.Replace(',', '.'),
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out _);
        }
    }
}