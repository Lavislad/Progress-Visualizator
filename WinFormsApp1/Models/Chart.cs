namespace ProgressVisualizer.Models
{
    public class Chart
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public string XAxisName { get; set; } = "";

        public string XAxisType { get; set; } = "Number";

        public string YAxisName { get; set; } = "";

        public string YAxisUnit { get; set; } = "";

        public DateTime CreatedDate { get; set; }
    }
}