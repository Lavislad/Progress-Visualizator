namespace ProgressVisualizer.Models
{
    public class DataPoint
    {
        public int Id { get; set; }

        public int ChartId { get; set; }

        public string XValue { get; set; } = "";

        public double YValue { get; set; }
    }
}